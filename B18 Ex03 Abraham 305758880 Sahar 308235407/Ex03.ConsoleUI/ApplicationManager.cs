using System;
using Ex03.GarageLogic.Garage;
using Ex03.ConsoleUI.Enums;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.ConcreteVehicles;
using Ex03.GarageLogic;
using Ex03.GarageLogic.CustomErrors;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public partial class ApplicationManager
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
                case eMainMenuOptions.AddAirToWheels: addAirToWheelsOp();
                    break;
                case eMainMenuOptions.AddFuelToVehicle: AddFuelToVehicleOp();
                    break;
                case eMainMenuOptions.ChargeVehicle: charageVehicleOp();
                    break;
                case eMainMenuOptions.ShowVehiclesData: showVehiclesDataOp();
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
                ownerInfo = CreateOwnerInfoFromUser();
                m_GarageManager.InsertVehicleToGarage(vehicle, ownerInfo);
                Console.WriteLine("The vehicle was added to the garage successfully!!");
            }

        }

        private OwnerInfo CreateOwnerInfoFromUser()
        {
            string owner;
            string phoneNumber;

            getValidPhoneNumberFromUser(out phoneNumber);
            getValidOwnerName(out owner);

            return new OwnerInfo(phoneNumber, owner);
        }

        private void getValidPhoneNumberFromUser(out string o_PhoneNumber)
        {
            bool parseSucceeded = false;
            string input = "";

            do
            {
              try
                {
                    Console.WriteLine("Please insert the owner's phone number: ");
                    input = Console.ReadLine();
                    ConvertStringToInt(input);
                    parseSucceeded = true;
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
            } while (!parseSucceeded);


            o_PhoneNumber = input;
        }

        private void getValidOwnerName(out string o_Owner)
        {
            o_Owner = "";
            string input;
            bool parseSucceeded = false;

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
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }

            } while (!parseSucceeded);
        }

        private void CheckIfNameNotContainsNumbers(string i_Input)
        {
            foreach (char Char in i_Input)
            {
                if (!((Char >= 'A' && Char <= 'Z') || (Char>='a' && Char<='z')))
                {
                    throw new FormatException("Invalid owner name. name has to contain letters only");
                }
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
                    parseSucceeded = false;
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
                    ConvertToValidNumberOfDoors(input, out o_NumberOfDoors);
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

        private void ConvertToValidNumberOfDoors(string i_NumberOfDoors, out int o_NumberOfDoors)
        {

            if (!(int.TryParse(i_NumberOfDoors, out o_NumberOfDoors)))
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

            if (!Enum.IsDefined(typeof(eVehicleColors), colorOption))
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
                    parseSucceeded = true;
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
                catch(ArgumentException e)
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
            else if (!Enum.IsDefined(typeof(LicenseTypes), choice))
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
            bool parseSucceeded = true;
            o_CurrentState = 0;

            do
            {
                try
                {
                    Console.WriteLine("Please enter your current energy amount: ");
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

            if(!int.TryParse(i_Input, out inputAsInteger))
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
            string input;
            int choice;
            bool parseSucceeded = false;

            do
            {
                try
                {
                    Console.WriteLine("Please choose which license numbers you would like to see according to the following filters:");
                    Console.WriteLine("1.Fixed vehicles");
                    Console.WriteLine("2.In fix vehicles");
                    Console.WriteLine("3.Paid vehicles");
                    Console.WriteLine("4.All vehicles");
                    input = Console.ReadLine();
                    choice = ConvertInputToFiltersChoice(input);
                    doActionUserByFilterChoice(choice);
                }
                catch( FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch( ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (!parseSucceeded);
         
        }

        private void doActionUserByFilterChoice(int choice)
        {
            switch(choice)
            {
                case 1: printLicenseNumbersByVehiclesState(eVehicleStatuses.Fixed);
                    break;
                case 2: printLicenseNumbersByVehiclesState(eVehicleStatuses.InFix);
                    break;
                case 3: printLicenseNumbersByVehiclesState(eVehicleStatuses.Paid);
                    break;
                case 4: printLicenseNumbersByVehiclesState(eVehicleStatuses.None);
                    break;
                default:
                    {
                        throw new ArgumentException("Invalid choice");
                    }
            }
        }

        private void printLicenseNumbersByVehiclesState(eVehicleStatuses i_VehicleStatus)
        {
            List<String> licenseNumbers;

            if(i_VehicleStatus == eVehicleStatuses.None)
            {
                //call functon from logic
            }   

            else
            {
                licenseNumbers = m_GarageManager.GetLisenceByVehicleStatus(i_VehicleStatus);

                if (licenseNumbers.Count == 0)
                {
                    Console.WriteLine("There are no vehicles in this status");
                }
                else
                {
                    foreach (string licenseNumber in licenseNumbers)
                    {
                        Console.WriteLine(licenseNumber);
                    }
                }  
            }
        }

        private int ConvertInputToFiltersChoice(string i_Input)
        {
            int choice;

            if(!int.TryParse(i_Input, out choice))
            {
                throw new FormatException("Invalid Format");
            }
            else
            {
                return choice;   
            }
        }
        
        private void ChangeVehicleStateOp()
        {

        }

        private void addAirToWheelsOp()
        {
            string requestedLicenseNumber;

            Console.Clear();
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

        private void AddFuelToVehicleOp()
        {

        }

        private void charageVehicleOp()
        {
            string requestedLicenseNumber;
            float timeToCharge;

            Console.Clear();
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

            Console.Clear();
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
            } while (!isValid);

            return energyToAdd;
        }
    }
}
