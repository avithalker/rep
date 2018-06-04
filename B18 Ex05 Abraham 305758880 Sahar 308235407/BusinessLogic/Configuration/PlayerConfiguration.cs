using BusinessLogic.Enums;

namespace BusinessLogic.Configuration
{
    public class PlayerConfiguration
    {
        private string m_PlayerName;
        private ePlayerTypes m_PlayerType;

        public ePlayerTypes PlayerType
        {
            get { return m_PlayerType; }
            set { m_PlayerType = value; }
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }
    }
}
