﻿using System.Collections.Generic;
using BusinessLogic.Configuration;
using BusinessLogic.GameBoard;
using BusinessLogic.Dtos;
using BusinessLogic.Enums;

namespace BusinessLogic
{
    public class GameManager
    {
        private BoardManager m_BoardManager;
        private List<Player> m_Players;
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
            setPlayers(i_GameConfiguration.PlayerConfigurations);
            m_BoardManager = new BoardManager(i_GameConfiguration.BoardSize, m_Players);
        }

        private void setPlayers(List<PlayerConfiguration> i_playersConfiguration)
        {
            m_Players = new List<Player>();
            m_Players.Add(new Player(i_playersConfiguration[0], ePlayerTitles.PlayerOne));
            m_Players.Add(new Player(i_playersConfiguration[1], ePlayerTitles.PlayerTwo));
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
            Player currentPlayer = m_Players[m_CurrentPlayerIndex];

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
                actionResult = quitCurrentPlayerIfLegal();
            }
            else
            {
                Move move = Move.Parse(i_Action);

                if (move != null)
                {
                    actionResult = moveChecker(move);
                }
                else
                {
                    actionResult = new ActionResult(false, "Invalid command syntax");
                }
            }

            return actionResult;
        }

        private ActionResult moveChecker(Move i_Move)
        {
            bool isDoubleEatMove;
            ActionResult actionResult = m_BoardManager.MoveChecker(i_Move, m_Players[m_CurrentPlayerIndex], out isDoubleEatMove);

            if (actionResult.IsSucceed)
            {
                bool isTurnNeedToBeChanged = !isDoubleEatMove;

                m_LastMove = convertMoveToCheckerMoveInfo(i_Move);
                handleEndOfTurn(isTurnNeedToBeChanged);
            }

            return actionResult;
        }

        private CheckerMoveInfo convertMoveToCheckerMoveInfo(Move i_Move)
        {
            string playerName = getPlayerNameByTitle(m_BoardManager.GetCellByLocation(i_Move.NextLocation).Soldier.Owner);
            string previousMove = i_Move.CurrentLocation.ToString();
            string nextMove = i_Move.NextLocation.ToString();

            return new CheckerMoveInfo(playerName, previousMove, nextMove);
        }

        private string getPlayerNameByTitle(ePlayerTitles i_Title)
        {
            string name = m_Players[0].PlayerName;

            if (m_Players[1].PlayerTitle == i_Title)
            {
                name = m_Players[1].PlayerName;
            }

            return name;
        }

        private ActionResult quitCurrentPlayerIfLegal()
        {
            ActionResult actionResult;

            if (checkIfPlayerCanQuit())
            {
                quitCurrentPlayerFromGame();
                actionResult = new ActionResult(true, string.Empty);
            }
            else
            {
                actionResult = new ActionResult(false, "You cannot quit at this point");
            }

            return actionResult;
        }

        private bool checkIfPlayerCanQuit()
        {
            ePlayerTitles currentPlayerTitle = m_Players[m_CurrentPlayerIndex].PlayerTitle;
            int opponentIndex = getOpponentPlayerIndex();
            bool hasSmallerScore = false;
            bool hasSmallerAmountOfSoldiers = false;

            return false;

            
        }

        private void quitCurrentPlayerFromGame()
        {
            int winnerPlayerIndex = getOpponentPlayerIndex();

            m_GameStatus = eGameStatus.Winner;
            m_LastWinner = m_Players[winnerPlayerIndex];
            //UpdateWinnerScore(m_LastWinner, Plam_CurrentPlayerIndex)
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

        private void changePlayerTurn()
        {
            m_CurrentPlayerIndex = getOpponentPlayerIndex();
        }

        private int getOpponentPlayerIndex()
        {
            return (m_CurrentPlayerIndex + 1) % m_Players.Count;
        }

        private void checkAndUpdateIfGameEnded()
        {
            bool[] playersHasMoves = new bool[m_Players.Count];
            bool hasMovesToDo = false;

            for (int i = 0; i < m_Players.Count; i++)
            {
                if (m_BoardManager.GetLegalMovesOfPlayer(m_Players[i]).Count != 0)
                {
                    playersHasMoves[i] = true;
                    hasMovesToDo = true;
                }
            }

            if (hasMovesToDo)
            {
                if (playersHasMoves[0] && !playersHasMoves[1])
                {
                    m_LastWinner = m_Players[0];
                    updateWinnerScore(m_Players[0], m_Players[1]);
                    m_GameStatus = eGameStatus.Winner;
                }
                else if (!playersHasMoves[0] && playersHasMoves[1])
                {
                    m_LastWinner = m_Players[1];
                    updateWinnerScore(m_Players[1], m_Players[0]);
                    m_GameStatus = eGameStatus.Winner;
                }
            }
            else
            {
                m_GameStatus = eGameStatus.Tie;
            }
        }

        private void handleEndOfTurn(bool i_ChangeTurn)
        {
            checkAndUpdateIfGameEnded();
            if (!IsGameEnded())
            {
                if (i_ChangeTurn)
                {
                    changePlayerTurn();
                }

                if (m_Players[m_CurrentPlayerIndex].PlayerType == ePlayerTypes.Computer)
                {
                    playComputerMove();
                }
            }
        }

        private void playComputerMove()
        {
            List<Move> legalMoves = m_BoardManager.GetLegalMovesOfPlayer(m_Players[m_CurrentPlayerIndex]);
            Move chosenMove = ComputerPlayer.SelectMoveAction(legalMoves);
            moveChecker(chosenMove);
        }

        private void updateWinnerScore(Player i_Winner, Player i_Looser)
        {
            int winnerPoints = calculatePointsOfPlayer(i_Winner);
            int looserPoints = calculatePointsOfPlayer(i_Looser);

            i_Winner.AddPoints(winnerPoints - looserPoints);
        }

        private int calculatePointsOfPlayer(Player i_Player)
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
                else if (soldier.SoldierType == eSoldierTypes.King)
                {
                    gamePoints += k_pointsForKingSoldier;
                }
            }

            return gamePoints;
        }
    }
}