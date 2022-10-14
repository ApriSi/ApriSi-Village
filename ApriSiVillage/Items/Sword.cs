using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriSiVillage.Items
{
    public class Sword : Item
    {
        private string[] names = {
            "Fire Axe", "Excalibur", "Iron Sword"
        };

        public Sword(int price) : base(price)
        {
            Name = names[RNG.Range(0, names.Length)];
        }
    }
}
