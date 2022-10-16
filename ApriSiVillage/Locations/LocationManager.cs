using System;
using System.Collections.Generic;

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

        private string[] _names =
        {
            "Abeona Mons", "Akna Montes", "Aleksota Mons", "Anala Mons",
            "Api Mons", "Atai Mons", "Atira Mons", "Atsyrkhus Mons",
            "Awenhai Mons", "Bunzi Mons", "Hallgerda Mons", "Innini Mons",
            "Irnini Mons"
        };
        
        public void CreateLocations<T>(int min, int max)
        {
            var amount = RNG.Range(min, max);
            for (int i = 0; i < amount; i++)
            {
                var location = Activator.CreateInstance(typeof(T), new object[] { _names[RNG.Range(0, _names.Length)], RNG.Range(3, 12)});
                Locations.Add(location as Location);
            }
        }

        public List<Location> Locations = new();
        public int GetLocationCount() => Locations.Count;
    }
}
