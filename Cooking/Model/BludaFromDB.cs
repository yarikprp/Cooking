using Cooking.Classes;
using Cooking.Model;
using Microsoft.Win32.SafeHandles;
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
            string sqlExp = "SELECT bluda.bludo_id, bluda.bludo_name, bluda.category_id, bluda.osnova, bluda.vihod, bluda.bludo_image " +
                "FROM public.bluda " +
                "INNER JOIN public.category_bluda " +
                "ON category_bluda.category_id = bluda.category_id " +
                "WHERE bluda.category_id = @category_id";
            NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
            command.Parameters.AddWithValue("category_id", idCategoriya);
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
    public List<SostavBluda> SostavBludFromDB(int idBluda)
    {
        List<SostavBluda> sostavBlud = new List<SostavBluda>();

        NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
        try
        {
            connection.Open();
            string sqlExp = "SELECT products_name, ves_bluda " +
                "FROM public.sostav_blud, public.products " +
                "WHERE public.sostav_blud.products_id = public.products.products_id AND sostav_blud.bludo_id=@idBluda";
            NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
            command.Parameters.AddWithValue("@idBluda", idBluda);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) 
            { 
                while(reader.Read())
                {
                    sostavBlud.Add(new SostavBluda(idBluda, reader.GetString(0), (int)reader.GetDouble(1)));
                }
            }
            reader.Close();
            return sostavBlud;
        }
        catch (NpgsqlException ex)
        {
            MessageBox.Show(ex.Message);
            return sostavBlud;
        }
        finally
        { connection.Close(); }
    }
}
