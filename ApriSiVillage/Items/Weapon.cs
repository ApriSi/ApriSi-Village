using ApriSiVillage.Interface;
using System.IO;
using System;
using System.Linq;

namespace ApriSiVillage.Items
{
    public class Weapon : Item
    {
        public Weapon(int price = 0) : base(price)
        {
            var items = JsonHandler.GetJsonObject("Items/Items.json");
            var sword = items["Weapons"][RNG.Range(0, items["Weapons"].Count())];
            Name = sword["Name"].ToString();
            Damage = RNG.Range(1, 20);
            Attribute = sword["Attribute"].ToString();
            Price = price;
        }

        public int Damage;
        public string Attribute;
    }
}
