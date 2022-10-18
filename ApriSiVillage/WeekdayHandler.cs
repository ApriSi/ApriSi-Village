using System;

namespace ApriSiVillage
{
    public static class WeekdayHandler
    {
        public delegate void NextDayAction();
        public static event NextDayAction OnNextDay;

        private static string[] _weeks = new string[]
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday gotta get down on friday",
            "Saturday",
            "Sunday"
        };

        public static int WeeksCount = 0;
        public static string Weekday = _weeks[(int)Week.Monday];

        public static void NextDay()
        {
            IncrementDay();
            TryDoomsday();
            OnNextDay.Invoke();
            Console.WriteLine($"The sun is going up and it's now {Weekday}");
        }

        private static void IncrementDay()
        {
            WeeksCount++;
            if (WeeksCount < _weeks.Length) {
                Weekday = _weeks[WeeksCount];
            } else {
                Weekday = _weeks[(int)Week.Monday];
                WeeksCount = 0;
            }
        }

        private static void TryDoomsday()
        {
            //It's monday and the world has a 20% chance of colapsing 
            if (Weekday == _weeks[(int)Week.Monday]) {
                if (RNG.Range(0, 10) >= 8)
                    Simulation.IsVillageAlive = false;
            } else {
                if (RNG.Range(0, 1000) >= 999)
                    Simulation.IsVillageAlive = false;
            }

            if(!Simulation.IsVillageAlive)
            {
                foreach (var villager in Simulation.VillagerManager.Villagers)
                    villager.SetDeath(true);
            }
        }
    }
}
