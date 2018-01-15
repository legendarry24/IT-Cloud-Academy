using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

                // Console.Write("\nEnter name: ");
                //string searchName = Console.ReadLine();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                //угроза SQL injection                
                //command.CommandText = string.Format("SELECT * FROM Patient WHERE Name = {0}", searchName);
                //command.CommandText = string.Format("INSERT INTO Patient(Age, Name) Values(23, '{0}')", searchName);

                //types of commands                
                //command.ExecuteReader();
                //command.ExecuteNonQuery();
                //command.ExecuteScalar();
                #region Reader
                //var reader = command.ExecuteReader();

                //if (reader.HasRows)
                //{
                //    Console.Write(reader.GetName(0) + " | ");
                //    Console.Write(reader.GetName(1) + " | ");
                //    Console.Write(reader.GetName(2));
                //    Console.WriteLine();

                //    while (reader.Read())
                //    {
                //        //Console.Write(reader.GetValue(0) + " | ");
                //        //Console.Write(reader.GetValue(1) + " | ");
                //        //Console.Write(reader.GetValue(2) + " | ");
                //        int id = reader.GetInt32(0);
                //        string name = reader.GetString(1);
                //        int age = reader.GetInt32(2);
                //        Console.WriteLine(id + " | " + name + " | " + age);
                //    }
                //}
                #endregion

                //command.CommandText = "INSERT INTO Patient(Age, Name) Values(@name, 23); SET @id=SCOPE_IDENTITY()";

                //SqlParameter parameter1 = new SqlParameter("@name", searchName);
                //command.Parameters.Add(parameter1);

                //var idParameter = new SqlParameter
                //{
                //    ParameterName = "@id",
                //    SqlDbType = SqlDbType.Int,
                //    Direction = ParameterDirection.Output
                //};
                //command.Parameters.Add(idParameter);

                //var reader = command.ExecuteNonQuery();

                //Console.WriteLine($"Inserted Patient ID: {idParameter.Value}");
            }


            #region Stored Procedure

            //using (SqlConnection connection = new SqlConnection(connectionName))
            //{
            //    connection.Open();
            //    string commandText = "InsertPatient";

            //    SqlCommand command = new SqlCommand
            //    {
            //        Connection = connection,
            //        CommandText = commandText,
            //        CommandType = CommandType.StoredProcedure
            //    };

            //    Console.Write("\nEnter name: ");
            //    string newName = Console.ReadLine();

            //    Console.Write("\nEnter name: ");
            //    int newAge = int.Parse(Console.ReadLine());

            //    var name = new SqlParameter("@name", newName);
            //    var age = new SqlParameter("@age", newAge);

            //    var id = command.ExecuteScalar();

            //    Console.WriteLine($"Inserted patient id: {id}");                
            //}
            #endregion

            // for Stored Procedure 2
            var patients = GetEntities().ToList();

            #region Stored Procedure 3

            //using (SqlConnection connection = new SqlConnection(connectionName))
            //{
            //    Console.Write("Enter name: ");
            //    string inputName = Console.ReadLine();

            //    connection.Open();
            //    string commandText = "GetAgeRange";

            //    SqlCommand command = new SqlCommand
            //    {
            //        Connection = connection,
            //        CommandText = commandText,
            //        CommandType = CommandType.StoredProcedure
            //    };                

            //    var name = new SqlParameter("@Name", inputName);
            //    var minAge = new SqlParameter
            //    {
            //        ParameterName = "@MinAge",
            //        Direction = ParameterDirection.Output,
            //        SqlDbType = SqlDbType.Int
            //    };
            //    var maxAge = new SqlParameter
            //    {
            //        ParameterName = "MaxAge", // still works without @
            //        Direction = ParameterDirection.Output,
            //        SqlDbType = SqlDbType.Int
            //    };

            //    command.Parameters.AddRange(new[] { name, minAge, maxAge });

            //    var affctedRows = command.ExecuteNonQuery();

            //    Console.WriteLine($"Affcted Rows id: {affctedRows}");
            //    Console.WriteLine($"Patients with {inputName} minAge: {minAge.Value} maxAge: {maxAge.Value}");
            //}

            #endregion

            #region Transaction

            using (SqlConnection connection = new SqlConnection(connectionName))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                var command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    string cmdText1 = "INSERT Patient (Name, Age) VALUES ('Kleo', 24)";
                    string cmdText2 = "INSERT Doctor (Name, SpecializationID) VALUES ('Aibolit', 1)";

                    command.CommandText = cmdText1;
                    command.ExecuteNonQuery();

                    command.CommandText = cmdText2;
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }
            }

             #endregion

             Console.ReadKey();
        }

        #region Stored Procedure 2

        private static IEnumerable<dynamic> GetEntities()
        {
            string connectionName = @"Data Source=(LocalDB)\mssqllocaldb;Initial Catalog=Hospital;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionName))
            {
                connection.Open();
                string commandText = "GetPatients";

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = commandText,
                    CommandType = CommandType.StoredProcedure
                };

                var patientsReader = command.ExecuteReader();

                if (patientsReader.HasRows)
                {
                    while (patientsReader.Read())
                    {
                        var patient = new 
                        {
                            ID = patientsReader.GetInt32(0),
                            Name = patientsReader.GetString(1),
                            Age = patientsReader.GetInt32(2)
                        };

                        Console.WriteLine($"id: {patient.ID}; Name: {patient.Name}; Age: {patient.Age}");

                        yield return patient;
                    }
                }
            }
        }

        #endregion
              
    }
}
