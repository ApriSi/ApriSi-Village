using System;
using System.Collections.Generic;
using System.Linq;

namespace ApriSiVillage.Locations
{
    public class LocationManager
    {

        public LocationManager()
        {
            var villagerCount = Simulation.VillagerManager.GetVillagerCount();
            CreateLocations<House>(villagerCount/4, villagerCount);
            CreateLocations<Supermarket>(1, 5);
            CreateLocations<Bank>(1, 3);
        }
        
        public void CreateLocations<T>(int min, int max)
        {
            var names = JsonHandler.GetJsonObject("Names.json");
            var name = names["LocationNames"][RNG.Range(0, names["LocationNames"].Count())];

            var amount = RNG.Range(min, max);
            for (int i = 0; i < amount; i++)
            {
                var location = Activator.CreateInstance(typeof(T), new object[] { name.ToString(), RNG.Range(3, 12)});
                Locations.Add(location as Location);
            }
        }

        public List<Location> Locations = new();
        public int GetLocationCount() => Locations.Count;
    }
}
