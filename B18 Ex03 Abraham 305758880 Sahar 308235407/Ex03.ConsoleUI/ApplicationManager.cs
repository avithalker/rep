using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Garage;
using Ex03.ConsoleUI.Enums;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic;
using Ex03.ConsoleUI;




namespace Ex03.ConsoleUI
{
    class ApplicationManager
    {
        private GarageManager m_GarageManager;

        bool m_ParseSucceeded = true;
        bool m_VehicleTypeChoice = true;
        

        public ApplicationManager()
        {
            m_GarageManager = new GarageManager();
        }


        public void PrintMainMenu()
        {
            System.Console.WriteLine("Welcome To The Garage Manager App!!");
            System.Console.WriteLine("Please choose from the following options:");
            System.Console.WriteLine("1.Enter new vehicle to the garage");
            System.Console.WriteLine("2.Show vehicle license numbers");
            System.Console.WriteLine("3.Change vehicle's state");
            System.Console.WriteLine("4.Add air to the vehicle's wheels up to maximum ");
            System.Console.WriteLine("5.Refuel Gas Vehicle");
            System.Console.WriteLine("6.Charge electric vehicle");
            System.Console.WriteLine("7.Show vehicle's full data");
            System.Console.WriteLine("8.Exit");

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
            eMainMenuOptions choiceValueInput = eMainMenuOptions.InvalidChoice; //had to initialize for "Unassigned return value..." error
            
            do
            {
                input = System.Console.ReadLine();

                try
                {
                    choiceValueInput = convertInputToChoice(input);
                }
                catch( FormatException e)
                {
                    m_ParseSucceeded = false;
                    System.Console.WriteLine(e.Message);
                }
            } while (!m_ParseSucceeded) ;

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
                    default: throw new FormatException("Invalid Input Format");
                        
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
            

            System.Console.WriteLine("Please insert your vehicle's license number:");
            licenseNumber = System.Console.ReadLine();
            
            if(m_GarageManager.IsVehicleExist(licenseNumber))
            {
                System.Console.WriteLine("This Vehicle is already exists in the garage...");
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
            string input;
            do
            {
                try
                {
                    printVehicleTypeOptions();
                    input = System.Console.ReadLine();
                    vehicleTypeChoice = convertInputToVehicleTypeOption(input);
                    getDataByVehicleTypeChoice(vehicleTypeChoice);
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                    m_VehicleTypeChoice = false;
                }
            } while (!m_VehicleTypeChoice);
           
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
                throw new FormatException("Invalid Choice");
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
                            throw new FormatException("Invalid Input");
                            
                        }

                }
            }

            return vehicleTypeOption;

        }

        private void printVehicleTypeOptions()
        {
            System.Console.WriteLine("Please choose from the following Vehicle type options:");
            System.Console.WriteLine("1.Electric Motorcycle");
            System.Console.WriteLine("2.Motorcycle Energised by fuel");
            System.Console.WriteLine("3.Electric Car");
            System.Console.WriteLine("4.Car energised by fuel");
            System.Console.WriteLine("5.Truck");
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
