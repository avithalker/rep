namespace Ex03.GarageLogic.VehicleBasics
{
    public abstract class Engine
    {
        private float m_EnergyLeft;
        private float m_EnergyCapacity;

        public Engine(float i_EnergyCapacity)
        {
            m_EnergyCapacity = i_EnergyCapacity;
            m_EnergyLeft = 0;
        }

        public float EnergyCapacity
        {
            get { return m_EnergyCapacity; }
        }

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
        }

        public void FillEnergy(float i_EnergyAmount)
        {

        }
    }
}
