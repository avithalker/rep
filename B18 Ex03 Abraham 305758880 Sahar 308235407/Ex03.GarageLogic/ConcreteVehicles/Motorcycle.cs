using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.GarageLogic.ConcreteVehicles
{
    public class Motorcycle:Vehicle
    {
        private LicenseTypes m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(Engine i_Engine, string i_Model, string i_LicenseNumber,int i_EngineVolume) : base(i_Engine, i_Model, i_LicenseNumber)
        {
            m_EngineVolume = i_EngineVolume;
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
        }

        public LicenseTypes LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }
    }
}
