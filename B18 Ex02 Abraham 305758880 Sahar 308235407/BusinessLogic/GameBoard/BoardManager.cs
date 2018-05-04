using System.Collections.Generic;
using BusinessLogic.GameBoard;
using BusinessLogic.Enums;
using BusinessLogic.Dtos;
using System.Linq;

namespace BusinessLogic.GameBoard
{
    public class BoardManager
    {
        private const int SPACES_BETWEEN_PLAYERS = 2;
        private readonly int NUM_ROWS_FOR_PLAYER;
        private List<Player> m_Players;
        private Cell[,] m_Board;
        private int m_BoardSize;

        public BoardManager(int i_size, List<Player> players)
        {
            m_Board = new Cell[i_size, i_size];  //board[row][col]
            m_BoardSize = i_size;
            NUM_ROWS_FOR_PLAYER = (i_size - 2) / 2;
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
            InitializeSoldiersLocationInBoard(0, PlayerTitles.ePlayerTitles.PlayerOne);
            InitializeEmptyCells(NUM_ROWS_FOR_PLAYER);
            InitializeSoldiersLocationInBoard(NUM_ROWS_FOR_PLAYER+2, PlayerTitles.ePlayerTitles.PlayerTwo);
        }

        private void InitializeEmptyCells(int i_startRow)
        {
            for (int i = 0; i < SPACES_BETWEEN_PLAYERS; i++)
            {
                for(int j = 0; j < m_Board.GetLength(1); j++)
                {
                    m_Board[i_startRow, j] = new Cell();
                }

                i_startRow++;
            }
        }

        private void InitializeSoldiersLocationInBoard(int i_row, PlayerTitles.ePlayerTitles i_playerTitle)
        {
            bool setSoldierInCell = false;
            bool setSoldierInStartOfRow = false;

            if (i_playerTitle == PlayerTitles.ePlayerTitles.PlayerTwo)
            {
                setSoldierInStartOfRow = true;
            }

            for (int i = 0; i < NUM_ROWS_FOR_PLAYER; i++)
            {
                setSoldierInCell = setSoldierInStartOfRow;
                for (int j = 0; j < m_Board.GetLength(1); j++)
                {
                    m_Board[i_row, j] = new Cell();
                    if (setSoldierInCell)
                    {
                        m_Board[i_row, j].Soldier = CreateNewSoldier(i,j,i_playerTitle);
                        setSoldierInCell = false;
                    }
                    else
                    {
                        setSoldierInCell = true;
                    }
                }

                setSoldierInStartOfRow = !setSoldierInStartOfRow;
                i_row++;
            }
        }

        private Soldier CreateNewSoldier(int i_row, int i_col, PlayerTitles.ePlayerTitles i_playerTitle)
        {
            Soldier soldier = new Soldier(new Location(i_row, i_col), SoldierTypes.eSoldierTypes.Regular, i_playerTitle);
            GetPlayerByTitle(i_playerTitle).AddSoldier(soldier);

            return soldier;
        }

        public ActionResult MoveChecker(Move i_Move, Player i_CurrentPlayer)
        { 
            ActionResult actionResult;
            List<Move> legalMoves = GetLegalMovesOfPlayer(i_CurrentPlayer); 

            if(IsExistInMovesArray(legalMoves, i_Move))
            {
                MakeMove(i_Move);
                actionResult = new ActionResult(true, string.Empty);
            }
            else
            {
                actionResult = new ActionResult(false, "Invalid Move");
            }

            return actionResult;
        }

        public void MakeMove(Move i_Move)
        {
            if(IsEatMove(i_Move))
            {
                Cell nextLocationCell = GetCellByLocation(i_Move.NextLocation);
                Cell currentLocationCell = GetCellByLocation(i_Move.CurrentLocation);
                Soldier eatenSoldier = nextLocationCell.Soldier;
                GetPlayerByTitle(eatenSoldier.Owner).RemoveSoldierFromList(eatenSoldier);
                nextLocationCell.Soldier = currentLocationCell.Soldier;
                currentLocationCell.Soldier = null;
                
            }
        }

        private bool IsEatMove(Move i_Move)
        {
            return true;
        }

        private List<Move> GetLegalMovesOfPlayer(Player i_CurrentPlayer)
        {
            List<Move> freeMoves = new List<Move>();
            List<Move> eatMoves = new List<Move>();
            List<Move> finalMoveList = null;

            foreach(Soldier soldier in i_CurrentPlayer.Soldiers)
            {
                List<Move> soldierEatMoves = GetLegalEatMovesOfSoldier(soldier);

                if (soldierEatMoves.Count != 0)
                {
                    eatMoves.AddRange(soldierEatMoves);
                }
                else
                {
                    freeMoves.AddRange(GetLegalFreeMovesOfSoldier(soldier));
                }
            }

            if(eatMoves.Count != 0)
            {
                finalMoveList = eatMoves;
            }
            else
            {
                finalMoveList = freeMoves;
            }

            return finalMoveList;
        }

