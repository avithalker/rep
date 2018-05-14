﻿using System;
using Ex03.GarageLogic.Garage;
using Ex03.ConsoleUI.Enums;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.ConcreteVehicles;
using Ex03.GarageLogic;
namespace Ex03.ConsoleUI
{
    public class ApplicationManager
    {
        private GarageManager m_GarageManager;


        public ApplicationManager()
        {
            m_GarageManager = new GarageManager();
        }


        public void PrintMainMenu()
        {
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

        public void Run()
        {
            eMainMenuOptions mainMenuChoice = eMainMenuOptions.InvalidChoice;

            do
            {
                PrintMainMenu();
                mainMenuChoice = getUserChoice();
                doActionUserByMainMenuChoice(mainMenuChoice);

            } while (mainMenuChoice != eMainMenuOptions.ExitProgram);
        }

        private eMainMenuOptions getUserChoice()
        {
            string input;
            bool parseSucceeded = false;
            eMainMenuOptions choiceValueInput = eMainMenuOptions.InvalidChoice; //had to initialize for "Unassigned return value..." error

            do
            {
                input = Console.ReadLine();

                try
                {
                    choiceValueInput = convertInputToChoice(input);
                    parseSucceeded = true;
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
            } while (!parseSucceeded);

            return choiceValueInput;
        }

        private eMainMenuOptions convertInputToChoice(string i_Input)
        {
            int inputAsInteger;
            eMainMenuOptions choice;

            if (!int.TryParse(i_Input, out inputAsInteger))
            {

                throw new FormatException("Invalid Input Format");
            }

            else
            {

                switch (inputAsInteger)
                {
                    case 1: choice = eMainMenuOptions.EnterNewVehicle;
                        break;
                    case 2: choice = eMainMenuOptions.ShowLicenseNumbers;
                        break;
                    case 3: choice = eMainMenuOptions.ChangeVehicleState;
                        break;
                    case 4: choice = eMainMenuOptions.AddAirToWheels;
                        break;
                    case 5: choice = eMainMenuOptions.AddFuelToVehicle;
                        break;
                    case 6: choice = eMainMenuOptions.ChargeVehicle;
                        break;
                    case 7: choice = eMainMenuOptions.ShowVehiclesData;
                        break;
                    case 8: choice = eMainMenuOptions.ExitProgram;
                        break;
                    default: throw new ArgumentException("Invalid option. Option does not exist...");

                }

            }

            return choice;
        }

        private void doActionUserByMainMenuChoice(eMainMenuOptions i_Choice)
        {
            switch (i_Choice)
            {
                case eMainMenuOptions.EnterNewVehicle: EnterNewVehicleOp();
                    break;
                case eMainMenuOptions.ShowLicenseNumbers: ShowLicenceNumbersOp();
                    break;
                case eMainMenuOptions.ChangeVehicleState: ChangeVehicleStateOp();
                    break;
                case eMainMenuOptions.AddAirToWheels: AddAirToWheelsOp();
                    break;
                case eMainMenuOptions.AddFuelToVehicle: AddFuelToVehicleOp();
                    break;
                case eMainMenuOptions.ChargeVehicle: CharageVehicleOp();
                    break;
                case eMainMenuOptions.ShowVehiclesData: ShowVehiclesDataOp();
                    break;
            }
        }

        private void EnterNewVehicleOp()
        {
            string licenseNumber;
            OwnerInfo ownerInfo = null;
            GarageLogic.VehicleBasics.Vehicle vehicle;

            getValidLicenseNumber(out licenseNumber);

            if (m_GarageManager.IsVehicleExist(licenseNumber))
            {
                Console.WriteLine("This Vehicle is already exists in the garage...");
                m_GarageManager.ChangeVehicleStatus(licenseNumber, eVehicleStatuses.InFix);
            }
            else
            {
                vehicle = getDataForCreateNewVehicle(licenseNumber);
                m_GarageManager.InsertVehicleToGarage(vehicle, ownerInfo); 
            }

        }

        private GarageLogic.VehicleBasics.Vehicle getDataForCreateNewVehicle(string i_LicenseNumber)
        {
            eVehicleTypeOptions vehicleTypeChoice;
            bool parseSucceeded = false;
            GarageLogic.VehicleBasics.Vehicle vehicle = null;

            string input;
            do
            {
                try
                {
                    printVehicleTypeOptions();
                    input = Console.ReadLine();
                    vehicleTypeChoice = convertInputToVehicleTypeOption(input);
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
                }
            } while (!parseSucceeded);

            return vehicle;
        }

        private GarageLogic.VehicleBasics.Vehicle getDataByVehicleTypeChoice(eVehicleTypeOptions i_VehicleTypeChoice, string i_LicenseNumber)
        {
            GarageLogic.VehicleBasics.Vehicle vehicle;

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
                    }
                    break;
            }

            return vehicle;

        }

