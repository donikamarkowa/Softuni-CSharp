using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            string result = GetEmployeesFromResearchAndDevelopment(context);

            Console.WriteLine(result);
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder(); 

            var employeesFromResearchAndDevelopmentDep = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var e in employeesFromResearchAndDevelopmentDep)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }

            return sb.ToString().TrimEnd(); 
        }

    }
}