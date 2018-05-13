using System;
using Ex03.GarageLogic.Garage;
using Ex03.ConsoleUI.Enums;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class ApplicationManager
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
                catch( FormatException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(e.Message);
                }
                catch(ArgumentException e)
                {
                    parseSucceeded = false;
                    Console.WriteLine(e.Message);
                }
            } while (!parseSucceeded) ;

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
            switch(i_Choice)
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
            string owner;


            Console.WriteLine("Please insert your vehicle's license number:");
            licenseNumber = Console.ReadLine();
            
            if(m_GarageManager.IsVehicleExist(licenseNumber))
            {
                Console.WriteLine("This Vehicle is already exists in the garage...");
                m_GarageManager.ChangeVehicleStatus(licenseNumber, eVehicleStatuses.InFix);
            }
            else
            {
                getDataForCreateNewVehicle(); 
            }

        }

        private void getDataForCreateNewVehicle()
        {
            eVehicleTypeOptions vehicleTypeChoice;
            bool parseSucceeded = false;
            string input;
            do
            {
                try
                {
                    printVehicleTypeOptions();
                    input = Console.ReadLine();
                    vehicleTypeChoice = convertInputToVehicleTypeOption(input);
                    getDataByVehicleTypeChoice(vehicleTypeChoice);
                    parseSucceeded = true;
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!parseSucceeded);
           
        }

        private void  getDataByVehicleTypeChoice(eVehicleTypeOptions i_VehicleTypeChoice)
        {
            switch(i_VehicleTypeChoice)
            {
                case eVehicleTypeOptions.ElectricMotorcycle:
                    getDataForElectricMotorcycle();
                    break;
                case eVehicleTypeOptions.FuelMotorcycle:
                    getDataForFuelMotorcycle();
                    break;
                case eVehicleTypeOptions.ElectricCar:
                    getDataForElectricCar();
                    break;
                case eVehicleTypeOptions.FuelCar:
                    getDataForFuelCar();
                    break;
                case eVehicleTypeOptions.Truck:
                    getDataForTruck();
                    break;
            }
               
        }

        private void getDataForElectricMotorcycle()
        { 
            string model;
            string licenseNumber;
            int engineVolume;  //define in factory as int but neet float ? 
            LicenseTypes licenseType; 
            string wheelsManufacturer;

            getDataForMotorycle(eEngineTypes.ElectricVehicle, out model, out licenseNumber, out engineVolume, out wheelsManufacturer, out licenseType);
        }

        private void getDataForMotorycle(eEngineTypes i_EngineType, out string o_Model, out string o_LicenseNumber, out int o_EngineVolume, out string o_WheelsManufacturer, out LicenseTypes o_LicenseType)
        {
            getModel(out o_Model);
            getValidLicenseNumber(out o_LicenseNumber);
            getValidEngineVolume(out o_EngineVolume);
            getWheelsManufacturer(out o_WheelsManufacturer);
            getLicenseType(out o_LicenseType);

            VehicleFactory.CreateMotorCycle(i_EngineType, o_Model, o_LicenseNumber, o_EngineVolume, o_LicenseType, o_WheelsManufacturer);

        }

        /*private void getDataForCar(eEngineTypes i_EngineType, out string o_Model, out string o_LicenseNumber, out int o_NumberOfDoors, out eVehicleColors o_Color, out string o_WheelsManufacturer)
        {
            getModel(out o_Model);
            getValidLicenseNumber(out o_LicenseNumber);
            getWheelsManufacturer(out o_WheelsManufacturer);
            getValidNumberOfDoors(out o_NumberOfDoors);
            //getValidColor(out o_Color);
        }
        */

        /*private void getValidNumberOfDoors(out int o_NumberOfDoors)
        {
            bool parseSuceeded = false;
            string input;

            do
            {
                System.Console.WriteLine("Please insert the number of doors from the following options: 2,3,4,5: ");
                input = Console.ReadLine();
                try
                {
                    getIntegerStringInputToInt(input, out o_NumberOfDoors);
                    CheckNumberOfDoorsValidation(o_NumberOfDoors);
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

        private void CheckNumberOfDoorsValidation(int i_NumberOfDoors)
        {
            if (!(i_NumberOfDoors != 5 && i_NumberOfDoors !=4 && i_NumberOfDoors != 3 && i_NumberOfDoors != 2))
            {
                throw new ArgumentException("Invalid number of doors");
            }
        }

        /*private getValidColor(out eVehicleColors o_Color)
        {
            bool parseSucceeded = false;
            string input;

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
                    //o_Color = ConvertStringColorToVehicleColor(input);
                    parseSucceeded = true;
                }
                catch (ArgumentException e)
                {
                    System.Console.WriteLine(e.Message);
                }
            } while (!parseSucceeded);
        }
        */
        /*private ConvertStringColorToVehicleColor(string i_Color)
        {
            int colorOption;

           if(!int.TryParse(i_Color,out colorOption))
            {
                throw FormatException("Invalid Option Format");
            }
           if()
        }
        */

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
                catch(FormatException e)
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
                    Console.WriteLine("Please insert your license type by typing one of the following options: A, A1, B1, B2 :");
                    input = Console.ReadLine();
                    o_LicenseType = convertStringToLicenseType(input);
                    parseSucceeded = true;
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                    parseSucceeded = false;
                }
                
            } while (!parseSucceeded); 
            
        }

        private LicenseTypes convertStringToLicenseType(string i_Input)
        {
            LicenseTypes licenseType;
            switch (i_Input)
            {
                case "A": licenseType = LicenseTypes.A;
                    break;
                case "A1": licenseType = LicenseTypes.A1;
                    break;
                case "B1": licenseType = LicenseTypes.B1;
                    break;
                case "B2": licenseType = LicenseTypes.B2;
                    break;
                default:
                    {
                        throw new FormatException("Invalid license type");
                    }
            }

            return licenseType;
        }

        private void getValidLicenseNumber(out string  o_LicenseNumber)
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

        private void getDataForFuelMotorcycle()
        {


        }

        private void getDataForElectricCar()
        {

        }

        private void getDataForFuelCar()
        {

        }

        private void getDataForTruck()
        {

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
