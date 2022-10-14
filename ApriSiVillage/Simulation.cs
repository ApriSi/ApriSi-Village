﻿using ApriSiVillage.Entities;
using ApriSiVillage.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApriSiVillage
{
    public static class Simulation
    {
        public static bool IsVillageAlive = true;
        public static VillagerManager VillagerManager = new();
        public static LocationManager LocationManager = new();

        public static void Start()
        {
            Console.WriteLine($"There's {VillagerManager.GetVillagerCount()} Villagers\n" +
                $"and {LocationManager.GetLocationCount()} Locations in Aprisi Village\n");

            while (IsVillageAlive)
            {
                Thread.Sleep(1);
                WeekdayHandler.NextDay();
            }

            Console.WriteLine($"F all the {VillagerManager.GetVillagerCount()} Villagers (°.°）");
            FetchVillager();
        }

        private static void FetchVillager()
        {
            Console.WriteLine($"\nEnter a villager from 0-{VillagerManager.GetVillagerCount()}\n");

            var integerEntered = int.TryParse(Console.ReadLine(), out int result);
            if (!integerEntered || result > VillagerManager.GetVillagerCount())
            {
                Console.WriteLine("That was no valid integer. Please try again.");
            } else {
                VillagerManager.Villagers[result].GetHistory();         
            }
            FetchVillager();
        }
    }
}
