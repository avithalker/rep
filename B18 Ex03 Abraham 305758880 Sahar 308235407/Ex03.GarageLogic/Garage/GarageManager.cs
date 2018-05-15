using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleBasics;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Garage
{
    public class GarageManager
    {
        Dictionary<string, GarageEntity> m_GarageVehicles;

        public GarageManager()
        {
            m_GarageVehicles = new Dictionary<string, GarageEntity>();
        }

        public void InsertVehicleToGarage(Vehicle i_Vehicle, OwnerInfo i_Owner)
        {
            if (IsVehicleExist(i_Vehicle.LicenseNumber))
            {
                ChangeVehicleStatus(i_Vehicle.LicenseNumber, eVehicleStatuses.InFix);
            }
            else
            {
                GarageEntity newGarageEntity = new GarageEntity(i_Owner, i_Vehicle);

                m_GarageVehicles.Add(i_Vehicle.LicenseNumber, newGarageEntity);
            }
        }

        public List<string> GetLisenceByVehicleStatus(eVehicleStatuses i_status)
        {
            List<string> requestedLisences = new List<string>();

            foreach (KeyValuePair<string, GarageEntity> garageEntity in m_GarageVehicles)
            {
                if (garageEntity.Value.VehicleStatus == i_status)
                {
                    requestedLisences.Add(garageEntity.Key);
                }
            }

            return requestedLisences;
        }

        public List<string> GetAllLisencesInGarage()
        {
            List<string> requestedLicenses = new List<string>();
            foreach(eVehicleStatuses vehicleStatus in Enum.GetValues(typeof(eVehicleStatuses)))
            {
                requestedLicenses.AddRange(GetLisenceByVehicleStatus(vehicleStatus));
            }

            return requestedLicenses;
        }

        public void InflateWheels(string i_LisenceNumber)
        {
            Vehicle requestedVehicle = null;

            checkIfVehicleExist(i_LisenceNumber);
            requestedVehicle = m_GarageVehicles[i_LisenceNumber].VehicleEntity;
            requestedVehicle.InflateWheels();
        }

        public void ChangeVehicleStatus(string i_LisenceNumber, eVehicleStatuses i_NewStatus)
        {
            checkIfVehicleExist(i_LisenceNumber);
            m_GarageVehicles[i_LisenceNumber].VehicleStatus = i_NewStatus;
        }

        public void FuelVehicle(string i_LisenceNumber, eFuelTypes i_FuelType, float i_AmountToFill)
        {
            Vehicle requestedVehicle = null;
            FuelEngine vehicleEngine = null;

            checkIfVehicleExist(i_LisenceNumber);
            requestedVehicle = m_GarageVehicles[i_LisenceNumber].VehicleEntity;
            checkIfFillable(requestedVehicle, eEngineTypes.FuelVehicle);
            vehicleEngine = requestedVehicle.VehicleEngine as FuelEngine;
            vehicleEngine.FillFuel(i_FuelType, i_AmountToFill);
        }

        public void ChargeVehicle(string i_LisenceNumber, float i_TimeToCharge)
        {
            Vehicle requestedVehicle = null;
            ElectricEngine vehicleEngine = null;

            checkIfVehicleExist(i_LisenceNumber);
            requestedVehicle = m_GarageVehicles[i_LisenceNumber].VehicleEntity;
            checkIfFillable(requestedVehicle, eEngineTypes.ElectricVehicle);
            vehicleEngine = requestedVehicle.VehicleEngine as ElectricEngine;
            vehicleEngine.Charge(i_TimeToCharge);
        }

        public string GetVehicleInformationForm(string i_LisenceNumber)
        {
            checkIfVehicleExist(i_LisenceNumber);
            return m_GarageVehicles[i_LisenceNumber].GetVehicleInformationForm();
        }

        public bool IsVehicleExist(string i_LisenceNumber)
        {
            return m_GarageVehicles.ContainsKey(i_LisenceNumber);
        }

        private void checkIfVehicleExist(string i_LisenceNumber)
        {
            if (!IsVehicleExist(i_LisenceNumber))
            {
                string errorMessage = string.Format("Lisence number: {0} doesnt exist in the garage!", i_LisenceNumber);

                throw new ArgumentException(errorMessage);
            }
        }

        private void checkIfFillable(Vehicle i_Vehicle, eEngineTypes i_RequestedEngine)
        {
            if (i_Vehicle.GetEngineType() != i_RequestedEngine)
            {
                string errorMessage = string.Format("Cant fill energy to vehicle with lisence number: {0} because it's engine is not compatible!", i_Vehicle.LicenseNumber);
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
