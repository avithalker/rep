using System.Collections.Generic;

namespace Ex03.GarageLogic.VehicleBasics
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string LicenseNumber;
        private float m_EnergyLevel;
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
            get { return m_EnergyLevel; }
        }

        public string m_LicenseNumber
        {
            get { return LicenseNumber; }
            set { LicenseNumber = value; }
        }

        public string Model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }

    }
}
