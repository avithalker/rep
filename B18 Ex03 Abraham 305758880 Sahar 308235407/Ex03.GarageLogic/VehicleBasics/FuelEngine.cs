using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.VehicleBasics
{
    public class FuelEngine:Engine
    {
        private eFuelTypes m_FuelType;

        public FuelEngine(float i_EnergyCapacity, eFuelTypes i_FuelType) : base(i_EnergyCapacity)
        {
            m_FuelType = i_FuelType;
        }

        public eFuelTypes FuelType
        {
            get { return m_FuelType; }
        }
    }
}
