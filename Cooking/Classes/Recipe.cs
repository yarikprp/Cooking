using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Classes
{
    public class Recipe
    {
        public int Bludo_id { get; set; }
        public string Rezepty { get; set; }
        public Recipe(int bludo_id, string rezepty)
        {
            Bludo_id = bludo_id;
            Rezepty = rezepty;
        }
    }
}
