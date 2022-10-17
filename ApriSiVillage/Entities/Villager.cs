
using ApriSiVillage.Items;
using ApriSiVillage.Locations;
using System;
using System.Collections.Generic;

namespace ApriSiVillage.Entities
{

    public class Villager
    {
        private string[] _names = new string[]
        {
            "Per", "John", "Jack", "Sarah", "Rem", "Ram",
            "Karen", "Soren", "Rasmus", "Patrick", "Jakob",
            "Mads"
        };

        public Villager(int id)
        {
            Id = id;
            Name = _names[RNG.Range(0, _names.Length)];
            Age = RNG.Range(13, 85);
            Money = RNG.Range(0, 100);
            WeekdayHandler.OnNextDay += RandomAction;
            Inventory = RandomItems();
        }

        public string ActionHistory;

        public int Id;
        public string Name;
        public int Age;
        public int Money;
        public List<Item> Inventory;
        public HealthSystem HealthSystem = new();

        public Location CurrentLocation;
        private bool _isDead = false;

        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nAge: {Age}\nMoney: {Money}\nHealth: {HealthSystem.Health}\nDead: {_isDead}\n";
        }

        public void GetHistory()
        {
            Console.WriteLine(ToString());
            Console.WriteLine(ActionHistory);

            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        public void SetDeath(bool isDead)
        {
            _isDead = isDead;
        }

        public void RandomAction()
        {
            if (_isDead) return;

            var chanceToDie = RNG.Range(0, 100);
            if (chanceToDie >= 99) {
                DeathAction();
                return;
            }

            var chanceToEnterLocation = RNG.Range(0, 100);
            if (chanceToEnterLocation >= 80)
            {
                EnterLocationAction();
                return;
            }

            var chanceToTrade = RNG.Range(0, 100);
            if (chanceToTrade >= 70)
            {
                TradeAction();
                return;
            }
        }

        private void DeathAction()
        {
            _isDead = true;
        }

        private void TradeAction()
        {
            if (Inventory.Count <= 0) return;
            if (CurrentLocation is null) return;
            if (CurrentLocation.MaxCapacity <= 1) return;
            
            var villager = CurrentLocation.Capacity[RNG.Range(0, CurrentLocation.Capacity.Count)];
            if (villager == this) return;
            if (villager.Inventory.Count <= 0) return;

            Item offer = Inventory[RNG.Range(0, Inventory.Count)];
            Item recieve = villager.Inventory[RNG.Range(0, villager.Inventory.Count)];

            villager.Inventory.Remove(recieve);
            Inventory.Add(recieve);

            villager.Inventory.Add(offer);
            Inventory.Remove(offer);
            ActionHistory += $"Traded {offer.Name} with {villager.Name} ID: {villager.Id} for {recieve.Name}\n";
            villager.ActionHistory += $"Traded {recieve.Name} with {Name} ID: {Id} for {offer.Name}\n";
        }

        private void EnterLocationAction()
        {
            var locations = Simulation.LocationManager.Locations;
            var location = locations[RNG.Range(0, locations.Count)];

            if (CurrentLocation != null)
            {
                CurrentLocation.Capacity.Remove(this);
                CurrentLocation = null;
            }

            
            if (location.Capacity.Count >= location.MaxCapacity)
            {
                ActionHistory += $"Tried to enter {location.Name} [{location.GetType().Name}] but it was full\n";
                return;
            }

            CurrentLocation = location;
            location.Capacity.Add(this);
            ActionHistory += $"Entered {location.Name} [{location.GetType().Name}]\n";
        }

        private List<Item> RandomItems()
        {
            var items = new List<Item>();

            items.AddRange(CreateItem<Food>(0, 3));
            //items.AddRange(CreateItem<Sword>(0, 2));

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