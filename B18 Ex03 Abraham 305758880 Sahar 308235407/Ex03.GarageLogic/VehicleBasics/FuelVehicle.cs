using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.VehicleBasics
{
    public abstract class FuelVehicle : Vehicle
    {
        private eFuelTypes m_FuelType;
        private float m_FuelAmount;
        private float m_MaximumFuelAmount;

        public eFuelTypes FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        public float MaximumFuelAmount
        {
            get { return m_MaximumFuelAmount; }
            set { m_MaximumFuelAmount = value; }
        }

        public float FuelAmount
        {
            get { return m_FuelAmount; }
            set { m_FuelAmount = value; }
        }

        public void AddFuel(eFuelTypes i_FuelType, float i_FuelAmount)
        {

        }

    }
}
