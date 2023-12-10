using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Classes
{
    public class Role
    {
        public int Role_id {  get; set; }
        public string Role_name { get; set; }
        public Role(int role_id, string role_name) 
        {
            this.Role_id = role_id;
            this.Role_name = role_name;
        }
    }
}
