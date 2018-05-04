using System.Collections.Generic;
using BusinessLogic.Configuration;
using BusinessLogic.GameBoard;
using BusinessLogic.Dtos;
using BusinessLogic.Enums;


namespace BusinessLogic
{
    public class GameManager
    {
        private BoardManager m_BoardManager;
        private List<Player> m_players;
        private CheckerMoveInfo m_LastMove;
        private int m_CurrentPlayerIndex;

        public void InitializeGame(GameConfiguration i_GameConfiguration)
        {
            SetPlayers(i_GameConfiguration.PlayerConfigurations);
            m_BoardManager = new BoardManager(i_GameConfiguration.BoardSize, m_players);
        }

        private void SetPlayers(List<PlayerConfiguration> i_playersConfiguration)
        {
            m_players = new List<Player>();
            m_players.Add(new Player(i_playersConfiguration[0], PlayerTitles.ePlayerTitles.PlayerOne));
            m_players.Add(new Player(i_playersConfiguration[1], PlayerTitles.ePlayerTitles.PlayerTwo));
        }

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
            Player currentPlayer = m_players[m_CurrentPlayerIndex];

            playerInfo.PlayerName = currentPlayer.PlayerName;
            playerInfo.PlayerSign = currentPlayer.PlayerSign;
            playerInfo.PlayerTitle = currentPlayer.PlayerTitle;
            playerInfo.PlayerType = currentPlayer.PlayerType;

            return playerInfo;
        }

        public ActionResult HandlePlayerAction(string i_Action) // handle player move/Quit game
        {
            ActionResult actionResult = null;
            
            if (i_Action == "Q")
            {
                QuitCurrentPlayer();
            }
            else
            {
                Move Move = Move.Parse(i_Action);

                if (Move != null)
                {

                    actionResult = m_BoardManager.MoveChecker(Move, m_players[m_CurrentPlayerIndex]);
                    if(actionResult.IsSucceed)
                    {
                        HandleEndOfTurn();
                    }
                }
                else
                {
                    actionResult = new ActionResult(false, "Invalid command syntax");
                }
            }

            return actionResult;
        }

        private void QuitCurrentPlayer()
        {
        }

        public GameSummery GetGameSummery()
        {
            return new GameSummery(); // here need to return all the end game info like the winner name, score, game state(TIE/WINNER)
        }

        private void ChangePlayerTurn()
        {
            m_CurrentPlayerIndex = (m_CurrentPlayerIndex + 1) % m_players.Count;
        }

        private void HandleEndOfTurn()
        {
            ChangePlayerTurn();

            if (m_players[m_CurrentPlayerIndex].PlayerType == PlayerTypes.ePlayerTypes.Computer)
            {
                PlayComputerMove();
            }
        }

        private void PlayComputerMove()
        {
            List<Move> legalMoves = m_BoardManager.GetLegalMovesOfPlayer(m_players[m_CurrentPlayerIndex]);
            Move chosenMove = ComputerPlayer.SelectMoveAction(legalMoves);

        }
            
        private int CalculatePointsOfPlayer(Player i_Player)
        {
            int gamePoints = 0;
            int k_pointsForRegularSoldier = 1;
            int k_pointsForKingSoldier = 4;

            foreach(Soldier soldier in i_Player.Soldiers)
            {
                if(soldier.SoldierType == SoldierTypes.eSoldierTypes.Regular)
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