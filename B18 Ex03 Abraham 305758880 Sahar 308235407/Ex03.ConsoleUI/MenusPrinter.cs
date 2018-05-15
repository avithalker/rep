using Ex03.GarageLogic.Enums;
using System;

namespace Ex03.ConsoleUI
{
    public static class MenusPrinter
    {
        public static void printFuelTypesMenu()
        {
            foreach (eFuelTypes fuelType in Enum.GetValues(typeof(eFuelTypes)))
            {
                if (fuelType != eFuelTypes.None)
                {
                    Console.WriteLine(string.Format("{0}. {1}", (int)fuelType, fuelType));
                }
            }
        }
    }
}
