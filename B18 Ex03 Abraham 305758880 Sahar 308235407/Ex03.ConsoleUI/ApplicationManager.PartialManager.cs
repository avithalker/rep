using Ex03.GarageLogic.CustomErrors;
using System;

namespace Ex03.ConsoleUI
{
    public partial class ApplicationManager
    {
        private void addAirToWheelsOp2()
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
            catch(ArgumentException e)
            {
                Console.WriteLine(string.Format("Error has occured!{0}{1}",Environment.NewLine,e.Message));
            }
        }

        private void showVehiclesDataOp2()
        {
            string requestedLicenseNumber;

            Console.Clear();
            getValidLicenseNumber(out requestedLicenseNumber);
            Console.Clear();
            try
            {
                m_GarageManager.GetVehicleInformationForm(requestedLicenseNumber);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(string.Format("Error has occured!{0}{1}", Environment.NewLine, e.Message));
            }
        }

        private void charageVehicleOp2()
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
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(string.Format("Error has occured!{0}{1}", Environment.NewLine, e.Message));
            }
            catch(ValueOutOfRangeException e)
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
