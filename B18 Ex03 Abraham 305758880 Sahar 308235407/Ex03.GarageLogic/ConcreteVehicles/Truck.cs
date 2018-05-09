using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.GarageLogic.ConcreteVehicles
{
    public class Truck:FuelVehicle
    {
        private bool m_IsTrunkCold;
        private double m_TrunkVolume;

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
