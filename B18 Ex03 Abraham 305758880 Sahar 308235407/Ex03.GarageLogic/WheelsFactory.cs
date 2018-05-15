using System.Collections.Generic;
using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.GarageLogic
{
    internal static class WheelsFactory
    {
        public static List<Wheel> CreateWheels(int i_Amount, float i_MaximumAirPressure, string i_Manufacturer)
        {
            List<Wheel> wheels = new List<Wheel>(i_Amount);

            for (int i = 0; i < i_Amount; i++)
            {
                Wheel wheel = new Wheel(i_Manufacturer, i_MaximumAirPressure);

                wheels.Add(wheel);
            }

            return wheels;
        }
    }
}