        private Motorcycle getDataForElectricMotorcycle(string i_LicenseNumber)
        {
            string model;
            int engineVolume;  //define in factory as int but neet float ? 
            LicenseTypes licenseType;
            string wheelsManufacturer;
            int wheelsCurrentAirPressure;
            float currentEnergyState;
            OwnerInfo ownerInfo;
            Motorcycle ElectricMotorcycle;
            

            ElectricMotorcycle = getDataForCreateMotorycle(eEngineTypes.ElectricVehicle, out model, i_LicenseNumber, out engineVolume, out wheelsManufacturer, out licenseType);
            getCurrentEngineState(ElectricMotorcycle, out currentEnergyState);
            getWheelsCurrentPressure(ElectricMotorcycle, out wheelsCurrentAirPressure);

            return ElectricMotorcycle;
        }

        private void getAirPressureAndEnergyState(out int o_WheelsCurrentAirPressure, out int o_CurrentEnergyState)
        {
            getSpecialIntDataFromUser("Please insert your wheels' current air pressure: ", out o_WheelsCurrentAirPressure);
            getSpecialIntDataFromUser("Please insert your current energy state: ", out o_CurrentEnergyState);
        }

        private Motorcycle getDataForCreateMotorycle(eEngineTypes i_EngineType, out string o_Model, string i_LicenseNumber, out int o_EngineVolume, out string o_WheelsManufacturer, out LicenseTypes o_LicenseType)
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

            do
            {
                Console.WriteLine("Please insert the number of doors from the following options: 2, 3, 4, 5");

                input = Console.ReadLine();
                try
                {
                    CheckNumberOfDoorsValidation(input);
                    parseSuceeded = true;
                }
                catch (FormatException e)
                {
                    System.Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    System.Console.WriteLine(e.Message);
                }
            } while (!parseSuceeded);
        }

        private void CheckNumberOfDoorsValidation(string i_NumberOfDoors)
        {
            int numberOfDoors;

            if (!(int.TryParse(i_NumberOfDoors, out numberOfDoors)))
            {
                throw new FormatException("Invalid Choice");
            }
            else
            {
                if (numberOfDoors != 2 && numberOfDoors != 3 && numberOfDoors != 4 && numberOfDoors != 5)
                {
                    throw new ArgumentException("Invalid number of Doors");
                }
            }
        }

        private void getValidColor(out eVehicleColors o_Color)
        {
            bool parseSucceeded = false;
            string input;
            o_Color = eVehicleColors.None;

            do
            {
                try
                {
                    System.Console.WriteLine("Please insert your car color from the following options:");
                    System.Console.WriteLine("1.Gray");
                    System.Console.WriteLine("2.Blue");
                    System.Console.WriteLine("3.White");
                    System.Console.WriteLine("4.Black");

                    input = System.Console.ReadLine();
                    o_Color = ConvertStringColorToVehicleColor(input);
                    parseSucceeded = true;
                }
                catch (ArgumentException e)
                {
                    System.Console.WriteLine(e.Message);
                }
            } while (!parseSucceeded);
        }

        private eVehicleColors ConvertStringColorToVehicleColor(string i_Color)
        {
            int colorOption;

            if (!int.TryParse(i_Color, out colorOption))
            {
                throw new FormatException("Invalid Option Format");
            }

            if (Enum.IsDefined(typeof(eVehicleColors), colorOption))
            {
                throw new ArgumentException("Invalid Color Choice");
            }

            else
            {
                return (eVehicleColors)colorOption;
            }

        }


