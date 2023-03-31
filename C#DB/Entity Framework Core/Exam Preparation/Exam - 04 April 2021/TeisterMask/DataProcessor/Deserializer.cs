// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using System.Text;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));
            StringReader reader = new StringReader(xmlString);

            var projectDtos = (ImportProjectDto[])xmlSerializer.Deserialize(reader);

            ICollection<Project> projects = new HashSet<Project>();

            foreach (var projectDto in projectDtos)
            {
                bool isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validProjectOpenDate);

                bool isProjectDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedProjectDueDate);
                if (!IsValid(projectDto) ||
                    !isProjectOpenDateValid ||
                    (!string.IsNullOrWhiteSpace(projectDto.DueDate) && !isProjectDueDateValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime? validProjectDueDate = string.IsNullOrWhiteSpace(projectDto.DueDate)
                    ? null
                    : parsedProjectDueDate;

                Project project = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = validProjectOpenDate,
                    DueDate = validProjectDueDate,
                };

                ICollection<Task> tasks = new HashSet<Task>();
                foreach (var taskDto in projectDto.Tasks)
                {
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validTaskOpenDate);
                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validTaskDueDate);

                    if (!IsValid(taskDto)
                        || !isTaskOpenDateValid
                        || !isTaskDueDateValid
                        || validTaskOpenDate < validProjectOpenDate
                        || (validProjectDueDate != null && validTaskDueDate > validProjectDueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Task task = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = validTaskOpenDate,
                        DueDate = validTaskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType,
                        ProjectId = project.Id
                    };
                    tasks.Add(task);
                }
                project.Tasks = tasks;
                projects.Add(project);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            ICollection<Employee> employees = new HashSet<Employee>();
            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Employee employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };
                
                ICollection<Task> tasks = new HashSet<Task>();
                foreach (var taskDto in employeeDto.Tasks.Distinct())
                {
                    if (!context.Tasks.Any(t => t.Id == taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    employee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Employee = employee,
                        TaskId = taskDto
                    });
                }
                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}