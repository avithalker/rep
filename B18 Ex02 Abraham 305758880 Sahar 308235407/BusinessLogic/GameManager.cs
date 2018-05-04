using System.Collections.Generic;
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
        private int m_CurrentPlayerIndex;

        public int BoardSize
        {
            get { return m_BoardManager.BoardSize; }
        }

        public Cell[,] Board
        {
            get { return m_BoardManager.Board; }
        }

        public CheckerMoveInfo LastCheckerMove
        {
            get { return m_LastMove; }
        }

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

        public void StartGame()
        {
            m_CurrentPlayerIndex = 0;
            m_BoardManager.InitializeBoardsData();
        }

        public bool IsGameEnded()
        {
            return false;
        }

        public PlayerInfo GetCurrentPlayerTurn()
        {
            PlayerInfo playerInfo = new PlayerInfo();
            Player currentPlayer = players[m_CurrentPlayerIndex];

            playerInfo.PlayerName = currentPlayer.PlayerName;
            playerInfo.PlayerSign = currentPlayer.PlayerSign;
            playerInfo.PlayerTitle = currentPlayer.PlayerTitle;
            playerInfo.PlayerType = currentPlayer.PlayerType;

            return playerInfo;
        }

        public ActionResult HandlePlayerAction(string i_Action) // handle player move/Quit game
        {
            ActionResult ActionResult = null;

            if (i_Action == "Q")
            {
                QuitCurretPlayer();
            }
            else
            {
                Move Move = Move.Parse(i_Action);

                if (Move != null)
                {
                    ActionResult = m_BoardManager.MoveChecker(Move, players[m_CurrentPlayerIndex]);
                }
                else
                {
                    ActionResult = new ActionResult(false, "Invalid command syntax");
                }
            }

            return ActionResult;
        }

        private void QuitCurretPlayer()
        {
        }

        public GameSummery GetGameSummery()
        {
            return new GameSummery(); // here need to return all the end game info like the winner name, score, game state(TIE/WINNER)
        }

        private void ChangePlayerTurn()
        {
            m_CurrentPlayerIndex = (m_CurrentPlayerIndex + 1) % players.Count;
        }

        private void HandleEndOfTurn()
        {
            ChangePlayerTurn();
            if (players[m_CurrentPlayerIndex].PlayerType == Enums.PlayerTypes.ePlayerTypes.Computer)
            {
                PlayComputerMove();
            }
        }

        private void PlayComputerMove()
        {

        }

        private int CalculatePointsOfPlayer(Player i_Player)
        {
            int gamePoints = 0;
            int k_pointsForRegularSoldier = 1;
            int k_pointsForKingSoldier = 4;

            foreach (Soldier soldier in i_Player.Soldiers)
            {
                if (soldier.SoldierType == Enums.SoldierTypes.eSoldierTypes.Regular)
                {
                    gamePoints += k_pointsForRegularSoldier;
                }
                else
                {
                    gamePoints += k_pointsForKingSoldier;
                }
            }

            return gamePoints;
        }
    }
}