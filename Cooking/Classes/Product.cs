using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Classes
{
    public class Product
    {
        public int Products_id { get; set; }
        public string Products_name {  get; set; }
        public int Belki {  get; set; }
        public int Uglevody { get; set; }
        public int Jiry { get; set; }
        public Product(int products_id, string products_name, int belki, int uglevody, int jiry) 
        {
            this.Products_id = products_id;
            this.Products_name = products_name;
            this.Belki = belki;
            this.Uglevody = uglevody;
            this.Jiry = jiry;
        }
    }
}
