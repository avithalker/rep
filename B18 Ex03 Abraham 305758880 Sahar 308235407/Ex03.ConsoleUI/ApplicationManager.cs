﻿using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.ConsoleUI.Enums;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.ConcreteVehicles;
using Ex03.GarageLogic;
using Ex03.GarageLogic.CustomErrors;
using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.ConsoleUI
{
    public class ApplicationManager
    {
        private GarageManager m_GarageManager;

        public ApplicationManager()
        {
            m_GarageManager = new GarageManager();
        }

        public void Run()
        {
            eMainMenuOptions mainMenuChoice = eMainMenuOptions.InvalidChoice;
            do
            {
                MenusPrinter.PrintMainMenu();
                mainMenuChoice = getUserChoice();
                doActionUserByMainMenuChoice(mainMenuChoice);
            }
            while (mainMenuChoice != eMainMenuOptions.ExitProgram);
        }

        private eMainMenuOptions getUserChoice()
        {
            string input;
            bool parseSucceeded = false;
            eMainMenuOptions choiceValueInput = eMainMenuOptions.InvalidChoice;

            do
            {
                input = Console.ReadLine();

                try
                {
                    choiceValueInput = CustomConverter.ConvertInputToChoice(input);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(string.Format("{0} please try again", e.Message));
                }
                catch (ArgumentException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(string.Format("{0} please try again", e.Message));
                }
            }
            while (!parseSucceeded);

            return choiceValueInput;
        }

        private void doActionUserByMainMenuChoice(eMainMenuOptions i_Choice)
        {
            switch (i_Choice)
            {
                case eMainMenuOptions.EnterNewVehicle:
                    EnterNewVehicleOp();
                    break;
                case eMainMenuOptions.ShowLicenseNumbers:
                    showLicenceNumbersOp();
                    break;
                case eMainMenuOptions.ChangeVehicleState:
                    changeVehicleStateOp();
                    break;
                case eMainMenuOptions.AddAirToWheels:
                    addAirToWheelsOp();
                    break;
                case eMainMenuOptions.AddFuelToVehicle:
                    addFuelToVehicleOp();
                    break;
                case eMainMenuOptions.ChargeVehicle:
                    charageVehicleOp();
                    break;
                case eMainMenuOptions.ShowVehiclesData:
                    showVehiclesDataOp();
                    break;
            }
        }

        private void EnterNewVehicleOp()
        {
            string licenseNumber;
            OwnerInfo ownerInfo = null;
            Vehicle vehicle;

            Console.Clear();
            getValidLicenseNumber(out licenseNumber);

            if (m_GarageManager.IsVehicleExist(licenseNumber))
            {
                Console.WriteLine("This Vehicle is already exists in the garage. Changing its status to Infix");
                m_GarageManager.InsertVehicleToGarage(m_GarageManager.GetVehicleByLicenseNumber(licenseNumber), ownerInfo);
            }
            else
            {
                vehicle = getDataForCreateNewVehicle(licenseNumber);
                ownerInfo = CreateOwnerInfoFromUser();
                m_GarageManager.InsertVehicleToGarage(vehicle, ownerInfo);
                Console.Clear();
                Console.WriteLine("The vehicle was added to the garage successfully!!");
            }
        }

        private OwnerInfo CreateOwnerInfoFromUser()
        {
            string owner;
            string phoneNumber;

            getValidPhoneNumberFromUser(out phoneNumber);
            getValidOwnerName(out owner);

            return new OwnerInfo(owner, phoneNumber);
        }

        private void getValidPhoneNumberFromUser(out string o_PhoneNumber)
        {
            bool parseSucceeded = false;
            string input = string.Empty;

            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Please insert the owner's phone number: ");
                    input = Console.ReadLine();
                    CustomConverter.ConvertStringToInt(input);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
            }
            while (!parseSucceeded);

            o_PhoneNumber = input;
        }

        private void getValidOwnerName(out string o_Owner)
        {
            o_Owner = string.Empty;
            string input;
            bool parseSucceeded = false;

            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Please insert the owner's name: ");
                    input = Console.ReadLine();
                    CheckIfNameNotContainsNumbers(input);
                    o_Owner = input;
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
            }
            while (!parseSucceeded);
        }

        private void CheckIfNameNotContainsNumbers(string i_Input)
        {
            foreach (char Char in i_Input)
            {
                if (!((Char >= 'A' && Char <= 'Z') || (Char >= 'a' && Char <= 'z')))
                {
                    throw new FormatException("Invalid owner name. name has to contain letters only");
                }
            }
        }

        private Vehicle getDataForCreateNewVehicle(string i_LicenseNumber)
        {
            eVehicleTypeOptions vehicleTypeChoice;
            bool parseSucceeded = false;
            Vehicle vehicle = null;
            string input;

            Console.Clear();
            do
            {
                try
                {
                    MenusPrinter.PrintVehicleTypeOptions();
                    input = Console.ReadLine();
                    vehicleTypeChoice = CustomConverter.ConvertInputToVehicleTypeOption(input);
                    vehicle = getDataByVehicleTypeChoice(vehicleTypeChoice, i_LicenseNumber);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
            }
            while (!parseSucceeded);

            return vehicle;
        }

        private Vehicle getDataByVehicleTypeChoice(eVehicleTypeOptions i_VehicleTypeChoice, string i_LicenseNumber)
        {
            Vehicle vehicle;

            switch (i_VehicleTypeChoice)
            {
                case eVehicleTypeOptions.ElectricMotorcycle:
                    vehicle = getDataForElectricMotorcycle(i_LicenseNumber);
                    break;
                case eVehicleTypeOptions.FuelMotorcycle:
                    vehicle = getDataForFuelMotorcycle(i_LicenseNumber);
                    break;
                case eVehicleTypeOptions.ElectricCar:
                    vehicle = getDataForElectricCar(i_LicenseNumber);
                    break;
                case eVehicleTypeOptions.FuelCar:
                    vehicle = getDataForFuelCar(i_LicenseNumber);
                    break;
                case eVehicleTypeOptions.Truck:
                    vehicle = getDataForTruck(i_LicenseNumber);
                    break;
                default:
                    {
                        vehicle = null;
                        break;
                    }
            }

            return vehicle;
        }

        private Motorcycle getDataForElectricMotorcycle(string i_LicenseNumber)
        {
            string model;
            int engineVolume;
            eLicenseTypes licenseType;
            string wheelsManufacturer;
            float wheelsCurrentAirPressure;
            float currentEnergyState;
            Motorcycle ElectricMotorcycle;

            ElectricMotorcycle = getDataForCreateMotorycle(eEngineTypes.ElectricVehicle, out model, i_LicenseNumber, out engineVolume, out wheelsManufacturer, out licenseType);
            getCurrentEnergyState(ElectricMotorcycle, out currentEnergyState);
            getWheelsCurrentPressure(ElectricMotorcycle, out wheelsCurrentAirPressure);

            return ElectricMotorcycle;
        }

        private Motorcycle getDataForCreateMotorycle(eEngineTypes i_EngineType, out string o_Model, string i_LicenseNumber, out int o_EngineVolume, out string o_WheelsManufacturer, out eLicenseTypes o_LicenseType)
        {
            getModel(out o_Model);
            getValidEngineVolume(out o_EngineVolume);
            getWheelsManufacturer(out o_WheelsManufacturer);
            getLicenseType(out o_LicenseType);

            return VehicleFactory.CreateMotorCycle(i_EngineType, o_Model, i_LicenseNumber, o_EngineVolume, o_LicenseType, o_WheelsManufacturer);
        }

        private Car getDataForCreateCar(eEngineTypes i_EngineType, out string o_Model, string i_LicenseNumber, out int o_NumberOfDoors, out eVehicleColors o_Color, out string o_WheelsManufacturer)
        {
            getModel(out o_Model);
            getWheelsManufacturer(out o_WheelsManufacturer);
            getValidNumberOfDoors(out o_NumberOfDoors);
            getValidColor(out o_Color);

            return VehicleFactory.CreateCar(i_EngineType, o_Model, i_LicenseNumber, o_NumberOfDoors, o_Color, o_WheelsManufacturer);
        }

        private void getValidNumberOfDoors(out int o_NumberOfDoors)
        {
            bool parseSuceeded = false;
            string input;
            o_NumberOfDoors = 0;

            Console.Clear();
            do
            {
                Console.WriteLine("Please insert the number of doors from the following options: 2, 3, 4, 5");

                input = Console.ReadLine();
                try
                {
                    CustomConverter.ConvertToValidNumberOfDoors(input, out o_NumberOfDoors);
                    parseSuceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (!parseSuceeded);
        }

        private void getValidColor(out eVehicleColors o_Color)
        {
            bool parseSucceeded = false;
            string input;
            o_Color = eVehicleColors.None;

            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Please insert your car color from the following options:");
                    MenusPrinter.PrintColorsMenu();
                    input = Console.ReadLine();
                    o_Color = CustomConverter.ConvertStringColorToVehicleColor(input);
                    parseSucceeded = true;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (!parseSucceeded);
        }

        private void getValidEngineVolume(out int o_EngineVolume)
        {
            bool parseSucceeded = false;
            string input;

            o_EngineVolume = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Please enter your engine volume");
                input = Console.ReadLine();
                try
                {
                    o_EngineVolume = CustomConverter.ConvertStringToInt(input);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
            }
            while (!parseSucceeded);
        }

        private void getModel(out string o_Model)
        {
            Console.Clear();
            Console.WriteLine("Please insert your vehicle's model:");
            o_Model = Console.ReadLine();
        }

        private void getWheelsManufacturer(out string o_wheelsManufacturer)
        {
            string input;

            Console.Clear();
            Console.WriteLine("Please insert your wheels' manufacturer");
            input = Console.ReadLine();

            o_wheelsManufacturer = input;
        }

        private void getLicenseType(out eLicenseTypes o_LicenseType)
        {
            string input;
            bool parseSucceeded = false;
            o_LicenseType = eLicenseTypes.None;

            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Please insert your license type by typing one of the following options:");
                    MenusPrinter.PrintLicenseTypesMenu();
                    input = Console.ReadLine();
                    o_LicenseType = CustomConverter.ConvertStringToLicenseType(input);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
            }
            while (!parseSucceeded);
        }

        private void getValidLicenseNumber(out string o_LicenseNumber)
        {
            string input;
            int licensenNumberAsInt;
            bool parseSucceeded = false;

            o_LicenseNumber = string.Empty;
            Console.Clear();
            do
            {
                Console.WriteLine("Please enter your License Number");
                input = Console.ReadLine();

                try
                {
                    licensenNumberAsInt = CustomConverter.ConvertStringToInt(input);
                    parseSucceeded = true;
                    o_LicenseNumber = input;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
            }
            while (!parseSucceeded);
        }

        private Motorcycle getDataForFuelMotorcycle(string i_LicenseNumber)
        {
            string model;
            int engineVolume;
            float currentEnergyState;
            float wheelsCurrentAirPressure;
            eLicenseTypes licenseType;
            string wheelsManufacturer;
            Motorcycle FuelMotorcycle;

            FuelMotorcycle = getDataForCreateMotorycle(eEngineTypes.FuelVehicle, out model, i_LicenseNumber, out engineVolume, out wheelsManufacturer, out licenseType);
            getCurrentEnergyState(FuelMotorcycle, out currentEnergyState);
            getWheelsCurrentPressure(FuelMotorcycle, out wheelsCurrentAirPressure);
            return FuelMotorcycle;
        }

        private Car getDataForElectricCar(string i_LicenseNumber)
        {
            string model;
            string wheelsManufacturer;
            int numberOfDoors;
            float currentEnergyState;
            float wheelsCurrentAirPressure;
            eVehicleColors color;
            Car electricCar;

            electricCar = getDataForCreateCar(eEngineTypes.ElectricVehicle, out model, i_LicenseNumber, out numberOfDoors, out color, out wheelsManufacturer);
            getCurrentEnergyState(electricCar, out currentEnergyState);
            getWheelsCurrentPressure(electricCar, out wheelsCurrentAirPressure);

            return electricCar;
        }

        private Car getDataForFuelCar(string i_LicenseNumber)
        {
            string model;
            string wheelsManufacturer;
            int numberOfDoors;
            float currentEnergyState;
            float wheelsCurrentAirPressure;
            eVehicleColors color;
            Car fuelCar;

            fuelCar = getDataForCreateCar(eEngineTypes.FuelVehicle, out model, i_LicenseNumber, out numberOfDoors, out color, out wheelsManufacturer);
            getCurrentEnergyState(fuelCar, out currentEnergyState);
            getWheelsCurrentPressure(fuelCar, out wheelsCurrentAirPressure);

            return fuelCar;
        }

        private Truck getDataForTruck(string i_LicenseNumber)
        {
            string model;
            string wheelsManufacturer;
            bool isTrunkCold;
            float currentEnergyState;
            float wheelsCurrentAirPressure;
            Truck truck;

            truck = getDataForCreateTruck(out model, i_LicenseNumber, out isTrunkCold, out wheelsManufacturer);
            getCurrentEnergyState(truck, out currentEnergyState);
            getWheelsCurrentPressure(truck, out wheelsCurrentAirPressure);

            return truck;
        }

        private Truck getDataForCreateTruck(out string o_Model, string i_LicenseNumber, out bool o_IsTrunkCold, out string o_WheelsManufacturer)
        {
            getModel(out o_Model);
            getWheelsManufacturer(out o_WheelsManufacturer);
            getIsTruckCold(out o_IsTrunkCold);

            return VehicleFactory.CreateTruck(o_Model, i_LicenseNumber, o_IsTrunkCold, o_WheelsManufacturer);
        }

        private void getIsTruckCold(out bool o_IsTruckCold)
        {
            string input;
            bool parseSucceeded = false;

            o_IsTruckCold = false;

            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Is Your Truck cold? type Y/N :");
                    input = Console.ReadLine();
                    o_IsTruckCold = CustomConverter.ConvertStringToIsColdBool(input);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(e.Message);
                }
                catch(ArgumentException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(e.Message);
                }
            }
            while (!parseSucceeded);
        }

        private void getWheelsCurrentPressure(Vehicle i_Vehicle, out float o_CurrentPressure)
        {
            string input;
            bool parseSucceeded = false;
            o_CurrentPressure = 0;

            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Please enter your current wheels' air pressure: ");
                    input = Console.ReadLine();
                    o_CurrentPressure = CustomConverter.ConvertStringToFloat(input);
                    i_Vehicle.SetCurrentWheelsAir(o_CurrentPressure);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (!parseSucceeded);
        }

        private void getCurrentEnergyState(Vehicle i_Vehicle, out float o_CurrentState)
        {
            string input;
            bool parseSucceeded = true;
            o_CurrentState = 0;

            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Please enter your current energy amount: ");
                    input = Console.ReadLine();
                    o_CurrentState = CustomConverter.ConvertStringToFloat(input);
                    i_Vehicle.SetCurrentEnergyAmount(o_CurrentState);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(e.Message);
                }
                catch (ValueOutOfRangeException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(e.Message);
                }
            }
            while (!parseSucceeded);
        }

        private void showLicenceNumbersOp()
        {
            string input;
            eVehicleStatuses choice;
            bool parseSucceeded;

            Console.Clear();
            do
            {
                try
                {
                    parseSucceeded = true;
                    Console.WriteLine("Please choose which license numbers you would like to see according to the following filters:");
                    MenusPrinter.PrintStatusFilterMenu();
                    input = Console.ReadLine();
                    choice = CustomConverter.ConvertStringToVehicleStatusFiltering(input);
                    printLicenseNumbersByVehiclesState(choice);
                }
                catch (FormatException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(e.Message);
                }
            }
            while (!parseSucceeded);
        }

        private void printLicenseNumbersByVehiclesState(eVehicleStatuses i_VehicleStatus)
        {
            List<string> licenseNumbers;

            if (i_VehicleStatus == eVehicleStatuses.None)
            {
                licenseNumbers = m_GarageManager.GetAllLisencesInGarage();
            }
            else
            {
                licenseNumbers = m_GarageManager.GetLisenceByVehicleStatus(i_VehicleStatus);
            }

            Console.Clear();
            if (licenseNumbers.Count == 0)
            {
                Console.WriteLine("There are no vehicles in this status");
            }
            else
            {
                Console.WriteLine("The license numbers are:");
                foreach (string licenseNumber in licenseNumbers)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        }

        private void changeVehicleStateOp()
        {
            string requestedLicenseNumber;
            string input;
            eVehicleStatuses status;

            getValidLicenseNumber(out requestedLicenseNumber);
            Console.Clear();
            try
            {
                Console.WriteLine("Please choose the status you would like to set:");
                MenusPrinter.PrintVehicleStatuses();
                input = Console.ReadLine();
                status = CustomConverter.ConvertStringToVehicleStatus(input);
                m_GarageManager.ChangeVehicleStatus(requestedLicenseNumber, status);
                Console.WriteLine("Successfuly changed status for vehicle with license number:{0}", requestedLicenseNumber);
            }
            catch (FormatException e)
            {
                Console.WriteLine(string.Format("Error has occured!{0}{1}", Environment.NewLine, e.Message));
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

        private void addAirToWheelsOp()
        {
            string requestedLicenseNumber;

            getValidLicenseNumber(out requestedLicenseNumber);
            Console.Clear();
            try
            {
                m_GarageManager.InflateWheels(requestedLicenseNumber);
                Console.WriteLine("Successfuly inflated the wheels of vehicle with license number:{0}", requestedLicenseNumber);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(string.Format("Error has occured!{0}{1}", Environment.NewLine, e.Message));
            }
        }

        private void addFuelToVehicleOp()
        {
            string requestedLicenseNumber;
            float fuelAmount;
            eFuelTypes fuelType;

            getValidLicenseNumber(out requestedLicenseNumber);
            fuelAmount = getEnergyAmountToFill();
            fuelType = getFuelTypeToFill();
            Console.Clear();
            try
            {
                m_GarageManager.FuelVehicle(requestedLicenseNumber, fuelType, fuelAmount);
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

        private void charageVehicleOp()
        {
            string requestedLicenseNumber;
            float timeToCharge;

            getValidLicenseNumber(out requestedLicenseNumber);
            timeToCharge = getEnergyAmountToFill();
            Console.Clear();
            try
            {
                m_GarageManager.ChargeVehicle(requestedLicenseNumber, timeToCharge);
                Console.WriteLine("Successfuly charged vehicle with license number:{0}", requestedLicenseNumber);
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

        private void showVehiclesDataOp()
        {
            string requestedLicenseNumber;

            getValidLicenseNumber(out requestedLicenseNumber);
            Console.Clear();
            try
            {
                Console.WriteLine(m_GarageManager.GetVehicleInformationForm(requestedLicenseNumber));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(string.Format("Error has occured!{0}{1}", Environment.NewLine, e.Message));
            }
        }

        private float getEnergyAmountToFill()
        {
            float energyToAdd = 0;
            bool isValid;

            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Please enter the amount of energy to add:");
                    isValid = float.TryParse(Console.ReadLine(), out energyToAdd);
                    if (!isValid)
                    {
                        throw new FormatException("Invalid energy value. Input must be a number");
                    }
                }
                catch (FormatException e)
                {
                    isValid = false;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please try again");
                }
            }
            while (!isValid);

            return energyToAdd;
        }

        private eFuelTypes getFuelTypeToFill()
        {
            eFuelTypes fuelType = eFuelTypes.None;
            int choice;
            bool isValid;

            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Please choose the requested fuel type:");
                    MenusPrinter.PrintFuelTypesMenu();
                    isValid = int.TryParse(Console.ReadLine(), out choice);
                    if (!isValid)
                    {
                        throw new FormatException("Invalid choice. Input must be a number");
                    }
                    else if (!Enum.IsDefined(typeof(eFuelTypes), choice) || (eFuelTypes)choice == eFuelTypes.None)
                    {
                        throw new ArgumentException("Invalid choice. Please choose only from the types in the list.");
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
            }
            while (!isValid);

            return fuelType;
        }
    }
}
