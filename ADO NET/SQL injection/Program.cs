using System;
using System.Data;
using System.Data.SqlClient;

namespace SQL_injection
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionName = @"Data Source={{SERVER_NAME}};Initial Catalog={{DATABASE_NAME}};Integrated Security=True";
            //string connectionName = @"Data Source=(LocalDB)\mssqllocaldb;Initial Catalog=Hospital;Integrated Security=True";
            string connectionName = @"Data Source=IGOR\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";

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

                Console.Write("\nEnter name: ");
                string searchName = Console.ReadLine();

                //for SQL injection.png               
                command.CommandText = string.Format("SELECT * FROM Patient WHERE Name LIKE {0}", searchName);
                //for SQL injection2.png  
                command.CommandText = string.Format("SELECT * FROM Patient WHERE Name LIKE '{0}'", searchName);
                //command.CommandText = string.Format("INSERT INTO Patient(Age, Name) Values(23, '{0}')", searchName);

                //to avoid sql injection need use parameters
                command.CommandText = @"SELECT * FROM Patient WHERE Name = @Name";
                command.Parameters.AddWithValue("@Name", searchName);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}" +
                                      $"\n{new string('_', 19)}");

                    while (reader.Read())
                    {
                        //Console.Write(reader.GetValue(0) + " | ");
                        //Console.Write(reader.GetValue(1) + " | ");
                        //Console.Write(reader.GetValue(2) + " | ");
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);
                        Console.WriteLine($"{id}\t{name}\t{age}");
                    }
                }
                reader.Close();

                Console.Write("\nEnter id: ");
                int ID = int.Parse(Console.ReadLine());

                string query = @"SELECT * FROM Department WHERE ID = @ID";
                SqlCommand anotherCommand = new SqlCommand(query, connection); 
                SqlParameter parameter = new SqlParameter("@ID", ID);
                anotherCommand.Parameters.Add(parameter);

                reader = anotherCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t\t\t{reader.GetName(2)}");

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string phone = reader.GetString(2);
                        Console.WriteLine($"{id}\t{name}\t{phone}");
                    }
                }
                reader.Close();

                Console.Write("\nEnter a new patient name: ");
                string newName = Console.ReadLine();

                command.CommandText = "INSERT Patient(Name, Age) Values(@PatientName, 28); " +
                                      "SET @id=SCOPE_IDENTITY()";

                SqlParameter nameParameter = new SqlParameter("@PatientName", newName);
                command.Parameters.Add(nameParameter);

                var idParameter = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();

                Console.WriteLine($"Inserted Patient ID: {idParameter.Value}");
            }
            
            Console.ReadKey();
        }
    }
}
