using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleBasics;
using System.Text;

namespace Ex03.GarageLogic.ConcreteVehicles
{
    public class Car:Vehicle
    {
        private eVehicleColors m_VehicleColor;
        private int m_DoorsNumber;

        public Car(Engine i_Engine, string i_Model, string i_LicenseNumber,int i_DoorsNumber) : base(i_Engine, i_Model, i_LicenseNumber)
        {
            m_DoorsNumber = i_DoorsNumber;
        }

        public int DoorsNumber
        {
            get { return m_DoorsNumber; }
        }

        public eVehicleColors VehicleColor
        {
            get { return m_VehicleColor; }
            set { m_VehicleColor = value; }
        }

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder();

            infoBuilder.Append(base.ToString());
            infoBuilder.AppendLine(string.Format("The car has {0} doors and it's color is: {1}", m_DoorsNumber, m_VehicleColor));
            return infoBuilder.ToString();
        }
    }
}
