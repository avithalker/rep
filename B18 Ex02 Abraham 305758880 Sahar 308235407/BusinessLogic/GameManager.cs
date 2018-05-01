using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Configuration;
using BusinessLogic.GameBoard;
using BusinessLogic.Dtos;

namespace BusinessLogic
{
    public class GameManager
    {
        private BoardManager m_BoardManager;
        private List<Player> players;
        private CheckerMoveInfo m_LastMove;
        private Player m_CurrentPlayer;

        public void InitializeGame(GameConfiguration i_GameConfiguration)
        {
            SetPlayers(i_GameConfiguration.PlayerConfigurations);
            m_BoardManager = new BoardManager(i_GameConfiguration.BoardSize, ref players);
            m_CurrentPlayer = players[0];
        }

        private void SetPlayers(List<PlayerConfiguration> i_playersConfiguration)
        {
            players = new List<Player>();
            players.Add(new Player(i_playersConfiguration[0], Enums.PlayerTitles.ePlayerTitles.PlayerOne));
            players.Add(new Player(i_playersConfiguration[1], Enums.PlayerTitles.ePlayerTitles.PlayerTwo));
        }

        public int BoardSize
        {
            get { return m_BoardManager.BoardSize; } // return the real board size!!!!
        }

        public Cell[,] Board
        {
            get { return m_BoardManager.Board; } // return the real board!!!
        }

        public CheckerMoveInfo LastCheckerMove
        {
            get { return m_LastMove; } // return the last move! if no last move, will return null
        }

        public void StartGame()
        {
            m_BoardManager.InitializeBoardsData();
        }

        public bool IsGameEnded()
        {
            return false;
        }

        public PlayerInfo GetCurrentPlayerTurn()
        {

            return new PlayerInfo(m_CurrentPlayer); //// here need to return the current player that need to play! fill the player info with the data!
        }

        public ActionResult HandlePlayerAction(string i_Action) // handle player move/Quit game
        {
            ActionResult k_ActionResult = null;

            if(!IsMoveSyntaxValid())
            {
                k_ActionResult = new ActionResult(false, "Invalid command syntax");
            }
            else
            {
                k_ActionResult = m_BoardManager.SetCheckersMove(i_Action); // here need to return if the action succeeded or not. if not, fill the message.
            }

            return k_ActionResult;
           
        }

        private bool IsMoveSyntaxValid()
        {
            return false;
        }

        public GameSummery GetGameSummery()
        {
            return new GameSummery(); // here need to return all the end game info like the winner name, score, game state(TIE/WINNER)
        }
    }
}