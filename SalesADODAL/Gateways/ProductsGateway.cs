using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SalesADODAL.Interfaces;
using SalesADODAL.Models;

namespace SalesADODAL.Gateways
{
    public static class ProductsGateway
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
                command.CommandText = "Delete From [Products] Where id = @id";
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;
                command.ExecuteNonQuery();
            }
        }

        public static Product Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Select * From [Products] Where id=@id";
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;
                SqlDataReader dbReader = command.ExecuteReader();
                dbReader.Read();
                Product product = new Product();
                product.Id = (int)dbReader.GetValue(0);
                product.Name = (string)dbReader.GetValue(1);
                product.Price = (int)dbReader.GetValue(2);
                product.CategoryId = (int)dbReader.GetValue(3);
                product.ProviderId = (int)dbReader.GetValue(4);
                dbReader.Close();
                return product;
            }
        }

        public static IEnumerable<Product> GetAll()
        {
            List<Product> result = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Select * From [Products]";
                SqlDataReader dbReader = command.ExecuteReader();
                while (dbReader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)dbReader.GetValue(0);
                    product.Name = (string)dbReader.GetValue(1);
                    product.Price = (int)dbReader.GetValue(2);
                    product.CategoryId = (int)dbReader.GetValue(3);
                    product.ProviderId = (int)dbReader.GetValue(4);
                    result.Add(product);
                }
                dbReader.Close();
            }
            return result;
        }

        public static void Save(Product record)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand commandSelect = connection.CreateCommand();
                commandSelect.CommandText = "Select * From [Products] Where id=@id";
                commandSelect.Parameters.Add("@id", SqlDbType.Int);
                commandSelect.Parameters["@id"].Value = record.Id;
                SqlDataReader dbReader = commandSelect.ExecuteReader();
                Product product = new Product();
                while (dbReader.Read())
                {
                    product.Id = (int)dbReader.GetValue(0);
                    product.Name = (string)dbReader.GetValue(1);
                }
                if (product.Name == null)
                {
                    SqlCommand commandInsert = connection.CreateCommand();
                    commandInsert.CommandText = "Insert Into [Products] Values (@id, @Name, @Price, @CategoryId, @ProviderId)";
                    commandInsert.Parameters.Add("@id", SqlDbType.Int);
                    commandInsert.Parameters.Add("@Name", SqlDbType.NChar);
                    commandInsert.Parameters.Add("@Price", SqlDbType.Int);
                    commandInsert.Parameters.Add("@CategoryId", SqlDbType.Int);
                    commandInsert.Parameters.Add("@ProviderId", SqlDbType.Int);
                    commandInsert.Parameters["@id"].Value = record.Id;
                    commandInsert.Parameters["@Name"].Value = record.Name;
                    commandInsert.Parameters["@Price"].Value = record.Price;
                    commandInsert.Parameters["@CategoryId"].Value = record.CategoryId;
                    commandInsert.Parameters["@ProviderId"].Value = record.ProviderId;
                    commandInsert.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand commandUpdate = connection.CreateCommand();
                    commandUpdate.CommandText = "Update [Categories] Set (Name=@Name, Price=@Price, Category=@CategoryId, ProviderId=@ProviderId) Where id=@id";
                    commandUpdate.Parameters.Add("@id", SqlDbType.Int);
                    commandUpdate.Parameters.Add("@Name", SqlDbType.NChar);
                    commandUpdate.Parameters.Add("@Price", SqlDbType.Int);
                    commandUpdate.Parameters.Add("@CategoryId", SqlDbType.Int);
                    commandUpdate.Parameters.Add("@ProviderId", SqlDbType.Int);
                    commandUpdate.Parameters["@id"].Value = record.Id;
                    commandUpdate.Parameters["@Name"].Value = record.Name;
                    commandUpdate.Parameters["@Price"].Value = record.Price;
                    commandUpdate.Parameters["@CategoryId"].Value = record.CategoryId;
                    commandUpdate.Parameters["@ProviderId"].Value = record.ProviderId;
                    commandUpdate.ExecuteNonQuery();
                }

            }
        }
    }
}
