namespace Ex03.GarageLogic.VehicleBasics
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_AirPressure;
        private float m_MaximumAirPressure;

        public Wheel(string i_Manufactur, float i_MaximumAirPressure)
        {
            m_AirPressure = 0;
            m_Manufacturer = i_Manufactur;
            m_MaximumAirPressure = i_MaximumAirPressure;
        }

        public float MaximumAirPressure
        {
            get { return m_MaximumAirPressure; }
            set { m_MaximumAirPressure = value; }
        }

        public float AirPressure
        {
            get { return m_AirPressure; }
        }

        public string Manufacturer
        {
            get { return m_Manufacturer; }
        }

        public void Inflate(float i_AmountOfAir)
        {

        }

    }
}
