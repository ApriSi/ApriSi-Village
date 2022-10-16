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

        private static int _weeksCount = 0;
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
            _weeksCount++;
            if (_weeksCount < _weeks.Length) {
                Weekday = _weeks[_weeksCount];
            } else {
                Weekday = _weeks[(int)Week.Monday];
                _weeksCount = 0;
            }
        }

        private static void TryDoomsday()
        {
            if(Weekday == _weeks[(int)Week.Monday]) {
                if (RNG.Range(0, 1000) >= 800)
                    Simulation.IsVillageAlive = false;
            } else {
                if (RNG.Range(0, 1000) >= 999)
                    Simulation.IsVillageAlive = false;
            }
        }
    }

    public enum Week
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}
