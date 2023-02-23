using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _03.MinionNames
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection =
                new SqlConnection(@"Server=DESKTOP-CTSCET9\SQLEXPRESS01;Database=MinionsDB;Integrated Security=True;TrustServerCertificate=True;");
            sqlConnection.Open();

            SqlCommand sqlCommandForVillianId = new SqlCommand("@SELECT Name FROM Villains WHERE Id = @Id", sqlConnection);

            int id = int.Parse(Console.ReadLine());
            sqlCommandForVillianId.Parameters.AddWithValue("@Id", id);

            string nameOfVillian = (string)sqlCommandForVillianId.ExecuteScalar();
            if (nameOfVillian == null)
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Villain: {nameOfVillian}");


            SqlCommand sqlCommandForMinionsOfVillian = new SqlCommand(
                @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                            m.Name,
                                            m.Age
                                       FROM MinionsVillains AS mv
                                       JOIN Minions As m ON mv.MinionId = m.Id
                                      WHERE mv.VillainId = @Id
                                   ORDER BY m.Name", 
                sqlConnection);

            sqlCommandForMinionsOfVillian.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = sqlCommandForMinionsOfVillian.ExecuteReader();
            if (!reader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (reader.Read())
                {
                    long rowNum = (long)reader["RowNum"];
                    string minionName = (string)reader["Name"];
                    int minionAge = (int)reader["Age"];

                    sb.AppendLine($"{rowNum}. {minionName} {minionAge}");
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