        private void getValidEngineVolume(out int o_EngineVolume)
        {
            bool parseSucceeded = false;
            o_EngineVolume = 0;

            string input;

            do
            {
                Console.WriteLine("Please enter your engine volume");
                input = Console.ReadLine();
                try
                {
                    getIntegerStringInputToInt(input, out o_EngineVolume);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
            } while (!parseSucceeded);

        }

        private void getModel(out string o_Model)
        {
            Console.WriteLine("Please insert your vehicle's model:");
            o_Model = Console.ReadLine();
        }

        private void getWheelsManufacturer(out string o_wheelsManufacturer)
        {
            string input;

            Console.WriteLine("Please insert your wheels' manufacturer");
            input = Console.ReadLine();

            o_wheelsManufacturer = input;
        }

        private void getLicenseType(out LicenseTypes o_LicenseType)
        {
            string input;
            bool parseSucceeded = false;
            o_LicenseType = LicenseTypes.None;

            do
            {
                try
                {
                    Console.WriteLine("Please insert your license type by typing one of the following options:");
                    Console.WriteLine("1.A");
                    Console.WriteLine("2.A1");
                    Console.WriteLine("3.B1");
                    Console.WriteLine("4.B2");
                    input = Console.ReadLine();
                    o_LicenseType = convertStringToLicenseType(input);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }

            } while (!parseSucceeded);

        }

        private LicenseTypes convertStringToLicenseType(string i_Input)
        {
            int choice;
            LicenseTypes licenseType = LicenseTypes.None;

            if (!int.TryParse(i_Input, out choice))
            {
                throw new FormatException("Invalid Input Format");
            }
            else if (!Enum.IsDefined(typeof(LicenseTypes), i_Input))
            {
                throw new ArgumentException("Invalid LicenseType choice");
            }
            else
            {
                licenseType = (LicenseTypes)choice;
            }

            return licenseType;
        }

        private void getValidLicenseNumber(out string o_LicenseNumber)
        {
            string input;
            int LicensenUmberAsInt;
            o_LicenseNumber = "";

            bool parseSucceeded = false;
            do
            {
                Console.WriteLine("Please enter your License Number");
                input = Console.ReadLine();

                try
                {
                    getIntegerStringInputToInt(input, out LicensenUmberAsInt);
                    parseSucceeded = true;
                    o_LicenseNumber = input;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }

            } while (!parseSucceeded);
        }

        private void getIntegerStringInputToInt(string i_Input, out int o_InputAsInt)
        {

            if (!int.TryParse(i_Input, out o_InputAsInt))
            {
                throw new FormatException("Invalid Input - input not contains numbers only");
            }

        }

        private Motorcycle getDataForFuelMotorcycle(string i_LicenseNumber)
        {
            string model;
            int engineVolume;  //define in factory as int but neet float ? 
            float currentEnergyState;
            int wheelsCurrentAirPressure;
            LicenseTypes licenseType;
            string wheelsManufacturer;
            Motorcycle FuelMotorcycle;


            FuelMotorcycle = getDataForCreateMotorycle(eEngineTypes.FuelVehicle, out model, i_LicenseNumber, out engineVolume, out wheelsManufacturer, out licenseType);
            getCurrentEngineState(FuelMotorcycle, out currentEnergyState);
            getWheelsCurrentPressure(FuelMotorcycle, out wheelsCurrentAirPressure);

            return FuelMotorcycle;
        }

        private Car getDataForElectricCar(string i_LicenseNumber)
        {
            string model;
            string wheelsManufacturer;
            int numberOfDoors;
            float currentEnergyState;
            int wheelsCurrentAirPressure;
            eVehicleColors color;
            Car electricCar;

            electricCar = getDataForCreateCar(eEngineTypes.ElectricVehicle, out model, i_LicenseNumber, out numberOfDoors, out color, out wheelsManufacturer);
            getCurrentEngineState(electricCar, out currentEnergyState);
            getWheelsCurrentPressure(electricCar, out wheelsCurrentAirPressure);

            return electricCar;
        }

        private Car getDataForFuelCar(string i_LicenseNumber)
        {
            string model;
            string wheelsManufacturer;
            int numberOfDoors;
            float currentEnergyState;
            int wheelsCurrentAirPressure;
            eVehicleColors color;
            Car fuelCar;

            fuelCar = getDataForCreateCar(eEngineTypes.FuelVehicle, out model, i_LicenseNumber, out numberOfDoors, out color, out wheelsManufacturer);
            getCurrentEngineState(fuelCar, out currentEnergyState);
            getWheelsCurrentPressure(fuelCar, out wheelsCurrentAirPressure);

            return fuelCar;
        }

        private Truck getDataForTruck(string i_LicenseNumber)
        {
            string model;
            string wheelsManufacturer;
            bool isTrunkCold;
            float currentEnergyState;
            int wheelsCurrentAirPressure;
            Truck truck;

            truck = getDataForCreateTruck(out model, i_LicenseNumber, out isTrunkCold, out wheelsManufacturer);
            getCurrentEngineState(truck, out currentEnergyState);
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

            do
            {
                try
                {
                    Console.WriteLine("Is Your Truck cold? type Y/N :");
                    input = Console.ReadLine();
                    o_IsTruckCold = ConvertStringToIsColdBool(input);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!parseSucceeded);

        }

        private void getWheelsCurrentPressure(GarageLogic.VehicleBasics.Vehicle i_Vehicle, out int o_CurrentPressure)
        {
            string input;
            bool parseSucceeded = false;
            o_CurrentPressure = 0;

            do
            {
                try
                {
                    Console.WriteLine("Please enter your current wheels' air pressure: ");
                    input = Console.ReadLine();
                    o_CurrentPressure = ConvertStringToInt(input);
                    //here we need to call the function in logic for check validation.
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (!parseSucceeded);
        }

        private void getCurrentEngineState(GarageLogic.VehicleBasics.Vehicle i_Vehicle, out float o_CurrentState)
        {
            string input;
            bool parseSucceeded = false;
            o_CurrentState = 0;

            do
            {
                try
                {
                    Console.WriteLine("Please enter your current engine state: ");
                    input = Console.ReadLine();
                    o_CurrentState = ConvertStringToFloat(input);
                    //here we need to call the function in logic for check validation.
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (!parseSucceeded);
        }

        private float ConvertStringToFloat(string input)
        {
            float inputAsFloat;

            if(float.TryParse(input, out inputAsFloat))
            {
                throw new FormatException("Invalid input Format");
            }

            return inputAsFloat;
        }

        private void getSpecialIntDataFromUser(string i_Message, out int o_CurrentEnergyState)
        {
            string input;
            bool parseSucceeded = false;
            o_CurrentEnergyState = 0;

            do
            {
                try
                {
                    Console.WriteLine(i_Message);
                    input = Console.ReadLine();
                    o_CurrentEnergyState = ConvertStringToInt(input);
                    parseSucceeded = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (!parseSucceeded);
        }

        

        private int ConvertStringToInt(string input)
        {
            int inputAsInt;

            if (!int.TryParse(input, out inputAsInt))
            {
                throw new FormatException("Invalid input format");
            }

            return inputAsInt;
        }

        private bool ConvertStringToIsColdBool(string input)
        {
            bool isCold;

            if (input == "Y" || input == "y")
            {
                isCold = true;
            }
            else if (input == "N" || input == "n")
            {
                isCold = false;
            }
            else
            {
                throw new ArgumentException("Invalid Option");
            }

            return isCold;
        }

        private eVehicleTypeOptions convertInputToVehicleTypeOption(string i_Input)
        {
            int inputAsInteger;
            eVehicleTypeOptions vehicleTypeOption = eVehicleTypeOptions.InvalidType;

            if(int.TryParse(i_Input, out inputAsInteger))
            {
                throw new FormatException("Invalid format input choice");
            }

            else
            {
                switch(inputAsInteger)
                {
                    case 1: vehicleTypeOption = eVehicleTypeOptions.ElectricMotorcycle;
                        break;
                    case 2: vehicleTypeOption = eVehicleTypeOptions.FuelMotorcycle;
                        break;
                    case 3: vehicleTypeOption = eVehicleTypeOptions.ElectricCar;
                        break;
                    case 4: vehicleTypeOption = eVehicleTypeOptions.FuelCar;
                        break;
                    case 5: vehicleTypeOption = eVehicleTypeOptions.Truck;
                        break;
                    default:
                        {
                            throw new ArgumentException("Invalid option. Option does not exist...");
                            
                        }

                }
            }

            return vehicleTypeOption;

        }

        private void printVehicleTypeOptions()
        {
            Console.WriteLine("Please choose from the following Vehicle type options:");
            Console.WriteLine("1.Electric Motorcycle");
            Console.WriteLine("2.Motorcycle Energised by fuel");
            Console.WriteLine("3.Electric Car");
            Console.WriteLine("4.Car energised by fuel");
            Console.WriteLine("5.Truck");
        }


        private void ShowLicenceNumbersOp()
        {
            
        }
        
        private void ChangeVehicleStateOp()
        {

        }

        private void AddAirToWheelsOp()
        {

        }

        private void AddFuelToVehicleOp()
        {

        }

        private void CharageVehicleOp()
        {

        }

        private void ShowVehiclesDataOp()
        {

        }
    }
}
