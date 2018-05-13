using Ex03.GarageLogic.CustomErrors;
using System;

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
            if (i_AmountOfAir < 0)
            {
                string errorMsg = string.Format("'Air to fill' value must be positive!");

                throw new ArgumentException(errorMsg);
            }

            if (m_AirPressure + i_AmountOfAir > m_MaximumAirPressure)
            {
                throw new ValueOutOfRangeException(0, m_MaximumAirPressure);
            }

            m_AirPressure += i_AmountOfAir;
        }

        public override string ToString()
        {
            return string.Format("wheel manufactur: {0}, air pressure: {1}, max air pressure: {2}", m_Manufacturer, m_AirPressure, m_MaximumAirPressure);
        }

    }
}
