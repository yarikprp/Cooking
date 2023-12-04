using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Classes
{
    public class User
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string patronymic  { get; set; }
        public DateTime date_of_birthday { get; set; }  
        public string login { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string adress { get; set; }
        public int role_id  { get; set; }
        public User(int user_id, string first_name, string last_name, string patronymic, DateTime date_of_birthday, string login, string password, string phone, string adress, int role_id)
        {
            this.user_id = user_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.patronymic = patronymic;
            this.date_of_birthday = date_of_birthday;
            this.login = login;
            this.password = password;
            this.phone = phone;
            this.adress = adress;
            this.role_id = role_id;
        }
    }
}

