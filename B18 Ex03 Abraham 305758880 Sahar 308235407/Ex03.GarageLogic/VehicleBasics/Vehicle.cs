using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

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

        public void SetCurrentEnergyAmount(float i_EnergyAmount)
        {
            m_Engine.EnergyLeft = i_EnergyAmount;
        }

        public void SetCurrentWheelsAir(float i_AirPressure)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.AirPressure = i_AirPressure;
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

        public override string ToString()
        {
            StringBuilder infoString = new StringBuilder();

            infoString.AppendLine(string.Format("Vehicle lisence number: {0}", m_LicenseNumber));
            infoString.AppendLine(string.Format("Vehicle model: {0}", m_Model));
            infoString.AppendLine(string.Format("Number of wheels: {0}", m_Wheels.Count));
            infoString.AppendLine(Wheels[0].ToString());
            infoString.Append(m_Engine.ToString());
            return infoString.ToString();
        }
    }
}
