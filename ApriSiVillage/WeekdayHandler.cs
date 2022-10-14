using System;
using System.Collections.Generic;

namespace ApriSiVillage
{
    public static class WeekdayHandler
    {
        public delegate void NextDayAction();
        public static event NextDayAction OnNextDay;

        public static string[] Weeks = new string[]
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday gotta get down on friday",
            "Saturday",
            "Sunday"
        };

        private static int weeksCount = 0;
        private static string weekday = Weeks[0];

        public static void NextDay()
        {
            IncrementDay();
            TryDoomsday();
            OnNextDay.Invoke();
            Console.WriteLine($"The sun is going up and it's now {weekday}");
        }

        private static void IncrementDay()
        {
            weeksCount++;
            if (weeksCount < Weeks.Length) {
                weekday = Weeks[weeksCount];
            } else {
                weekday = Weeks[0];
                weeksCount = 0;
            }
        }

        private static void TryDoomsday()
        {
            if(weekday == Weeks[0]) {
                if (RNG.Range(0, 1000) >= 800)
                    Simulation.IsVillageAlive = false;
            } else {
                if (RNG.Range(0, 1000) >= 999)
                    Simulation.IsVillageAlive = false;
            }
        }
    }
}
