
using ApriSiVillage.Items;
using ApriSiVillage.Locations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApriSiVillage.Entities
{

    public class Villager
    {
        public string[] Names = new string[]
        {
            "Per", "John", "Jack", "Sarah", "Rem", "Ram",
            "Karen", "Soren", "Rasmus", "Patrick", "Jakob",
            "Mads"
        };

        public Villager(int id)
        {
            Id = id;
            Name = Names[RNG.Range(0, Names.Length)];
            Age = RNG.Range(13, 85);
            Money = RNG.Range(0, 100);
            WeekdayHandler.OnNextDay += RandomAction;
            Inventory = RandomItems();
        }

        private string actionHistory;

        public int Id;
        public string Name;
        public int Age;
        public int Money;
        public List<Item> Inventory;
        public HealthSystem HealthSystem = new();

        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nAge: {Age}\nMoney: {Money}\nHealth: {HealthSystem.Health}\n";
        }

        public void GetHistory()
        {
            Console.WriteLine(ToString());
            Console.WriteLine(actionHistory);

            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        public void RandomAction()
        {
            var chance = RNG.Range(0, 1000);
            if(chance >= 900)
                EnterLocationAction();
        }

        private void DeathAction()
        {

        }

        private void EnterLocationAction()
        {
            var locations = Simulation.LocationManager.Locations;
            var location = locations[RNG.Range(0, locations.Count)];
            actionHistory += $"{Name} entered {location.Name} [{location.GetType().Name}]\n";
        }

        private List<Item> RandomItems()
        {
            var items = new List<Item>();

            items.AddRange(CreateItem<Food>(0, 3));
            items.AddRange(CreateItem<Sword>(0, 2));

            return items;
        }

        private List<Item> CreateItem<T>(int min, int max)
        {
            var items = new List<Item>();
            var amount = RNG.Range(min, max);
            for (int i = 0; i < amount; i++)
            {
                var item = Activator.CreateInstance(typeof(T), new object[] { RNG.Range(3, 100) });
                items.Add(item as Item);
            }
            return items;
        }
    }
}