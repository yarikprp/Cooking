using Cooking.Classes;
using Cooking.Model;
using Microsoft.Win32.SafeHandles;
using Npgsql;
using System.Data.Common;
using System.Text;

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
                while (reader.Read())
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
    public void DeleteBludo(Bludo bludo)
    {
        NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
        try
        {
            connection.Open();
            string sqlQuery = "DELETE FROM public.bluda WHERE bludo_id = @bludo_id;";

            NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("bludo_id", bludo.Id);

            int i = command.ExecuteNonQuery();
            if (i == 1) { MessageBox.Show("Блюдо удалено!"); }
        }
        catch (NpgsqlException ex) { MessageBox.Show(ex.Message); }
        connection.Close();
    }
    public void AddNewBludo(Bludo newBludo, List<SostavBluda> sostavBludas, int idCategoriya, string picPath)
    {
        NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
        connection.Open();
        NpgsqlTransaction transaction = connection.BeginTransaction();
        NpgsqlCommand cmd = connection.CreateCommand();
        cmd.Transaction = transaction;

        try
        {
            cmd.CommandText = "INSERT INTO public.bluda(bludo_name, category_id, osnova, vihod, bludo_image) " +
               "VALUES (@bludo_name, @categoriya, @osnova, @vihod, @bludo_image) ";
            cmd.Parameters.AddWithValue("bludo_name", newBludo.BludoName);
            cmd.Parameters.AddWithValue("categoriya", idCategoriya);
            cmd.Parameters.AddWithValue("osnova", newBludo.Osnova);
            cmd.Parameters.AddWithValue("vihod", newBludo.Vyhod);
            cmd.Parameters.AddWithValue("bludo_image", picPath);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT MAX(bludo_id) FROM public.bluda ";

            int idBluda = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show(idBluda.ToString());

            for(int i = 0; i < sostavBludas.Count; i++) 
            {
                cmd.CommandText = $"INSERT INTO public.sostav_blud(bludo_id, products_id, ves_bluda) " +
                    $" VALUES ({idBluda}, (SELECT public.products.products_id FROM public.products WHERE products_name = '{sostavBludas[i].ProductName}'), "
                    + $"{sostavBludas[i].Weight})";
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show($"Блюдо добавлено");
            transaction.Commit();
        }
        catch(NpgsqlException ex) { MessageBox.Show(ex.Message); transaction.Rollback(); }
    }
    

}
