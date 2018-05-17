using System;
using Ex03.ConsoleUI.Enums;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.CustomErrors;

namespace Ex03.ConsoleUI
{
    public static class CustomConverter
    {
        public static bool ConvertStringToIsColdBool(string i_Input)
        {
            bool isCold;

            if (i_Input == "Y" || i_Input == "y")
            {
                isCold = true;
            }
            else if (i_Input == "N" || i_Input == "n")
            {
                isCold = false;
            }
            else
            {
                throw new ArgumentException("Invalid Option");
            }

            return isCold;
        }

        public static float ConvertStringToPositiveFloat(string i_Input)
        {
            float inputAsFloat;

            if (!float.TryParse(i_Input, out inputAsFloat))
            {
                throw new FormatException("Invalid input format");
            }

            if(inputAsFloat < 0)
            {
                throw new ValueOutOfRangeException(0, float.MaxValue);
            }

            return inputAsFloat;
        }

        public static int ConvertStringToPositiveInt(string i_Input)
        {
            int inputAsInt;

            if (!int.TryParse(i_Input, out inputAsInt))
            {
                throw new FormatException("Invalid input Format");
            }

            if (inputAsInt < 0)
            {
                throw new ValueOutOfRangeException(0, float.MaxValue);
            }

            return inputAsInt;
        }

        public static eVehicleTypeOptions ConvertInputToVehicleTypeOption(string i_Input)
        {
            int inputAsInteger;
            eVehicleTypeOptions vehicleTypeOption = eVehicleTypeOptions.InvalidType;

            if (!int.TryParse(i_Input, out inputAsInteger))
            {
                throw new FormatException("Invalid format input choice");
            }

            if (!Enum.IsDefined(typeof(eVehicleTypeOptions), inputAsInteger) || (eVehicleTypeOptions)inputAsInteger == eVehicleTypeOptions.InvalidType)
            {
                throw new ArgumentException("Invalid option. Option does not exist...");
            }

            vehicleTypeOption = (eVehicleTypeOptions)inputAsInteger;
            return vehicleTypeOption;
        }

        public static void ConvertToValidNumberOfDoors(string i_NumberOfDoors, out int o_NumberOfDoors)
        {
            if (!int.TryParse(i_NumberOfDoors, out o_NumberOfDoors))
            {
                throw new FormatException("Invalid Choice");
            }
            else
            {
                if (o_NumberOfDoors != 2 && o_NumberOfDoors != 3 && o_NumberOfDoors != 4 && o_NumberOfDoors != 5)
                {
                    throw new ArgumentException("Invalid number of Doors");
                }
            }
        }

        public static eVehicleColors ConvertStringColorToVehicleColor(string i_Color)
        {
            int colorOption;

            if (!int.TryParse(i_Color, out colorOption))
            {
                throw new FormatException("Invalid Option Format");
            }

            if (!Enum.IsDefined(typeof(eVehicleColors), colorOption) || (eVehicleColors)colorOption == eVehicleColors.None)
            {
                throw new ArgumentException("Invalid Color Choice");
            }
            else
            {
                return (eVehicleColors)colorOption;
            }
        }

        public static eVehicleStatuses ConvertStringToVehicleStatus(string i_Input)
        {
            int choice;

            if (!int.TryParse(i_Input, out choice))
            {
                throw new FormatException("Invalid Format");
            }

            if (!Enum.IsDefined(typeof(eVehicleStatuses), choice) || (eVehicleStatuses)choice == eVehicleStatuses.None)
            {
                throw new ArgumentException("Invalid choice. Please choose only from the statuses in the list.");
            }

            return (eVehicleStatuses)choice;
        }

        public static eVehicleStatuses ConvertStringToVehicleStatusFiltering(string i_Input)
        {
            int choice;
            eVehicleStatuses vehicleStatus;

            if (!int.TryParse(i_Input, out choice))
            {
                throw new FormatException("Invalid Format");
            }

            if(choice == 4)
            {
                vehicleStatus = eVehicleStatuses.None;
            }
            else if (!Enum.IsDefined(typeof(eVehicleStatuses), choice) || (eVehicleStatuses)choice == eVehicleStatuses.None)
            {
                throw new ArgumentException("Invalid choice. Please choose only from the statuses in the list.");
            }
            else
            {
                vehicleStatus = (eVehicleStatuses)choice; 
            }

            return vehicleStatus;
        }

        public static eLicenseTypes ConvertStringToLicenseType(string i_Input)
        {
            int choice;
            eLicenseTypes licenseType = eLicenseTypes.None;

            if (!int.TryParse(i_Input, out choice))
            {
                throw new FormatException("Invalid Input Format");
            }
            else if (!Enum.IsDefined(typeof(eLicenseTypes), choice) || (eLicenseTypes)choice == eLicenseTypes.None)
            {
                throw new ArgumentException("Invalid LicenseType choice");
            }
            else
            {
                licenseType = (eLicenseTypes)choice;
            }

            return licenseType;
        }

        public static eMainMenuOptions ConvertInputToChoice(string i_Input)
        {
            int inputAsInteger;
            eMainMenuOptions choice;

            if (!int.TryParse(i_Input, out inputAsInteger))
            {
                throw new FormatException("Invalid Input Format");
            }

            if (!Enum.IsDefined(typeof(eMainMenuOptions), inputAsInteger) || (eMainMenuOptions)inputAsInteger == eMainMenuOptions.InvalidChoice)
            {
                throw new ArgumentException("Invalid option. Option does not exist.");
            }

            choice = (eMainMenuOptions)inputAsInteger;
            return choice;
        }
    }
}
