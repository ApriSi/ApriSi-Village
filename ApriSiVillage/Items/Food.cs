using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriSiVillage.Items
{
    public class Food : Item
    {
        private string[] names = {
            "Sushi", "Bread", "Fish", "Lasagna",
            "Rice", "Noodles"
        };

        public Food(int price) : base(price)
        {
            Name = names[RNG.Range(0, names.Length)];
        }
    }
}
