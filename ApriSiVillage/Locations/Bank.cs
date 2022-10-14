using System.Collections.Generic;

namespace ApriSiVillage.Locations
{
    public class Bank : Location
    {
        public Bank(string name, int maxCapacity) : base(name, maxCapacity) { }

        public List<BankInformation> Villagers = new();
    }
}
