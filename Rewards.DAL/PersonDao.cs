using Rewards.DAL.Interface;
using Rewards.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Rewards.DAL
{
    public class PersonDao : IPersonDao
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Constructor
        public PersonDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
        #endregion

        #region Methods
        public int Add(string name, string surname, DateTime dateOfBirth, int age, string city, string street, string numberOfHouse)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreatePerson";

                var Name = new SqlParameter("@name", SqlDbType.NVarChar)
                {
                    Value = name
                };
                command.Parameters.Add(Name);

                var Surname = new SqlParameter("@surname", SqlDbType.NVarChar)
                {
                    Value = surname
                };
                command.Parameters.Add(Surname);

                var DateOfBirth = new SqlParameter("@dateOfBirth", SqlDbType.DateTime)
                {
                    Value = dateOfBirth
                };
                command.Parameters.Add(DateOfBirth);

                var Age = new SqlParameter("@age", SqlDbType.Int)
                {
                    Value = age
                };
                command.Parameters.Add(Age);

                var City = new SqlParameter("@city", SqlDbType.NVarChar)
                {
                    Value = city
                };
                command.Parameters.Add(City);

                var Street = new SqlParameter("@street", SqlDbType.NVarChar)
                {
                    Value = street
                };
                command.Parameters.Add(Street);

                var NumberOfHouse = new SqlParameter("@numberOfHouse", SqlDbType.NVarChar)
                {
                    Value = numberOfHouse
                };
                command.Parameters.Add(NumberOfHouse);

                connection.Open();
                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RemovePerson";

                var Id = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Person> GetAll()
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowAllPeople";
                connetion.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Person()
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Surname = (string)reader["surname"],
                        DateOfBirth = (DateTime)reader["dateOfBirth"],
                        Age = (int)reader["age"],
                        City = (string)reader["city"],
                        Street = (string)reader["street"],
                        NumberOfHouse = (string)reader["numberOfHouse"]
                    };
                }
            }
        }

        public Person GetById(int id)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReturnPersonByID";

                var identificator = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(identificator);

                connetion.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Person()
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Surname = (string)reader["surname"],
                        DateOfBirth = (DateTime)reader["dateOfBirth"],
                        Age = (int)reader["age"],
                        City = (string)reader["city"],
                        Street = (string)reader["street"],
                        NumberOfHouse = (string)reader["numberOfHouse"]
                    };
                }
            }
            return null;
        }

        public void Update(int id, string name, string surname, DateTime dateOfBirth, int age, string city, string street, string numberOfHouse)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdatePerson";

                var Id = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(Id);

                var Name = new SqlParameter("@name", SqlDbType.NVarChar)
                {
                    Value = name
                };
                command.Parameters.Add(Name);

                var Surname = new SqlParameter("@surname", SqlDbType.NVarChar)
                {
                    Value = surname
                };
                command.Parameters.Add(Surname);

                var DateOfBirth = new SqlParameter("@dateOfBirth", SqlDbType.DateTime)
                {
                    Value = dateOfBirth
                };
                command.Parameters.Add(DateOfBirth);

                var Age = new SqlParameter("@age", SqlDbType.Int)
                {
                    Value = age
                };
                command.Parameters.Add(Age);

                var City = new SqlParameter("@city", SqlDbType.NVarChar)
                {
                    Value = city
                };
                command.Parameters.Add(City);

                var Street = new SqlParameter("@street", SqlDbType.NVarChar)
                {
                    Value = street
                };
                command.Parameters.Add(Street);

                var NumberOfHouse = new SqlParameter("@numberOfHouse", SqlDbType.NVarChar)
                {
                    Value = numberOfHouse
                };
                command.Parameters.Add(NumberOfHouse);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
