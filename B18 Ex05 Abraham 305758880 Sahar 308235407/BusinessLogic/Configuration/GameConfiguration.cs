using System.Collections.Generic;
using BusinessLogic.Enums;

namespace BusinessLogic.Configuration
{
    public class GameConfiguration
    {
        private int m_BoardSize;
        private eGameModes m_GameMode;
        private List<PlayerConfiguration> m_PlayerConfigurations;

        public eGameModes GameMode
        {
            get { return m_GameMode; }
            set
            {
                m_GameMode = value;
                if(m_GameMode == eGameModes.OnePlayerGame)
                {
                    PlayerConfiguration computerPlayerConfig = new PlayerConfiguration();

                    computerPlayerConfig.PlayerName = "Computer";
                    computerPlayerConfig.PlayerType = ePlayerTypes.Computer;
                    AddPlayerConfiguration(computerPlayerConfig);
                }
            }
        }

        public List<PlayerConfiguration> PlayerConfigurations
        {
            get
            {
                return m_PlayerConfigurations;
            }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        public GameConfiguration()
        {
            m_PlayerConfigurations = new List<PlayerConfiguration>(2);
        }

        public void AddPlayerConfiguration(PlayerConfiguration i_PlayerConfiguration)
        {
            m_PlayerConfigurations.Add(i_PlayerConfiguration);
        }
    }
}
