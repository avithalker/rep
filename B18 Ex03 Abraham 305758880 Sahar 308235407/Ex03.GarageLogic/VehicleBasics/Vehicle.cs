using System.Collections.Generic;

namespace Ex03.GarageLogic.VehicleBasics
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string LicenseNumber;
        private float m_EnergyLevel;
        private List<Wheel> m_Wheels;

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public float EnergyLevel
        {
            get { return m_EnergyLevel; }
            set { m_EnergyLevel = value; }
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