        private List<Move> GetLegalFreeMovesOfSoldier(Soldier i_Soldier)
        {
            List<Move> legalMoves = new List<Move>();
            List<Location> possibleNextLocations = GetNextPossibleLocationsOfSoldier(i_Soldier);

            foreach (Location location in possibleNextLocations)
            {
                if (GetCellByLocation(location).IsCellEmpty())
                {
                    legalMoves.Add(new Move(i_Soldier.Location, location));
                }
            }

            return legalMoves;
        }

        private List<Move> GetLegalEatMovesOfSoldier(Soldier i_soldier)
        {
            Move eatMove = null;
            List<Move> finalEatMoves = new List<Move>();
            int rowDeletaDirection = GetRowDeltaDirection(i_soldier.Owner);

            eatMove = GetSingleEatMoveOfSoldier(i_soldier, rowDeletaDirection, 1);
            if(eatMove!=null)
            {
                finalEatMoves.Add(eatMove);
            }

            eatMove = GetSingleEatMoveOfSoldier(i_soldier, rowDeletaDirection, -1);
            if (eatMove != null)
            {
                finalEatMoves.Add(eatMove);
            }

            if (i_soldier.SoldierType == SoldierTypes.eSoldierTypes.King)
            {
                eatMove = GetSingleEatMoveOfSoldier(i_soldier, rowDeletaDirection * -1, 1);
                if (eatMove != null)
                {
                    finalEatMoves.Add(eatMove);
                }

                eatMove = GetSingleEatMoveOfSoldier(i_soldier, rowDeletaDirection * -1, -1);
                if (eatMove != null)
                {
                    finalEatMoves.Add(eatMove);
                }
            }

            return finalEatMoves;
        }

        private Move GetSingleEatMoveOfSoldier(Soldier i_Soldier, int i_rowDeltaDirection, int i_columnDeltaDirection)
        {
            Location currentLocation = i_Soldier.Location;
            Location opponentSoldierLocation = new Location(currentLocation.Row + i_rowDeltaDirection, currentLocation.Col + i_columnDeltaDirection);
            Move eatMove = null;

            if (LocationExistInBoard(opponentSoldierLocation))
            {
                Cell cell = GetCellByLocation(opponentSoldierLocation);

                if (!cell.IsCellEmpty() && cell.Soldier.Owner != i_Soldier.Owner)
                {
                    Location jumppingLocation = new Location(opponentSoldierLocation.Row + i_rowDeltaDirection, opponentSoldierLocation.Col + i_columnDeltaDirection);

                    if (LocationExistInBoard(jumppingLocation) && GetCellByLocation(jumppingLocation).IsCellEmpty())
                    {
                        eatMove = new Move(currentLocation, jumppingLocation);
                    }
                }
            }

            return eatMove;
        }
        
        private List<Location> GetNextPossibleLocationsOfSoldier(Soldier i_Soldier)
        {
            List<Location> locations = new List<Location>();
            Location nextLocation;
            int rowDeltaDirection = GetRowDeltaDirection(i_Soldier.Owner);

            nextLocation = new Location(i_Soldier.Location.Row + rowDeltaDirection, i_Soldier.Location.Col - 1);
            if (LocationExistInBoard(nextLocation))
            {
                locations.Add(nextLocation);
            }

            nextLocation = new Location(i_Soldier.Location.Row + rowDeltaDirection, i_Soldier.Location.Col + 1);
            if (LocationExistInBoard(nextLocation))
            {
                locations.Add(nextLocation);
            }

            if (i_Soldier.SoldierType == SoldierTypes.eSoldierTypes.King)
            {
                nextLocation = new Location(i_Soldier.Location.Row + rowDeltaDirection * -1, i_Soldier.Location.Col - 1);
                if (LocationExistInBoard(nextLocation))
                {
                    locations.Add(nextLocation);
                }

                nextLocation = new Location(i_Soldier.Location.Row + rowDeltaDirection * -1, i_Soldier.Location.Col + 1);
                if (LocationExistInBoard(nextLocation))
                {
                    locations.Add(nextLocation);
                }
            }

            return locations;
        }

        private int GetRowDeltaDirection(PlayerTitles.ePlayerTitles i_PlayerTitle)
        {
            int rowDeltaDirection;

            if (i_PlayerTitle == PlayerTitles.ePlayerTitles.PlayerOne)
            {
                rowDeltaDirection = 1;
            }
            else
            {
                rowDeltaDirection = -1;
            }

            return rowDeltaDirection;
        }

        private bool LocationExistInBoard(Location i_Location)
        {
            bool isInBoard = true;

            if (i_Location.Row >= m_BoardSize || i_Location.Col >= m_BoardSize || i_Location.Row < 0 || i_Location.Col < 0)
            {
                isInBoard = false;
            }

            return isInBoard;
        }

        private bool IsExistInMovesArray(List<Move> i_MoveArray, Move i_Move)
        {
            return false;
        }

        private Cell GetCellByLocation(Location i_Location)
        {
            return m_Board[i_Location.Row, i_Location.Col];
        }

        private Player GetPlayerByTitle(PlayerTitles.ePlayerTitles i_playerTitle)
        {
            Player player = null;

            if (m_Players[0].PlayerTitle == i_playerTitle)
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
