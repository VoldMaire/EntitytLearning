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
    public static class CategoriesGateway
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
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Delete From [Categories] Where id = @id";
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;
                command.ExecuteNonQuery();
            }
        }

        public static Category Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Select * From [Categories] Where id=@id";
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;
                SqlDataReader dbReader = command.ExecuteReader();
                dbReader.Read();
                Category category = new Category();
                category.Id = (int)dbReader.GetValue(0);
                category.Name = (string)dbReader.GetValue(1);
                dbReader.Close();
                return category;
            }
        }

        public static IEnumerable<Category> GetAll()
        {
            List<Category> result = new List<Category>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Select * From [Categories]";
                SqlDataReader dbReader = command.ExecuteReader();
                while (dbReader.Read())
                {
                    Category category = new Category();
                    category.Id = (int)dbReader.GetValue(0);
                    category.Name = (string)dbReader.GetValue(1);
                    result.Add(category);
                }
                dbReader.Close();
            }
            return result;
        }

        public static void Save(Category record)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand commandSelect = connection.CreateCommand();
                commandSelect.CommandText = "Select * From [Categories] Where id=@id";
                commandSelect.Parameters.Add("@id", SqlDbType.Int);
                commandSelect.Parameters["@id"].Value = record.Id;
                SqlDataReader dbReader = commandSelect.ExecuteReader();
                Category category = new Category();
                while (dbReader.Read())
                {
                    category.Id = (int)dbReader.GetValue(0);
                    category.Name = (string)dbReader.GetValue(1);
                }
                if (category.Name == null)
                {
                    SqlCommand commandInsert = connection.CreateCommand();
                    commandInsert.CommandText = "Insert Into [Categories] Values (@id, @Name)";
                    commandInsert.Parameters.Add("@id", SqlDbType.Int);
                    commandInsert.Parameters.Add("@Name", SqlDbType.NChar);
                    commandInsert.Parameters["@id"].Value = record.Id;
                    commandInsert.Parameters["@Name"].Value = record.Name;
                    commandInsert.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand commandUpdate = connection.CreateCommand();
                    commandUpdate.CommandText = "Update [Categories] Set Name=@Name Where id=@id";
                    commandUpdate.Parameters.Add("@id", SqlDbType.Int);
                    commandUpdate.Parameters.Add("@Name", SqlDbType.NChar);
                    commandUpdate.Parameters["@id"].Value = record.Id;
                    commandUpdate.Parameters["@Name"].Value = record.Name;
                    commandUpdate.ExecuteNonQuery();
                }

            }
        }
    }
}
