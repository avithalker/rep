using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleBasics;
using System.Text;

namespace Ex03.GarageLogic.Garage
{
    public class GarageEntity
    {
        private eVehicleStatuses m_VehicleStatus;
        private Vehicle m_VehicleEntity;
        private OwnerInfo m_OwnerContactInfo;

        public GarageEntity(OwnerInfo i_VehicleOwnerInfo,Vehicle i_Vehicle)
        {
            m_OwnerContactInfo = i_VehicleOwnerInfo;
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

        public OwnerInfo OwnerContactInfo
        {
            get { return m_OwnerContactInfo; }
            set { m_OwnerContactInfo = value; }
        }

        public string GetVehicleInformationForm()
        {
            StringBuilder informationFormBuilder = new StringBuilder();

            informationFormBuilder.AppendLine(m_OwnerContactInfo.ToString());
            informationFormBuilder.AppendLine(string.Format("Vehicle stauts: {0}", m_VehicleStatus));
            informationFormBuilder.AppendLine(m_VehicleEntity.ToString());
            return informationFormBuilder.ToString();
        }
    }
}
