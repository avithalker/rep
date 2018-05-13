using System.Text;

namespace Ex03.GarageLogic.VehicleBasics
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_EnergyCapacity) : base(i_EnergyCapacity)
        {
        }

        public void Charge(float i_AmountOfTime)
        {
            FillEnergy(i_AmountOfTime);
        }

        public override string ToString()
        {
            StringBuilder infoString = new StringBuilder();

            infoString.AppendLine("Engine: Electric engine");
            infoString.AppendLine(string.Format("Time until next charge(H): {0}, energy capacity: {1}", EnergyLeft, EnergyCapacity));
            return infoString.ToString();
        }
    }
}
