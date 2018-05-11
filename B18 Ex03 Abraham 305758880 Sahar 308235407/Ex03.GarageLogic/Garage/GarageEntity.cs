using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.GarageLogic.Garage
{
    public class GarageEntity
    {
        private string m_VehicleOwner;
        private eVehicleStatuses m_VehicleStatus;
        private Vehicle m_VehicleEntity;

        public GarageEntity(string i_VehicleOwner,Vehicle i_Vehicle)
        {
            m_VehicleOwner = i_VehicleOwner;
            m_VehicleEntity = i_Vehicle;
            m_VehicleStatus = eVehicleStatuses.InFix;
        }

        public Vehicle VehicleEntity
        {
            get { return m_VehicleEntity; }
            set { m_VehicleEntity = value; }
        }

        public eVehicleStatuses VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public string CarOwner
        {
            get { return m_VehicleOwner; }
            set { m_VehicleOwner = value; }
        }
    }
}
