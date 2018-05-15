using System;
using Ex03.GarageLogic.Enums;

namespace Ex03.ConsoleUI
{
    public static class MenusPrinter
    {
        public static void PrintMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome To The Garage Manager App!!");
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("1.Enter new vehicle to the garage");
            Console.WriteLine("2.Show vehicle license numbers");
            Console.WriteLine("3.Change vehicle's state");
            Console.WriteLine("4.Add air to the vehicle's wheels up to maximum ");
            Console.WriteLine("5.Refuel Gas Vehicle");
            Console.WriteLine("6.Charge electric vehicle");
            Console.WriteLine("7.Show vehicle's full data");
            Console.WriteLine("8.Exit");
        }

        public static void PrintFuelTypesMenu()
        {
            foreach (eFuelTypes fuelType in Enum.GetValues(typeof(eFuelTypes)))
            {
                if (fuelType != eFuelTypes.None)
                {
                    Console.WriteLine(string.Format("{0}. {1}", (int)fuelType, fuelType));
                }
            }
        }

        public static void PrintColorsMenu()
        {
            foreach (eVehicleColors color in Enum.GetValues(typeof(eVehicleColors)))
            {
                if (color != eVehicleColors.None)
                {
                    Console.WriteLine(string.Format("{0}. {1}", (int)color, color));
                }
            }
        }

        public static void PrintLicenseTypesMenu()
        {
            foreach (eLicenseTypes licenseType in Enum.GetValues(typeof(eLicenseTypes)))
            {
                if (licenseType != eLicenseTypes.None)
                {
                    Console.WriteLine(string.Format("{0}. {1}", (int)licenseType, licenseType));
                }
            }
        }

        public static void PrintVehicleTypeOptions()
        {
            Console.WriteLine("Please choose from the following Vehicle type options:");
            Console.WriteLine("1.Electric Motorcycle");
            Console.WriteLine("2.Motorcycle Energised by fuel");
            Console.WriteLine("3.Electric Car");
            Console.WriteLine("4.Car energised by fuel");
            Console.WriteLine("5.Truck");
        }

        public static void PrintStatusFilterMenu()
        {
            Console.WriteLine("1.In fix vehicles");
            Console.WriteLine("2.Fixed vehicles");
            Console.WriteLine("3.Paid vehicles");
            Console.WriteLine("4.All vehicles");
        }

        public static void PrintVehicleStatuses()
        {
            foreach (eVehicleStatuses vehicleStatus in Enum.GetValues(typeof(eVehicleStatuses)))
            {
                if (vehicleStatus != eVehicleStatuses.None)
                {
                    Console.WriteLine(string.Format("{0}. {1}", (int)vehicleStatus, vehicleStatus));
                }
            }
        }
    }
}
