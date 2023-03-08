using SoftUni.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            string result = DeleteProjectById(softUniContext);

            Console.WriteLine(result);
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder(); 

            var projectsToDelete = context.Projects.Find(2);

            var projectsWithId2 = context
                .EmployeesProjects
                .Where(p => p.ProjectId == projectsToDelete.ProjectId)
                .ToList();

            context.EmployeesProjects.RemoveRange(projectsWithId2);
            context.Projects.Remove(projectsToDelete);
            context.SaveChanges();

            var projects = context
                .Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine(p);
            }

            return sb.ToString().TrimEnd();
        }
    }
}