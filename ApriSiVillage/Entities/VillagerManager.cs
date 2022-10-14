using System.Collections.Generic;

namespace ApriSiVillage.Entities
{
    public class VillagerManager
    {
        public VillagerManager()
        {
            var villagerAmount = RNG.Range(12, 100);
            for (int i = 0; i < villagerAmount; i++)
            {
                Villagers.Add(new Villager(i));
            }
        }

        public List<Villager> Villagers = new();
        public int GetVillagerCount() => Villagers.Count - 1;
    }
}
