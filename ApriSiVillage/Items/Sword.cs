namespace ApriSiVillage.Items
{
    public class Sword : Item
    {
        private string[] _names = {
            "Fire Axe", "Excalibur", "Iron Sword"
        };

        public Sword(int price) : base(price)
        {
            Name = _names[RNG.Range(0, _names.Length)];
        }
    }
}
