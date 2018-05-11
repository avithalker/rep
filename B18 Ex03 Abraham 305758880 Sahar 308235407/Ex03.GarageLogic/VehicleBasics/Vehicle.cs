using Ex03.GarageLogic.Enums;
using System.Collections.Generic;

namespace Ex03.GarageLogic.VehicleBasics
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        public Vehicle(Engine i_Engine, string i_Model, string i_LicenseNumber)
        {
            m_Engine = i_Engine;
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
        }

        public Engine VehicleEngine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public float EnergyLevel
        {
            get
            {
                return (m_Engine.EnergyLeft / m_Engine.EnergyCapacity) * 100;
            }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public string Model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }

        public void InflateWheels()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                if (wheel.AirPressure < wheel.MaximumAirPressure)
                {
                    float airAmountDelta = wheel.MaximumAirPressure - wheel.AirPressure;

                    wheel.Inflate(airAmountDelta);
                }
            }
        }

        public eEngineTypes GetEngineType()
        {
            eEngineTypes engineType;

            if (m_Engine is ElectricEngine)
            {
                engineType = eEngineTypes.ElectricVehicle;
            }
            else
            {
                engineType = eEngineTypes.FuelVehicle;
            }

            return engineType;
        }
    }
}
