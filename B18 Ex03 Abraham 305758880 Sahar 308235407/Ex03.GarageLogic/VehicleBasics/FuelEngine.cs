using System;
using System.Text;
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

        public void FillFuel(eFuelTypes i_FuelType, float i_AmoutOfFuel)
        {
            if (i_FuelType != m_FuelType)
            {
                string errorMsg = string.Format("Cant fill {0} engine with fuel of type {1}!", m_FuelType, i_FuelType);

                throw new ArgumentException(errorMsg);
            }

            FillEnergy(i_AmoutOfFuel);
        }

        public override string ToString()
        {
            StringBuilder infoString = new StringBuilder();

            infoString.AppendLine("Engine: Fuel engine");
            infoString.AppendLine(string.Format("Fuel type: {0}, fuel left: {1}, fuel capacity: {2}", m_FuelType, EnergyLeft, EnergyCapacity));
            return infoString.ToString();
        }
    }
}
