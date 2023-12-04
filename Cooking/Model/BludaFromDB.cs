using Cooking.Classes;
using Cooking.Model;
using Npgsql;

public class BludaFromDB
{
    public List<Bludo> bludos;

    public List<Bludo> LoadBludos()
    {
        bludos = new List<Bludo>(); 

        NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
        try
        {
            connection.Open();
            string sqlExp = "SELECT bludo_id, bludo_name, category_name, osnova, vihod, bludo_image "
              + "FROM public.bluda, public.category_bluda where public.category_bluda.category_id = public.bluda.category_id order by bludo_id;";
            NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    bludos.Add(new Bludo((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), (int)reader[4], reader[5].ToString()));
                }
            }
            reader.Close();
            return bludos;
        }
        catch (NpgsqlException ex)
        {
            MessageBox.Show(ex.Message);
            return bludos;
        }
        finally { connection.Close(); }
    }

    public List<Bludo> FilterBludosByCategory(int idCategoriya)
    {
        bludos = new List<Bludo>();

        NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
        try
        {
            connection.Open();
            string sqlExp = "SELECT bludo_id, bludo_name, category_name, osnova, vihod, bludo_image "
              + "FROM public.bluda, public.category_bluda where public.category_bluda.category_id = public.bluda.category_id and category_id = @categoryId";
            NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
            command.Parameters.AddWithValue("categoryId", idCategoriya);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    bludos.Add(new Bludo((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), (int)reader[4], reader[5].ToString()));
                }
            }
            return bludos;
        }
        catch (NpgsqlException ex)
        {
            MessageBox.Show(ex.Message);
            return bludos;
        }
    }

    public List<Bludo> SearchBludos(string textBox1)
    {
        List<Bludo> bludoSearch = new List<Bludo>();
            foreach (Bludo item in bludos)
            {
                if (item.BludoName.StartsWith(textBox1) || item.Osnova.StartsWith(textBox1))
                {
                    bludoSearch.Add(item);
                }
            }
        return bludoSearch;
    }
}
