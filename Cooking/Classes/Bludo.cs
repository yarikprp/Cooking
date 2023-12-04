using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Classes
{
    public class Bludo
    {
        public int Id { get; set; }
        public string BludoName { get; set; }
        public string Categoriya { get; set; }
        public string Osnova { get; set; }
        public int Vyhod { get; set; }
        public Image Image { get; set; }
        public Bludo (int id, string bludoName, string categoriya, string osnova, int vyhod, string image)
        {
            Id = id;
            BludoName = bludoName;
            Categoriya = categoriya;
            Osnova = osnova;
            Vyhod = vyhod;
            if (image != "")
                Image = Image.FromFile(image);
            else
                Image = Image.FromFile(@"..\..\Images\picture.jpg");
        }
    }
    
}
