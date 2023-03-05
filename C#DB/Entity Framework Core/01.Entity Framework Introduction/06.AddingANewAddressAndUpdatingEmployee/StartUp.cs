namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();    

            string result = AddNewAddressToEmployee(context);

            Console.WriteLine(result);
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = newAddress;
            context.SaveChanges();

            var employeesWithTheirAddresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            foreach (var e in employeesWithTheirAddresses)
            {
                sb.AppendLine(e);
            }

            return sb.ToString().TrimEnd();
        }
    }
}