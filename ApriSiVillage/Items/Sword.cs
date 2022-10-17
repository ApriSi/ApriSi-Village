using ApriSiVillage.Interface;
using System.IO;
using System;
using System.Linq;

namespace ApriSiVillage.Items
{
    public class Sword : Item, IDamageable
    {
        public Sword(int price = 0) : base(price)
        {
            var items = JsonHandler.GetJsonObject($@"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\Items\Items.json");
            var sword = items["Swords"][RNG.Range(0, items["Swords"].Count())];
            Name = sword["Name"].ToString();
            Damage = RNG.Range(1, 20);
            Attribute = sword["Attribute"].ToString();
            Price = price;
        }

        public int Damage;
        public string Attribute;
    }
}
