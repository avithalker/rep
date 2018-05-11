namespace Ex03.GarageLogic.VehicleBasics
{
    //todo:deleate!
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_BatteryTimeLeft;
        private float m_BatteryLifeTime;

        public ElectricVehicle(Engine i_Engine, string i_Model, string i_LicenseNumber) : base(i_Engine, i_Model, i_LicenseNumber)
        {
        }

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
