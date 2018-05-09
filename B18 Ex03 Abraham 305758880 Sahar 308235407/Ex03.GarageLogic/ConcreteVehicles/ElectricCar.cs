using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.GarageLogic.ConcreteVehicles
{
    public class ElectricCar:ElectricVehicle
    {
        private eVehicleColors m_VehicleColor;
        private int m_DoorsNumber;

        public int DoorsNumber
        {
            get { return m_DoorsNumber; }
            set { m_DoorsNumber = value; }
        }


        public eVehicleColors VehicleColor
        {
            get { return m_VehicleColor; }
            set { m_VehicleColor = value; }
        }

    }
}
