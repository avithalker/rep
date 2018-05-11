﻿namespace Ex03.GarageLogic.VehicleBasics
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
    }
}
