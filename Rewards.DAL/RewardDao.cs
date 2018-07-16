using Rewards.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Rewards.DAL
{
    public class RewardDao : IRewardDao
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Constructor
        public RewardDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
        #endregion

        #region Methods
        public void Add(int personId, int medalId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateReward";

                var PersonId = new SqlParameter("@peopleId", SqlDbType.Int)
                {
                    Value = personId
                };
                command.Parameters.Add(PersonId);

                var MedalId = new SqlParameter("@medalsId", SqlDbType.Int)
                {
                    Value = medalId
                };
                command.Parameters.Add(MedalId);

                connection.Open();
                command.ExecuteNonQuery();
                //var id = (decimal)command.ExecuteScalar();
                //return 1;
            }
        }

        public void Delete(int personId, int medalId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RemoveReward";

                var PersonId = new SqlParameter("@peopleId", SqlDbType.NVarChar)
                {
                    Value = personId
                };
                command.Parameters.Add(PersonId);

                var MedalId = new SqlParameter("@medalsId", SqlDbType.NVarChar)
                {
                    Value = medalId
                };
                command.Parameters.Add(MedalId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool IsPersonCreated(int personId)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReturnPersonById";

                var PersonId = new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = personId
                };
                command.Parameters.Add(PersonId);

                connetion.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsMedalCreated(int medalId)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReturnMedalById";

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

        public IEnumerable<string> GetAll()
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                List<string> list = new List<string>();
                var command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowAllRewards";
                connetion.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    object name = reader.GetValue(0);
                    object surname = reader.GetValue(1);
                    object material = reader.GetValue(2);
                    object nameOfMedal = reader.GetValue(3);

                    list.Add(($"{name} {surname} - {material}: {nameOfMedal}"));
                }
                return list;
            }
        }
        #endregion
    }
}
