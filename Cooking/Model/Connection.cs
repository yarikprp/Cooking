using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Model
{
    internal class Connection
    {
        internal static string connectionStr =
        @"Server=localhost; Port=5432 ; DataBase=Cooking_Popov; 
        User Id=postgres; Password=1";
    }
}
