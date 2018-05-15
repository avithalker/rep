using Ex03.GarageLogic.CustomErrors;
using Ex03.GarageLogic.Enums;
using System;

namespace Ex03.ConsoleUI
{
    public partial class ApplicationManager
    {
        private void AddFuelToVehicleOp2()
        {
            string requestedLicenseNumber;
            float fuelAmount;
            eFuelTypes fuelType;

            Console.Clear();
            getValidLicenseNumber(out requestedLicenseNumber);
            fuelAmount = getEnergyAmountToFill();
            fuelType = getFuelTypeToFill();
            Console.Clear();
            try
            {
                m_GarageManager.FuelVehicle(requestedLicenseNumber, fuelType,fuelAmount);
                Console.WriteLine("Successfuly filled fuel for vehicle with license number:{0}", requestedLicenseNumber);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(string.Format("Error has occured!{0}{1}", Environment.NewLine, e.Message));
            }
            catch (ValueOutOfRangeException e)
            {
                Console.WriteLine(string.Format("Error has occured!{0}{1}", Environment.NewLine, e.Message));
            }
        }

        private eFuelTypes getFuelTypeToFill()
        {
            eFuelTypes fuelType = eFuelTypes.None;
            int choice;
            bool isValid;
            do
            {
                try
                {
                    Console.WriteLine("Please choose the requested fuel type:");
                    printFuelTypesMenu();
                    isValid = int.TryParse(Console.ReadLine(), out choice);
                    if (!isValid)
                    {
                        throw new FormatException("Invalid choice. Input must be a number");
                    }
                    else if (!Enum.IsDefined(typeof(eFuelTypes), choice) || (eFuelTypes)choice == eFuelTypes.None)
                    {
                        throw new ArgumentException("Invalid choice. Please choose only from the type list.");
                    }
                    else
                    {
                        fuelType = (eFuelTypes)choice;
                    }
                }
                catch (FormatException e)
                {
                    isValid = false;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please try again");
                }
                catch (ArgumentException e)
                {
                    isValid = false;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please try again");
                }
            } while (!isValid);

            return fuelType;
        }

        private void printFuelTypesMenu()
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
