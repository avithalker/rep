using System.Text;
using Ex03.GarageLogic.VehicleBasics;

namespace Ex03.GarageLogic.ConcreteVehicles
{
    public class Truck:Vehicle
    {
        private bool m_IsTrunkCold;
        private float m_TrunkVolume;

        public Truck(Engine i_Engine, string i_Model, string i_LicenseNumber, bool i_IsTrunkCold, float i_TrunkVolume) : base(i_Engine, i_Model, i_LicenseNumber)
        {
            m_IsTrunkCold = i_IsTrunkCold;
            m_TrunkVolume = i_TrunkVolume;
        }

        public float TrunkVolume
        {
            get { return m_TrunkVolume; }
            set { m_TrunkVolume = value; }
        }

        public bool IsTrunkCold
        {
            get { return m_IsTrunkCold; }
            set { m_IsTrunkCold = value; }
        }

        public override string ToString()
        {
            StringBuilder infoBuilder = new StringBuilder();

            infoBuilder.Append(base.ToString());
            infoBuilder.Append(string.Format("The truck has {0} trunk volume ", m_TrunkVolume));
            if(m_IsTrunkCold)
            {
                infoBuilder.AppendLine("and has cold trunk");
            }
            else
            {
                infoBuilder.AppendLine("and doesnt have cold trunk");
            }

            return infoBuilder.ToString();
        }
    }
}
