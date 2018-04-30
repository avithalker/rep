using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Configuration;
using BusinessLogic.GameBoard;


namespace BusinessLogic
{
    public partial class GameManager
    {
        BoardManager m_BoardManager;
        List<Player> players;

        public void Init(GameConfiguration i_gameConfiguration)
        {
            SetPlayers(i_gameConfiguration. PlayerConfigurations);
            m_BoardManager = new BoardManager(i_gameConfiguration.BoardSize, ref players);
        }

        private void SetPlayers(List<PlayerConfiguration> i_playersConfiguration)
        {
            players = new List<Player>();
            players.Add(new Player(i_playersConfiguration[0], Enums.PlayerTitles.ePlayerTitles.PlayerOne));
            players.Add(new Player(i_playersConfiguration[1], Enums.PlayerTitles.ePlayerTitles.PlayerTwo));
        }
    }
}





