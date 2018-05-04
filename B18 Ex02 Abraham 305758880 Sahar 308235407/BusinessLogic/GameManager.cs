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
            m_BoardManager = new BoardManager(i_GameConfiguration.BoardSize, players);
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
            m_CurrentPlayer = players[0];
            m_BoardManager.InitializeBoardsData();
        }

        public bool IsGameEnded()
        {
            return false;
        }

        public PlayerInfo GetCurrentPlayerTurn()
        {
            PlayerInfo k_PlayerInfo = new PlayerInfo();
            k_PlayerInfo.PlayerName = m_CurrentPlayer.PlayerName;
            k_PlayerInfo.PlayerSign = m_CurrentPlayer.PlayerSign;
            k_PlayerInfo.PlayerTitle = m_CurrentPlayer.PlayerTitle;
            k_PlayerInfo.PlayerType = m_CurrentPlayer.PlayerType;

            return k_PlayerInfo; //// here need to return the current player that need to play! fill the player info with the data!
        }

        public ActionResult HandlePlayerAction(string i_Action) // handle player move/Quit game
        {
            ActionResult k_ActionResult = null;
            Move k_Move = Move.Parse(i_Action);

            if (k_Move == null && i_Action != "Q") 
            {
                k_ActionResult = new ActionResult(false, "Invalid command syntax");
            }
            else
            {
                if(i_Action== "Q")
                {
                    QuitCurretPlayer();
                }

                k_ActionResult = m_BoardManager.SetCheckersMove(k_Move, m_CurrentPlayer); // here need to return if the action succeeded or not. if not, fill the message.
            }

            return k_ActionResult;  
        }

        private void QuitCurretPlayer()
        {
        }

        private bool IsMoveSyntaxValid(String i_Action)
        {
            String[] moves = i_Action.Split('>');

            if(moves.Length != 2)
            {
                return false;
            }

            return true;
        }

        public GameSummery GetGameSummery()
        {
            return new GameSummery(); // here need to return all the end game info like the winner name, score, game state(TIE/WINNER)
        }
    }
}