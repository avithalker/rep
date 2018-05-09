namespace Ex03.GarageLogic.VehicleBasics
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_BatteryTimeLeft;
        private float m_BatteryLifeTime;

        public float BatteryLifeTime
        {
            get { return m_BatteryLifeTime; }
            set { m_BatteryLifeTime = value; }
        }

        public float BatteryTimeLeft
        {
            get { return m_BatteryTimeLeft; }
            set { m_BatteryTimeLeft = value; }
        }

        public void ChargeBattery(float i_ChargingTime)
        {

        }

    }
}
