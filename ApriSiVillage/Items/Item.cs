namespace ApriSiVillage.Items
{
    public abstract class Item
    {
        public Item(int price)
        {
            Name = "Unknown";
            Price = price;
        }

        public string Name;
        public int Price;
    }
}
