using ApriSiVillage.Entities;
using System.Collections.Generic;

namespace ApriSiVillage.Locations
{
    public abstract class Location
    {
        protected Location(string name, int maxCapacity)
        {
            Name = name;
            MaxCapacity = maxCapacity;
        }

        public string Name;
        public List<Villager> Capacity;
        public int MaxCapacity;
    }
}
