namespace Ex03.GarageLogic.VehicleBasics
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_AirPressure;
        private float m_MaximumAirPressure;

        public float MaximumAirPressure
        {
            get { return m_MaximumAirPressure; }
            set { m_MaximumAirPressure = value; }
        }


        public float AirPressure
        {
            get { return m_AirPressure; }
            set { m_AirPressure = value; }
        }


        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set { m_Manufacturer = value; }
        }

        public void Inflate(float i_AmountOfAir)
        {

        }

    }
}
