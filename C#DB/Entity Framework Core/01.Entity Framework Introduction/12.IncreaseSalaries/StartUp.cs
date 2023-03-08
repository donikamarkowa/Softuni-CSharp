using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            string result = IncreaseSalaries(context);

            Console.WriteLine(result);
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Engineering"
                         || e.Department.Name == "Tool Design"
                         || e.Department.Name == "Marketing"
                         || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employees)
            {
                e.Salary += e.Salary*(decimal)0.12;
                context.SaveChanges();
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }
            
            return sb.ToString().TrimEnd(); 
        }
    }
}