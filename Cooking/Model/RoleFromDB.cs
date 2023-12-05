using Cooking.Classes;
using Cooking.Forms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Model
{
    public class RoleFromDB
    {
        public List<Role> GetRole()
        {
            List<Role> roles = new List<Role>();
            NpgsqlConnection connect = new NpgsqlConnection(Connection.connectionStr);
            try
            {
                {
                    connect.Open();
                    string sqlExp = "SELECT * FROM public.role ORDER BY role_id ";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        if(reader.HasRows)
                        {
                            roles.Add(new Role((int)reader[0], reader[1].ToString()));
                        }
                    }
                }
                return roles;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message); return roles;
            }
            finally { connect.Close(); }
        }
    }
}
