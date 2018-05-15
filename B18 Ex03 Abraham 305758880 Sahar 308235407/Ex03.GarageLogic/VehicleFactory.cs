using Ex03.GarageLogic.ConcreteVehicles;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public static Car CreateCar(eEngineTypes i_EngineType, string i_Model, string i_LicenseNumber, int i_NumberOfDoors, eVehicleColors i_Color, string i_WheelManufacturer)
        {
            Engine newEngine = null;
            Car newCar = null;
            float energyCapacity = 0;
            eFuelTypes fuelType = eFuelTypes.None;
            float k_WheelMaxAirPressure = 32;
            int k_AmountOfWheels = 4;

            switch (i_EngineType)
            {
                case eEngineTypes.ElectricVehicle:
                    {
                        energyCapacity = 3.2f;
                        break;
                    }

                case eEngineTypes.FuelVehicle:
                    {
                        energyCapacity = 45;
                        fuelType = eFuelTypes.Octan98;
                        break;
                    }
            }

            newEngine = EngineFactory.CreateEngine(i_EngineType, energyCapacity, fuelType);
            newCar = new Car(newEngine, i_Model, i_LicenseNumber, i_NumberOfDoors);
            newCar.Wheels = WheelsFactory.CreateWheels(k_AmountOfWheels, k_WheelMaxAirPressure, i_WheelManufacturer);
            newCar.VehicleColor = i_Color;
            return newCar;
        }

        public static Motorcycle CreateMotorCycle(eEngineTypes i_EngineType, string i_Model, string i_LicenseNumber, int i_EngineVolume, eLicenseTypes i_LicenseType, string i_WheelManufacturer)
        {
            float energyCapacity = 0;
            eFuelTypes fuelType = eFuelTypes.None;
            float k_WheelMaxAirPressure = 30;
            int k_AmountOfWheels = 2;

            switch (i_EngineType)
            {
                case eEngineTypes.ElectricVehicle:
                    {
                        energyCapacity = 1.8f;
                        break;
                    }

                case eEngineTypes.FuelVehicle:
                    {
                        energyCapacity = 6;
                        fuelType = eFuelTypes.Octan96;
                        break;
                    }
            }

            Engine newEngine = EngineFactory.CreateEngine(i_EngineType, energyCapacity, fuelType);
            Motorcycle newMotorCycle = new Motorcycle(newEngine, i_Model, i_LicenseNumber, i_EngineVolume);

            newMotorCycle.Wheels = WheelsFactory.CreateWheels(k_AmountOfWheels, k_WheelMaxAirPressure, i_WheelManufacturer);
            newMotorCycle.LicenseType = i_LicenseType;
            return newMotorCycle;
        }

        public static Truck CreateTruck(string i_Model, string i_LicenseNumber, bool i_IsTrunkCold, string i_WheelManufacturer)
        {
            float k_EnergyCapacity = 115;
            float k_WheelMaxAirPressure = 28;
            int k_AmountOfWheels = 12;
            Engine newEngine = EngineFactory.CreateEngine(eEngineTypes.FuelVehicle, k_EnergyCapacity, eFuelTypes.Soler);
            Truck newTruck = new Truck(newEngine, i_Model, i_LicenseNumber, i_IsTrunkCold);

            newTruck.Wheels = WheelsFactory.CreateWheels(k_AmountOfWheels, k_WheelMaxAirPressure, i_WheelManufacturer);
            return newTruck;
        }
    }
}
