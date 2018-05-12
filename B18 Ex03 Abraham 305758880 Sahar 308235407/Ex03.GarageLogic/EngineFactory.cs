using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.GarageLogic
{
    internal static class EngineFactory
    {

        public static Engine CreateEngine(eEngineTypes i_EngineType, float i_EnergyCapacity, eFuelTypes i_FuelType = eFuelTypes.None)
        {
            Engine newEngine = null;
            switch (i_EngineType)
            {
                case eEngineTypes.ElectricVehicle:
                    {
                        newEngine = createElectricEngine(i_EnergyCapacity);
                    }
                    break;
                case eEngineTypes.FuelVehicle:
                    {
                        newEngine = createFuelEngine(i_FuelType, i_EnergyCapacity);
                    }
                    break;
            }

            return newEngine;
        }

        private static FuelEngine createFuelEngine(eFuelTypes i_FuelType, float i_EnergyCapacity)
        {
            return new FuelEngine(i_EnergyCapacity, i_FuelType);
        }

        private static ElectricEngine createElectricEngine(float i_EnergyCapacity)
        {
            return new ElectricEngine(i_EnergyCapacity);
        }
    }
}
