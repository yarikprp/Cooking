using Cooking.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cooking.Model
{
    class CategoriyaFromDB
    {
        public List<Categoriya> LoadCategoris()
        {
            List<Categoriya> categoriya = new List<Categoriya>();

            NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = "SELECT category_id, category_name FROM public.category_bluda ";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        categoriya.Add(new Categoriya((int)reader[0], reader[1].ToString()));
                    }
                }
                reader.Close();
                return categoriya;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return categoriya;
            }
            finally { connection.Close(); }
        }
    }
}
