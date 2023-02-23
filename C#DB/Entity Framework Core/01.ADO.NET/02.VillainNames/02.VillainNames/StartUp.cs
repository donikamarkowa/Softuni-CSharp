using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _02.VillainNames
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection =
                new SqlConnection(@"Server=DESKTOP-CTSCET9\SQLEXPRESS01;Database=MinionsDB;Integrated Security=True;TrustServerCertificate=True;");
            sqlConnection.Open();
 
            SqlCommand sqlCommand = new SqlCommand(
                @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
                    FROM Villains AS v
                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                GROUP BY v.Id, v.Name
                  HAVING COUNT(mv.VillainId) > 3
                ORDER BY COUNT(mv.VillainId)"
                , sqlConnection);

            StringBuilder sb = new StringBuilder();

            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                string villianName = (string)sqlReader["Name"];
                int countOfMinions = (int)sqlReader["MinionsCount"];

                sb.AppendLine($"{villianName} - {countOfMinions}");
            }

            sqlConnection.Close();
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
