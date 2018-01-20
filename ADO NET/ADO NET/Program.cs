using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace ADO_NET
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionName = @"Data Source={{SERVER_NAME}};Initial Catalog={{DATABASE_NAME}};Integrated Security=True";
            //string connectionName = @"Data Source=(LocalDB)\mssqllocaldb;Initial Catalog=Hospital;Integrated Security=True";
            string connectionName = @"Data Source=IGOR\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";

            #region Stored Procedure

            using (SqlConnection connection = new SqlConnection(connectionName))
            {
                connection.Open();
                string cmdText = "InsertPatient";

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = cmdText,
                    CommandType = CommandType.StoredProcedure
                };

                Console.Write("\nEnter name: ");
                string newName = Console.ReadLine();

                Console.Write("\nEnter age: ");
                int newAge = int.Parse(Console.ReadLine());

                var name = new SqlParameter("@name", newName);
                var age = new SqlParameter("@age", newAge);

                command.Parameters.AddRange(new[] { name, age });

                var id = command.ExecuteScalar();
                //int affectedRows = command.ExecuteNonQuery();
                Console.WriteLine($"Inserted patient id: {id}");
            }

            #endregion

            // for Stored Procedure 2
            var patients = GetEntities();
            //var patients = GetEntities().ToList();
            Console.WriteLine(patients.FirstOrDefault(patient => patient.Name == "Alex"));

            #region Stored Procedure 3

            using (SqlConnection connection = new SqlConnection(connectionName))
            {
                Console.Write("Enter name: ");
                string inputName = Console.ReadLine();

                connection.Open();
                string commandText = "GetAgeRange";

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = commandText,
                    CommandType = CommandType.StoredProcedure
                };

                var name = new SqlParameter("@Name", inputName);
                var minAge = new SqlParameter
                {
                    ParameterName = "@MinAge",
                    Direction = ParameterDirection.Output,
                    SqlDbType = SqlDbType.Int
                };
                var maxAge = new SqlParameter
                {
                    ParameterName = "MaxAge", // still works without @
                    Direction = ParameterDirection.Output,
                    SqlDbType = SqlDbType.Int
                };

                command.Parameters.AddRange(new[] { name, minAge, maxAge });

                int affctedRows = command.ExecuteNonQuery();

                Console.WriteLine($"Affcted rows: {affctedRows}");
                Console.WriteLine($"Patients with {inputName} minAge: {minAge.Value} maxAge: {maxAge.Value}");
            }

            #endregion

            #region Transaction

            using (SqlConnection connection = new SqlConnection(connectionName))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
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
            string connectionName = @"Data Source=IGOR\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";

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

                SqlDataReader patientsReader = command.ExecuteReader();

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
