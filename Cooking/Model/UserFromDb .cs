using Cooking.Classes;
using Cooking.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Model
{
    public class UserFromDb
    {
        public Classes.User GetUser(string login, string password)
        {
            Classes.User user = null;
            try
            {
                using (NpgsqlConnection connect = new NpgsqlConnection(Connection.connectionStr))
                {
                    connect.Open();
                    string sqlExp = "SELECT * FROM users WHERE login=@login ";
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    cmd.Parameters.AddWithValue("login", login);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (password != "")
                        {
                            if (Verification.VerifySHA512Hash(password, (string)reader["password"]))
                            {
                                DateTime date_of_birthday = DateTime.Now;
                                if (!(reader[4] is DBNull))
                                {
                                    date_of_birthday = Convert.ToDateTime(reader[4]);
                                }
                                user = new Classes.User((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), date_of_birthday, reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), (int)reader[9]);
                            }
                            else
                            {
                                MessageBox.Show("Неверный пароль!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нет такого пользователя!");
                    }
                    return user;
                }
            }
            catch (NpgsqlException ex) 
            { MessageBox.Show(ex.Message); return user; }
        }
        public bool CheckPassword(string password, string passRepeat)
        {
            if(password.Length < 6)
            {
                MessageBox.Show("Длина пароля не может быть меньше 6 символов");
                return false;
            }
            else
            {
                bool f, f1, f2;
                f = f1 = f2 = false;
                for(int i = 0; i < password.Length; i++)
                {
                    if (Char.IsDigit(password[i])) f1 = true;
                    if (Char.IsDigit(password[i])) f2 = true;
                    if (f1 && f2) break;

                }
                if (!(f1 && f2))
                {
                    MessageBox.Show("Пароль должен содержать хотя бы одну цифру и одну заглавную букву!");
                    return f1 && f2;
                }
                else
                {
                    string simbol = "!@#$%";
                    for (int i = 0; i < password.Length; i++)
                    {
                        for (int j = 0; j < simbol.Length; j++)
                            if (password[i] == simbol[j]) { f = true; break; }
                    }
                    if (!f) MessageBox.Show("Пароль должен содержать один из симводов !@#$%");
                    if ((password == passRepeat) && f) return true; else { MessageBox.Show("Неверно подвржден пароль"); return false; }

                }
            }
        }
        public bool CheckUser(string login)
        {
            try
            {
                using(NpgsqlConnection connect = new NpgsqlConnection(Connection.connectionStr)) 
                { 
                    connect.Open();
                    string sqlExp = "SELECT login FROM public.users WHERE login=@login" ;
                    NpgsqlCommand cmd = new NpgsqlCommand(sqlExp, connect);
                    cmd.Parameters.AddWithValue("@login", login);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Такой логин уже есть"); return false;
                    }
                    else
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
            catch (NpgsqlException ex) 
            {
                MessageBox.Show(ex.Message); return false;
            }
        }
        public void UserAdd(string login, string password, string first_name, string last_name)
        {
            using (NpgsqlConnection connect = new NpgsqlConnection(Connection.connectionStr))
            {
                try
                {
                    connect.Open();
                    string sqlExp = "INSERT INTO public.users(first_name, last_name, patronymic, login, password, phone, adress, role_id) "
                        + "VALUES (@first_name, @last_name, ' ', @login, @password, ' ', ' ', default) ";
                    NpgsqlCommand cmd1 = new NpgsqlCommand(sqlExp, connect);
                    cmd1.Parameters.AddWithValue("first_name", first_name);
                    cmd1.Parameters.AddWithValue("last_name", last_name);
                    cmd1.Parameters.AddWithValue("login", login);
                    cmd1.Parameters.AddWithValue("password", Verification.GetSHA512Hash(password));
                    int i = cmd1.ExecuteNonQuery();
                    if (i == 1) { MessageBox.Show("Вы успешно зарегистрированы "); }
                    else MessageBox.Show("Ошибка записи");
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        public void UserUpdateProfil(Classes.User user)
        {
            NpgsqlConnection connect = new NpgsqlConnection(Connection.connectionStr);
            try
            {
                connect.Open();
                string sqlExp = "UPDATE public.users SET first_name=@first_name, last_name=@last_name, patronymic=@patronymic, date_of_birthday=@date_of_birthday, phone=@phone, adress=@adress WHERE user_id=@user_id ";
                NpgsqlCommand cmd1 = new NpgsqlCommand( sqlExp, connect);

                cmd1.Parameters.AddWithValue("first_name", user.first_name);
                cmd1.Parameters.AddWithValue("last_name", user.last_name);
                cmd1.Parameters.AddWithValue("patronymic", user.patronymic);
                cmd1.Parameters.AddWithValue("date_of_birthday", user.date_of_birthday);
                cmd1.Parameters.AddWithValue("phone", user.phone);
                cmd1.Parameters.AddWithValue("adress", user.adress);
                cmd1.Parameters.AddWithValue("user_id", user.user_id);

                int i = cmd1.ExecuteNonQuery();
                if(i == 1)
                {
                    MessageBox.Show("Данные обновлены");
                }
                else
                {
                    MessageBox.Show("Ошибка записи");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message); return;
            }
            connect.Close();
        }
        public void EditPassword(string password)
        {
            NpgsqlConnection connect = new NpgsqlConnection(Connection.connectionStr);
            try
            {
                {
                    connect.Open();
                    string sqlExp = "UPDATE public.users SET password=@password WHERE user_id=@user_id ";
                    NpgsqlCommand cmd1 = new NpgsqlCommand(sqlExp, connect);
                    cmd1.Parameters.AddWithValue("@password", Verification.GetSHA512Hash(password));
                    cmd1.Parameters.AddWithValue("user_id", AuthorizationForm.currentUser.user_id);

                    int i = cmd1.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("Данные обновлены");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка записи");
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message); return;
            }
            connect.Close();
        }
    }
}
