using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO_NET
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionName = @"Data Source={{SERVER_NAME}};Initial Catalog={{DATABASE_NAME}};Integrated Security=True";
            string connectionName = @"Data Source=(LocalDB)\mssqllocaldb;Initial Catalog=Hospital;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionName))
            {
                connection.Open();
                Console.WriteLine(connection.State);
                Console.WriteLine(connection.ClientConnectionId);
                Console.WriteLine(connection.Database);
            }

            using (SqlConnection connection = new SqlConnection(connectionName))
            {
                connection.Open();
                Console.WriteLine(connection.ClientConnectionId);
                                
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                //угроза SQL injection
                Console.Write("\nEnter name: ");
                string searchName = Console.ReadLine();
                command.CommandText = string.Format("SELECT * FROM Patient WHERE Name = {0}", searchName);

                //types of commands                
                //command.ExecuteReader();
                //command.ExecuteNonQuery();
                //command.ExecuteScalar();

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.Write(reader.GetName(0) + " | ");
                    Console.Write(reader.GetName(1) + " | ");
                    Console.Write(reader.GetName(2));
                    Console.WriteLine();

                    while (reader.Read())
                    {
                        //Console.Write(reader.GetValue(0) + " | ");
                        //Console.Write(reader.GetValue(1) + " | ");
                        //Console.Write(reader.GetValue(2) + " | ");
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);
                        Console.WriteLine(id + " | " + name + " | " + age);
                    }
                }     
            }


            Console.ReadKey();
        }
    }
}
