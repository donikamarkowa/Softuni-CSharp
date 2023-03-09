namespace SoftUni
{
    using Microsoft.EntityFrameworkCore.Metadata.Conventions;
    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context
                .Towns.
                FirstOrDefault(t => t.Name == "Seattle");

            var addresses = context
                .Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            foreach (var e in context.Employees)
            {
                if (addresses.Any(a => a.AddressId == e.AddressId))
                {
                    e.AddressId = null;
                }
            }

            int countOfAddressedDeleted = addresses.Count;

            context.Addresses.RemoveRange(addresses);
            context.Towns.Remove(townToDelete);

            context.SaveChanges();
            return $"{countOfAddressedDeleted} addresses in Seattle were deleted";
        }
    }
}