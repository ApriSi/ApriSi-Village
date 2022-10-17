namespace ApriSiVillage.Items
{
    public class Food : Item
    {
        private string[] _names = {
            "Sushi", "Bread", "Fish", "Lasagna",
            "Rice", "Noodles", "Baguette"
        };

        public Food(int price) : base(price)
        {
            Name = _names[RNG.Range(0, _names.Length)];
        }
    }
}
