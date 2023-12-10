using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Classes
{
    public class User
    {
        public int User_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Patronymic  { get; set; }
        public DateTime Date_of_birthday { get; set; }  
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int Role_id  { get; set; }
        public User(int user_id, string first_name, string last_name, string patronymic, DateTime date_of_birthday, string login, string password, string phone, string adress, int role_id)
        {
            this.User_id = user_id;
            this.First_name = first_name;
            this.Last_name = last_name;
            this.Patronymic = patronymic;
            this.Date_of_birthday = date_of_birthday;
            this.Login = login;
            this.Password = password;
            this.Phone = phone;
            this.Adress = adress;
            this.Role_id = role_id;
        }
    }
}

