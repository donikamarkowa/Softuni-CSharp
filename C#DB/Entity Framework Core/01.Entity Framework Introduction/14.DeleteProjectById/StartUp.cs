using SoftUni.Data;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectsToDelete = context.Projects.Find(2);

            var projectsWithId2 = context
                .EmployeesProject
        }
    }
}