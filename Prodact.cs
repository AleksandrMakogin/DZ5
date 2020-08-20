using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_5_2_
{
    public class Prodact
    {
         public string Name { get; set; }
         public string Spetification { get; set; }
         public string Description { get; set; }
         public double Price { get; set;  }
        public Prodact() : this("", "", "", 0) { }
        public Prodact(string name, string spetification, string description, double price)
        {
            name = Name;
            spetification = Spetification;
            description = Description;
            price = Price;
        }
        public override string ToString()
        {
            return $" Товар {Name}";
        }

    }
}
