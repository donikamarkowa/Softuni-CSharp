using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           using SoftUniContext context = new SoftUniContext();

            string result = GetAddressesByTown(context);

            Console.WriteLine(result);
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder(); 

            var addresses = context
                .Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count()
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
    }
}