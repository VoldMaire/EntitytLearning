using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesADODAL.Models;
using SalesADODAL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace SalesADODAL.Gateways
{
    public static class ProvidersGateway
    {
        private static string _connectionString
        {
            get
            {
                return Gateway.ConnectionString;
            }
        }

        public static void SetConnectionString(string connectionString)
        {
            Gateway.ConnectionString = connectionString;
        }

        public static void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Delete From [Providers] Where id = @id";
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;
                command.ExecuteNonQuery();
            }
        }

        public static Provider Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Select * From [Providers] Where id=@id";
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;
                SqlDataReader dbReader = command.ExecuteReader();
                dbReader.Read();
                Provider provider = new Provider();
                provider.Id = (int)dbReader.GetValue(0);
                provider.Name = (string)dbReader.GetValue(1);
                provider.City = (string)dbReader.GetValue(2);
                dbReader.Close();
                return provider;
            }
        }

        public static IEnumerable<Provider> GetAll()
        {
            List<Provider> result = new List<Provider>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Select * From [Providers]";
                SqlDataReader dbReader = command.ExecuteReader();
                while (dbReader.Read())
                {
                    Provider provider = new Provider();
                    provider.Id = (int)dbReader.GetValue(0);
                    provider.Name = (string)dbReader.GetValue(1);
                    result.Add(provider);
                }
                dbReader.Close();
            }
            return result;
        }

        public static void Save(Provider record)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand commandSelect = connection.CreateCommand();
                commandSelect.CommandText = "Select * From [Providers] Where id=@id";
                commandSelect.Parameters.Add("@id", SqlDbType.Int);
                commandSelect.Parameters["@id"].Value = record.Id;
                SqlDataReader dbReader = commandSelect.ExecuteReader();
                Provider provider = new Provider();
                while (dbReader.Read())
                {
                    provider.Id = (int)dbReader.GetValue(0);
                    provider.Name = (string)dbReader.GetValue(1);
                }
                if (provider.Name == null)
                {
                    SqlCommand commandInsert = connection.CreateCommand();
                    commandInsert.CommandText = "Insert Into [Products] Values (@id, @Name, @City)";
                    commandInsert.Parameters.Add("@id", SqlDbType.Int);
                    commandInsert.Parameters.Add("@Name", SqlDbType.NChar);
                    commandInsert.Parameters.Add("@City", SqlDbType.NChar);
                    commandInsert.Parameters["@id"].Value = record.Id;
                    commandInsert.Parameters["@Name"].Value = record.Name;
                    commandInsert.Parameters["@City"].Value = record.City;
                    commandInsert.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand commandUpdate = connection.CreateCommand();
                    commandUpdate.CommandText = "Update [Categories] Set (Name=@Name, Price=@Price, Category=@CategoryId, ProviderId=@ProviderId) Where id=@id";
                    commandUpdate.Parameters.Add("@id", SqlDbType.Int);
                    commandUpdate.Parameters.Add("@Name", SqlDbType.NChar);
                    commandUpdate.Parameters.Add("@City", SqlDbType.NChar);
                    commandUpdate.Parameters["@id"].Value = record.Id;
                    commandUpdate.Parameters["@Name"].Value = record.Name;
                    commandUpdate.Parameters["@City"].Value = record.City;
                    commandUpdate.ExecuteNonQuery();
                }
            }
        }
    }
}
