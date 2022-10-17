using System;

namespace ApriSiVillage
{
    public class RNG
    {
        private static Random _rnd = new Random();
        public static int Range(int lower, int higher) { return _rnd.Next(lower, higher); }
    }
}