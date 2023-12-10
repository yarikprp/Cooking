using Cooking.Classes;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Model
{
    public class ProductFromDB
    {
        

        public List<Product> GetProducts()
        {
            List<Product> product = new List<Product>();

            NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = "SELECT products_id, products_name, belki, jiry, uglevody FROM public.products ";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)

                {
                    while (reader.Read())
                    {
                        product.Add(new Product((int)reader[0], reader[1].ToString(), (int)reader[2], (int)reader[3], (int)reader[4]));
                    }
                }
                reader.Close();
                return product;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return product;
            }
            finally { connection.Close(); }
        }
        public void AddProduct(Product product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = "INSERT INTO public.products (products_name, belki, jiry, uglevody) VALUES (@products_name, @belki, @uglevody, @jiry) ";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connection);

                cmd.Parameters.AddWithValue("products_name", product.Products_name);
                cmd.Parameters.AddWithValue("belki", product.Belki);
                cmd.Parameters.AddWithValue("uglevody", product.Jiry);
                cmd.Parameters.AddWithValue("jiry", product.Uglevody);

                int i = cmd.ExecuteNonQuery();
                if (i == 1) { MessageBox.Show("Данные добавлены"); }
            }
            catch (NpgsqlException ex) { MessageBox.Show(ex.Message); }
            connection.Close();
        }
        public void DeleteProduct(Product product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "DELETE FROM public.products where products_id = @products_id;";

                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("products_id", product.Products_id);

                int i = command.ExecuteNonQuery();
                if (i == 1) { MessageBox.Show("Продукт удален!"); }
            }
            catch (NpgsqlException ex) { MessageBox.Show(ex.Message); }
            connection.Close();
        }
    
    }
}
