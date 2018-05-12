namespace Ex03.GarageLogic.Garage
{
    public class OwnerInfo
    {
        private string m_Name;
        private string  m_PhoneNumber;

        public OwnerInfo(string i_Name,string i_PhoneNumber)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
        }

        public string  PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

    }
}
