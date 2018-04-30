using BusinessLogic.Enums;

namespace BusinessLogic.Configuration
{
    public class PlayerConfiguration
    {
        private string m_PlayerName;
        private PlayerTypes.ePlayerTypes m_PlayerType;

        public PlayerTypes.ePlayerTypes PlayerType
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
