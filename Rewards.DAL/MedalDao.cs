using Rewards.DAL.Interface;
using Rewards.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Rewards.DAL
{
    public class MedalDao : IMedalDao
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Constructor
        public MedalDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
        #endregion

        #region Methods
        public int Add(string name, string material)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateMedal";

                var Name = new SqlParameter("@name", SqlDbType.NVarChar)
                {
                    Value = name
                };
                command.Parameters.Add(Name);

                var Material = new SqlParameter("@material", SqlDbType.NVarChar)
                {
                    Value = material
                };
                command.Parameters.Add(Material);
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
                command.CommandText = "RemoveMedal";

                var Id = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Medal> GetAll()
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowAllMedals";
                connetion.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Medal()
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Material = (string)reader["material"]
                    };
                }
            }
        }

        public Medal GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReturnMedalById";

                var identificator = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = id
                };
                command.Parameters.Add(identificator);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Medal()
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Material = (string)reader["material"]
                    };
                }
            }
            return null;
        }

        public bool OccursInReward(int medalId)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FindRewardByMedalID";

                var MedalId = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = medalId
                };

                command.Parameters.Add(MedalId);
                connetion.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
            }
            return false;
        }

        public void Update(int medalId, string name, string material)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateMedal";

                var Id = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = medalId
                };
                command.Parameters.Add(Id);

                var Name = new SqlParameter("@name", SqlDbType.NVarChar)
                {
                    Value = name
                };
                command.Parameters.Add(Name);

                var Material = new SqlParameter("@material", SqlDbType.NVarChar)
                {
                    Value = material
                };
                command.Parameters.Add(Material);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
