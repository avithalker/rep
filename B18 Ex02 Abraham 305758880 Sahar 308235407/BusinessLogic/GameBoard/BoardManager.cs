using System;
using System.Collections.Generic;
using BusinessLogic.Enums;
using BusinessLogic.Dtos;

namespace BusinessLogic.GameBoard
{
    public class BoardManager
    {
        private const int k_SpacesBetweenPlayers = 2;
        private readonly int k_NumRowsForPlayer;
        private List<Player> m_Players;
        private Cell[,] m_Board;
        private int m_BoardSize;
        private bool m_StartRowWithSoldier;
        private List<Move> m_DoubleEatMoves;

        public BoardManager(int i_size, List<Player> players)
        {
            m_BoardSize = i_size;
            k_NumRowsForPlayer = (i_size - 2) / 2;
            m_Players = players;
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        public Cell[,] Board
        {
            get { return m_Board; }
            set { m_Board = value; }
        }

        public void InitializeBoardsData()
        {
            m_DoubleEatMoves = new List<Move>();
            m_Board = new Cell[m_BoardSize, m_BoardSize];
            foreach(Player player in m_Players)
            {
                player.RemoveAllSoldiers();
            }

            initializeSoldiersLocationInBoard(0, ePlayerTitles.PlayerOne, false);
            initializeEmptyCells(k_NumRowsForPlayer);
            initializeSoldiersLocationInBoard(k_NumRowsForPlayer + 2, ePlayerTitles.PlayerTwo, m_StartRowWithSoldier);
            setCellsStatus();
        }

        public ActionResult MoveChecker(Move i_Move, Player i_CurrentPlayer, out bool o_IsDoubleEatMove)
        {
            ActionResult actionResult;
            List<Move> legalMoves = GetLegalMovesOfPlayer(i_CurrentPlayer);

            o_IsDoubleEatMove = false;
            if (isExistInMovesArray(legalMoves, i_Move))
            {
                makeMove(i_Move, out o_IsDoubleEatMove);
                actionResult = new ActionResult(true, string.Empty);
            }
            else
            {
                actionResult = new ActionResult(false, "Invalid Move");
            }

            return actionResult;
        }

        public List<Move> GetLegalMovesOfPlayer(Player i_CurrentPlayer)
        {
            List<Move> freeMoves = new List<Move>();
            List<Move> eatMoves = new List<Move>();
            List<Move> finalMoveList = null;

            // if we are not in double eat move flow then find other legal moves
            if (m_DoubleEatMoves.Count == 0)
            {
                foreach (Soldier soldier in i_CurrentPlayer.Soldiers)
                {
                    List<Move> soldierEatMoves = getLegalEatMovesOfSoldier(soldier);

                    if (soldierEatMoves.Count != 0)
                    {
                        eatMoves.AddRange(soldierEatMoves);
                    }
                    else
                    {
                        freeMoves.AddRange(getLegalFreeMovesOfSoldier(soldier));
                    }
                }
            }

            if (m_DoubleEatMoves.Count != 0)
            {
                finalMoveList = m_DoubleEatMoves;
            }
            else if (eatMoves.Count != 0)
            {
                finalMoveList = eatMoves;
            }
            else
            {
                finalMoveList = freeMoves;
            }

            return finalMoveList;
        }

        public Cell GetCellByLocation(Location i_Location)
        {
            return m_Board[i_Location.Row, i_Location.Col];
        }

        private void initializeEmptyCells(int i_StartRow)
        {
            for (int i = 0; i < k_SpacesBetweenPlayers; i++)
            {
                for (int j = 0; j < m_Board.GetLength(1); j++)
                {
                    m_Board[i_StartRow, j] = new Cell();
                }

                i_StartRow++;
            }
        }

        private void initializeSoldiersLocationInBoard(int i_Row, ePlayerTitles i_PlayerTitle, bool i_SetSoldierInStartOfRow)
        {
            bool setSoldierInCell = false;

            for (int i = 0; i < k_NumRowsForPlayer; i++)
            {
                setSoldierInCell = i_SetSoldierInStartOfRow;
                for (int j = 0; j < m_Board.GetLength(1); j++)
                {
                    m_Board[i_Row, j] = new Cell();
                    if (setSoldierInCell)
                    {
                        m_Board[i_Row, j].Soldier = createNewSoldier(i_Row, j, i_PlayerTitle);
                        setSoldierInCell = false;
                    }
                    else
                    {
                        setSoldierInCell = true;
                    }
                }

                i_SetSoldierInStartOfRow = !i_SetSoldierInStartOfRow;
                i_Row++;
            }

            m_StartRowWithSoldier = i_SetSoldierInStartOfRow;
        }

        private void setCellsStatus()
        {
            bool isEnabled = false;

            foreach (Cell cell in m_Board)
            {
                cell.IsEnabled = isEnabled;
                isEnabled = !isEnabled;
            }
        }

        private Soldier createNewSoldier(int i_Row, int i_Col, ePlayerTitles i_PlayerTitle)
        {
            Soldier soldier = new Soldier(new Location(i_Row, i_Col), eSoldierTypes.Regular, i_PlayerTitle);
            getPlayerByTitle(i_PlayerTitle).AddSoldier(soldier);

            return soldier;
        }

        private void makeMove(Move i_Move, out bool o_IsDoubleEatMove)
        {
            Cell nextLocationCell = GetCellByLocation(i_Move.NextLocation);
            Cell currentLocationCell = GetCellByLocation(i_Move.CurrentLocation);
            Soldier currentSoldier = currentLocationCell.Soldier;

            nextLocationCell.Soldier = currentLocationCell.Soldier; // put the soldier in the nextLocation
            currentLocationCell.Soldier = null; // make the cell empty
            currentSoldier.Location = i_Move.NextLocation; // update Soldier's location
            checkAndUpdateToKing(currentSoldier);
            o_IsDoubleEatMove = false;
            if (isEatMove(i_Move))
            {
                eatSoldier(i_Move);
                m_DoubleEatMoves = getLegalEatMovesOfSoldier(currentSoldier);
                if (m_DoubleEatMoves.Count != 0)
                {
                    o_IsDoubleEatMove = true;
                }
            }
            else
            {
                m_DoubleEatMoves.Clear();
            }
        }

        private bool isEatMove(Move i_Move)
        {
            return Math.Abs(i_Move.CurrentLocation.Col - i_Move.NextLocation.Col) > 1;
        }

        private void eatSoldier(Move i_EatMove)
        {
            int colOfSoldier = Math.Min(i_EatMove.CurrentLocation.Col, i_EatMove.NextLocation.Col) + 1;
            int rowOfSoldier = Math.Min(i_EatMove.CurrentLocation.Row, i_EatMove.NextLocation.Row) + 1;
            Location eatenSoldierLocation = new Location(rowOfSoldier, colOfSoldier);
            Soldier soldierToRemove = GetCellByLocation(eatenSoldierLocation).Soldier;

            getPlayerByTitle(soldierToRemove.Owner).RemoveSoldierFromList(soldierToRemove);
            GetCellByLocation(eatenSoldierLocation).Soldier = null;
        }

        private List<Move> getLegalFreeMovesOfSoldier(Soldier i_Soldier)
        {
            List<Move> legalMoves = new List<Move>();
            List<Location> possibleNextLocations = getNextPossibleLocationsOfSoldier(i_Soldier);

            foreach (Location location in possibleNextLocations)
            {
                if (GetCellByLocation(location).IsCellEmpty())
                {
                    legalMoves.Add(new Move(i_Soldier.Location, location));
                }
            }

            return legalMoves;
        }

        private List<Move> getLegalEatMovesOfSoldier(Soldier i_Soldier)
        {
            List<Move> finalEatMoves = new List<Move>();
            eVertical verticalDirection = getVerticalDirection(i_Soldier.Owner);

            addEatMoveIfExist(i_Soldier, verticalDirection, eHorizontal.Right, ref finalEatMoves);
            addEatMoveIfExist(i_Soldier, verticalDirection, eHorizontal.Left, ref finalEatMoves);

            if (i_Soldier.SoldierType == eSoldierTypes.King)
            {
                verticalDirection = (eVertical)(((int)verticalDirection) * -1); // flip the vertical direction
                addEatMoveIfExist(i_Soldier, verticalDirection, eHorizontal.Right, ref finalEatMoves);
                addEatMoveIfExist(i_Soldier, verticalDirection, eHorizontal.Left, ref finalEatMoves);
            }

            return finalEatMoves;
        }

        private void addEatMoveIfExist(Soldier i_Soldier, eVertical i_VerticalDirection, eHorizontal i_HorizontalDirection, ref List<Move> io_EatMoves)
        {
            Move eatMove = getSingleEatMoveOfSoldier(i_Soldier, i_VerticalDirection, i_HorizontalDirection);

            if (eatMove != null)
            {
                io_EatMoves.Add(eatMove);
            }
        }

        private Move getSingleEatMoveOfSoldier(Soldier i_Soldier, eVertical i_VerticalDirection, eHorizontal i_HorizontalDirection)
        {
            Location currentLocation = i_Soldier.Location;
            Location opponentSoldierLocation = new Location(currentLocation.Row + (int)i_VerticalDirection, currentLocation.Col + (int)i_HorizontalDirection);
            Move eatMove = null;

            if (locationExistInBoard(opponentSoldierLocation))
            {
                Cell cell = GetCellByLocation(opponentSoldierLocation);

                if (!cell.IsCellEmpty() && cell.Soldier.Owner != i_Soldier.Owner)
                {
                    Location jumppingLocation = new Location(opponentSoldierLocation.Row + (int)i_VerticalDirection, opponentSoldierLocation.Col + (int)i_HorizontalDirection);

                    if (locationExistInBoard(jumppingLocation) && GetCellByLocation(jumppingLocation).IsCellEmpty())
                    {
                        eatMove = new Move(currentLocation, jumppingLocation);
                    }
                }
            }

            return eatMove;
        }

        private List<Location> getNextPossibleLocationsOfSoldier(Soldier i_Soldier)
        {
            List<Location> locations = new List<Location>();
            eVertical verticalDirection = getVerticalDirection(i_Soldier.Owner);

            addNextLocationIfPossible(i_Soldier, verticalDirection, eHorizontal.Left, ref locations);
            addNextLocationIfPossible(i_Soldier, verticalDirection, eHorizontal.Right, ref locations);
            if (i_Soldier.SoldierType == eSoldierTypes.King)
            {
                verticalDirection = (eVertical)(((int)verticalDirection) * -1); // flip the vertical direction
                addNextLocationIfPossible(i_Soldier, verticalDirection, eHorizontal.Left, ref locations);
                addNextLocationIfPossible(i_Soldier, verticalDirection, eHorizontal.Right, ref locations);
            }

            return locations;
        }

        private void addNextLocationIfPossible(Soldier i_Soldier, eVertical i_VerticalDirection, eHorizontal i_HorizontalDirection, ref List<Location> io_Locations)
        {
            Location nextLocation = new Location(i_Soldier.Location.Row + (int)i_VerticalDirection, i_Soldier.Location.Col + (int)i_HorizontalDirection);
            if (locationExistInBoard(nextLocation))
            {
                io_Locations.Add(nextLocation);
            }
        }

        private eVertical getVerticalDirection(ePlayerTitles i_PlayerTitle)
        {
            eVertical verticalDirection;

            if (i_PlayerTitle == ePlayerTitles.PlayerOne)
            {
                verticalDirection = eVertical.Down;
            }
            else
            {
                verticalDirection = eVertical.Up;
            }

            return verticalDirection;
        }

        private void checkAndUpdateToKing(Soldier i_Soldier)
        {
            if ((i_Soldier.Owner == ePlayerTitles.PlayerOne && i_Soldier.Location.Row == BoardSize - 1) ||
                (i_Soldier.Owner == ePlayerTitles.PlayerTwo && i_Soldier.Location.Row == 0))
            {
                i_Soldier.PromoteSoldier();
            }
        }

        private bool locationExistInBoard(Location i_Location)
        {
            bool isInBoard = true;

            if (i_Location.Row >= m_BoardSize || i_Location.Col >= m_BoardSize || i_Location.Row < 0 || i_Location.Col < 0)
            {
                isInBoard = false;
            }

            return isInBoard;
        }

        private bool isExistInMovesArray(List<Move> i_MoveArray, Move i_Move)
        {
            foreach (Move possibleMove in i_MoveArray)
            {
                if (possibleMove.AreEqual(i_Move))
                {
                    return true;
                }
            }

            return false;
        }

        private Player getPlayerByTitle(ePlayerTitles i_PlayerTitle)
        {
            Player player = null;

            if (m_Players[0].PlayerTitle == i_PlayerTitle)
            {
                player = m_Players[0];
            }
            else
            {
                player = m_Players[1];
            }

            return player;
        }
    }
}
