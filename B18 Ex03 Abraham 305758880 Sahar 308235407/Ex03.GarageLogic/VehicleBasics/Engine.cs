using System;
using Ex03.GarageLogic.CustomErrors;

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
            set
            {
                if (value < 0)
                {
                    string errorMsg = string.Format("'Energy to fill' value must be positive!");

                    throw new ArgumentException(errorMsg);
                }

                if (value > m_EnergyLeft)
                {
                    FillEnergy(value - m_EnergyLeft);
                }
            }
        }

        protected void FillEnergy(float i_EnergyAmount)
        {
            if(i_EnergyAmount < 0)
            {
                string errorMsg = string.Format("'Energy to fill' value must be positive!");

                throw new ArgumentException(errorMsg);
            }

            if(m_EnergyLeft + i_EnergyAmount > m_EnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, m_EnergyCapacity);
            }

            m_EnergyLeft += i_EnergyAmount;
        }
    }
}
