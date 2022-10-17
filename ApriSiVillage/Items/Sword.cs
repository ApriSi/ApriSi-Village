using ApriSiVillage.Interface;
using Newtonsoft.Json; 


namespace ApriSiVillage.Items
{
    public class Sword : Item, IDamageable
    {
        public Sword(int price = 0) : base(price)
        {
            /*Name = sword.Name;
            Damage = RNG.Range(1, 20);
            Attribute = sword.Attribute;
            price = sword.Price;*/
        }

        public int Damage;
        public string Attribute;
    }
}
