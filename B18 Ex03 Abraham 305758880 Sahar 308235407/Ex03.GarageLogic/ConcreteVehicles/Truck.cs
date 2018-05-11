using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.GarageLogic.ConcreteVehicles
{
    public class Truck:Vehicle
    {
        private bool m_IsTrunkCold;
        private double m_TrunkVolume;

        public Truck(Engine i_Engine, string i_Model, string i_LicenseNumber) : base(i_Engine, i_Model, i_LicenseNumber)
        {
        }

        public double TrunkVolume
        {
            get { return m_TrunkVolume; }
            set { m_TrunkVolume = value; }
        }

        public bool IsTrunkCold
        {
            get { return m_IsTrunkCold; }
            set { m_IsTrunkCold = value; }
        }
    }
}
