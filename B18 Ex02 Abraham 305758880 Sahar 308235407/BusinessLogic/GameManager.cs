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
        private Player m_LastWinner;
        private eGameStatus m_GameStatus;

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
            m_GameStatus = eGameStatus.None;
            m_LastWinner = null;
            SetPlayers(i_GameConfiguration.PlayerConfigurations);
            m_BoardManager = new BoardManager(i_GameConfiguration.BoardSize, m_players);
        }

        private void SetPlayers(List<PlayerConfiguration> i_playersConfiguration)
        {
            m_players = new List<Player>();
            m_players.Add(new Player(i_playersConfiguration[0], ePlayerTitles.PlayerOne));
            m_players.Add(new Player(i_playersConfiguration[1], ePlayerTitles.PlayerTwo));
        }

        public void StartGame()
        {
            m_CurrentPlayerIndex = 0;
            m_BoardManager.InitializeBoardsData();
            m_GameStatus = eGameStatus.Started;
        }

        public bool IsGameEnded()
        {
            return m_GameStatus == eGameStatus.Tie || m_GameStatus == eGameStatus.Winner;
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
                
                actionResult = QuitCurrentPlayerIfLegal();
            }
            else
            {
                Move move = Move.Parse(i_Action);

                if (move != null)
                {
                    actionResult = MoveChecker(move);
                }
                else
                {
                    actionResult = new ActionResult(false, "Invalid command syntax");
                }
            }

            return actionResult;
        }

        private ActionResult MoveChecker(Move i_Move)
        {
            ActionResult actionResult = m_BoardManager.MoveChecker(i_Move, m_players[m_CurrentPlayerIndex]);

            if (actionResult.IsSucceed)
            {
                m_LastMove = ConvertMoveToCheckerMoveInfo(i_Move);          //TODO: update here the m_LastMove !!!!
                HandleEndOfTurn();
            }

            return actionResult;
        }

        private CheckerMoveInfo ConvertMoveToCheckerMoveInfo(Move i_Move)
        {
            string playerName = GetPlayerNameByTitle(m_BoardManager.GetCellByLocation(i_Move.NextLocation).Soldier.Owner);
            string previousMove = i_Move.CurrentLocation.ToString();
            string nextMove = i_Move.NextLocation.ToString();

            return new CheckerMoveInfo(playerName, previousMove, nextMove);
        }

        private string GetPlayerNameByTitle(ePlayerTitles i_Title)
        {
            string name = m_players[0].PlayerName;
            if(m_players[1].PlayerTitle == i_Title)
            {
                name = m_players[1].PlayerName;
            }

            return name;
        }
           

        private ActionResult QuitCurrentPlayerIfLegal()
        {
            ActionResult actionResult;

            if(CheckIfPlayerCanQuit())
            {
                QuitCurrentPlayerFromGame();
                actionResult = new ActionResult(true, string.Empty);
            }
            else
            {
                actionResult = new ActionResult(false, "You cannot quit at this point");
            }

            return actionResult;
        }

        private bool CheckIfPlayerCanQuit()
        {
            Enums.ePlayerTitles currentPlayerTitle = currentPlayerTitle = m_players[m_CurrentPlayerIndex].PlayerTitle;
            int opponentIndex = 0;
            bool hasSmallerScore = false;
            bool hasSmallerAmountOfSoldiers = false;
            if (m_CurrentPlayerIndex == 0)
            {
                opponentIndex = 1;
            }

            if (m_players[opponentIndex].Score > m_players[m_CurrentPlayerIndex].Score)
            {
                hasSmallerScore = true;
            }

            if (m_players[opponentIndex].Soldiers.Count > m_players[m_CurrentPlayerIndex].Soldiers.Count)
            {
                hasSmallerAmountOfSoldiers = true;
            }

            return hasSmallerAmountOfSoldiers & hasSmallerScore;
        }

        private void QuitCurrentPlayerFromGame()
        {
            m_GameStatus = eGameStatus.Winner;
            
            if(m_CurrentPlayerIndex == 0)
            {
                m_LastWinner = m_players[1];
            }
            else
            {
                m_LastWinner = m_players[0];
            }
            
        }

        public GameSummery GetGameSummery()
        {
            GameSummery gameSummery = new GameSummery();

            gameSummery.EndGameState = m_GameStatus;
            if (m_GameStatus == eGameStatus.Winner)
            {
                gameSummery.WinnerName = m_LastWinner.PlayerName;
                gameSummery.Score = m_LastWinner.Score;
            }

            return gameSummery;
        }

        private void ChangePlayerTurn()
        {
            m_CurrentPlayerIndex = (m_CurrentPlayerIndex + 1) % m_players.Count;
        }

        private void CheckAndUpdateIfGameEnded()
        {
            bool[] playersHasMoves = new bool[m_players.Count];
            bool hasMovesToDo = false;

            for (int i = 0; i < m_players.Count; i++)
            {
                if (m_BoardManager.GetLegalMovesOfPlayer(m_players[i]).Count != 0)
                {
                    playersHasMoves[i] = true;
                    hasMovesToDo = true;
                }
            }

            if (hasMovesToDo)
            {
                if (playersHasMoves[0] && !playersHasMoves[1])
                {
                    m_LastWinner = m_players[0];
                    UpdateWinnerScore(m_players[0], m_players[1]);
                    m_GameStatus = eGameStatus.Winner;
                }
                else if (!playersHasMoves[0] && playersHasMoves[1])
                {
                    m_LastWinner = m_players[1];
                    UpdateWinnerScore(m_players[1], m_players[0]);
                    m_GameStatus = eGameStatus.Winner;
                }
            }
            else
            {
                m_GameStatus = eGameStatus.Tie;
            }
        }

        private void HandleEndOfTurn()
        {
            ChangePlayerTurn();

            if (m_players[m_CurrentPlayerIndex].PlayerType == ePlayerTypes.Computer)
            {
                PlayComputerMove();
                CheckAndUpdateIfGameEnded();
            }
            else
            {
                CheckAndUpdateIfGameEnded();
            }
        }

        private void PlayComputerMove()
        {
            List<Move> legalMoves = m_BoardManager.GetLegalMovesOfPlayer(m_players[m_CurrentPlayerIndex]);
            Move chosenMove = ComputerPlayer.SelectMoveAction(legalMoves);
            MoveChecker(chosenMove);
        }

        private void UpdateWinnerScore(Player i_Winner, Player i_Looser)
        {
            int winnerPoints = CalculatePointsOfPlayer(i_Winner);
            int looserPoints = CalculatePointsOfPlayer(i_Looser);

            i_Winner.AddPoints(winnerPoints - looserPoints);
        }

        private int CalculatePointsOfPlayer(Player i_Player)
        {
            int gamePoints = 0;
            int k_pointsForRegularSoldier = 1;
            int k_pointsForKingSoldier = 4;

            foreach (Soldier soldier in i_Player.Soldiers)
            {
                if (soldier.SoldierType == eSoldierTypes.Regular)
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