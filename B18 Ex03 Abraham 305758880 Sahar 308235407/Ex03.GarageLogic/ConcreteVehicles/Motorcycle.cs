using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.GarageLogic.ConcreteVehicles
{
    public class Motorcycle:FuelVehicle
    {
        private LicenseTypes m_LicenseType;
        private int m_EngineVolume;

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public LicenseTypes LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }
    }
}
