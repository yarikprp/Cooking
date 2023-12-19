using Cooking.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Model
{
    public class RecipeFromDB
    {
        public List<Recipe> LoadRecipe(int idBluda)
        {
           List<Recipe> recipe = new List<Recipe>();

            NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = "SELECT rezepty FROM public.rezepty WHERE public.rezepty.bludo_id = @bludo_id";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                command.Parameters.AddWithValue("bludo_id", idBluda);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        recipe.Add(new Recipe(idBluda, reader[0].ToString()));
                    }
                }
                reader.Close();
                return recipe;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return recipe;
            }
            finally { connection.Close(); }
        }
        public void AddRecipe(int blidoId, string recipe)
        {
            NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;

            try
            {
                cmd.CommandText = "INSERT INTO public.rezepty(bludo_id, rezepty) " +
                $"VALUES ({blidoId}, @Rezepty)";
                cmd.Parameters.AddWithValue("Rezepty", recipe);


                int i = cmd.ExecuteNonQuery();
                if (i == 1) { MessageBox.Show("Данные добавлены"); }
                transaction.Commit();
            }
            catch (NpgsqlException ex) 
            {
                MessageBox.Show(ex.Message); 
                transaction.Rollback();
            }
            connection.Close();
        }
        public void RecipEdit(int blidoId, string recipe)
        {
            NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
            connection.Open();

            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;

            try
            {
                cmd.CommandText = $"UPDATE public.rezepty SET rezepty = '{recipe}' WHERE bludo_id = {blidoId}";
                cmd.Parameters.AddWithValue("Rezepty", recipe);

                int i = cmd.ExecuteNonQuery();
                if (i == 1) { MessageBox.Show("Вы успешно отредактировали рецепт"); }
                else MessageBox.Show("Ошибка записи");

                transaction.Commit();
            }
            catch (NpgsqlException ex)
            { 
                MessageBox.Show(ex.Message); 
                transaction.Rollback(); 
            }
            connection.Close();
        }

        public void DeleteRecipe(int blidoId)
        {
            NpgsqlConnection connection = new NpgsqlConnection(Connection.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "DELETE FROM public.rezepty WHERE bludo_id = @bludo_id;";

                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("bludo_id", blidoId);

                int i = command.ExecuteNonQuery();
                if (i == 1) { MessageBox.Show("Рецепт удален!"); }
            }
            catch (NpgsqlException ex) { MessageBox.Show(ex.Message); }
            connection.Close();
        }
    }
}
