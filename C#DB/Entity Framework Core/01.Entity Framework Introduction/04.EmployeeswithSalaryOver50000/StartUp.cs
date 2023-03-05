namespace SoftUni
{
    using SoftUni.Data;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            string result = GetEmployeesWithSalaryOver50000(context);

            Console.WriteLine(result);
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithSalaryOver50000 = context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var employee in employeesWithSalaryOver50000)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString();
        }
    }
}