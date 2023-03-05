using SoftUni.Data;
using System.Text;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            string result = GetEmployee147(context);

            Console.WriteLine(result);
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeeWithId147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.Projects
                    .Select(p => new
                    {
                        p.Name
                    })
                    .OrderBy(p => p.Name)   
                    .ToList()
                })
                .ToList();

            foreach (var e in employeeWithId147)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine(p.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}