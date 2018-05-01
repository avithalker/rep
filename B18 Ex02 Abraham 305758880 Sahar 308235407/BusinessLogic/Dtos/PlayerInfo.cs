using BusinessLogic.Enums;

namespace BusinessLogic.Dtos
{
    public class PlayerInfo
    {
        private string m_PlayerName;
        private PlayerTypes.ePlayerTypes m_PlayerType;
        private PlayerTitles.ePlayerTitles m_PlayerTitle;
        private char m_PlayerSign;

        public PlayerInfo(Player i_player)
        {
            this.m_PlayerName = i_player.PlayerName;
            this.m_PlayerType = i_player.PlayerType;
            this.m_PlayerTitle = i_player.PlayerTitle;
            this.m_PlayerSign = i_player.GetPlayerSign();
        }

        public char PlayerSign
        {
            get { return m_PlayerSign; }
            set { m_PlayerSign = value; }
        }

        public PlayerTitles.ePlayerTitles PlayerTitle
        {
            get { return m_PlayerTitle; }
            set { m_PlayerTitle = value; }
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }

        public PlayerTypes.ePlayerTypes PlayerType
        {
            get { return m_PlayerType; }
            set { m_PlayerType = value; }
        }
    }
}
