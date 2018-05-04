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

        public void InitializeBoardsData()
        {
            initializeSoldiersLocationInBoard(0, PlayerTitles.ePlayerTitles.PlayerOne);
            initializeEmptyCells(NUM_ROWS_FOR_PLAYER);
            initializeSoldiersLocationInBoard(NUM_ROWS_FOR_PLAYER+2, PlayerTitles.ePlayerTitles.PlayerTwo);
        }

        private void initializeEmptyCells(int i_startRow)
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

        private void initializeSoldiersLocationInBoard(int i_row, PlayerTitles.ePlayerTitles i_playerTitle)
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
            Soldier k_soldier = new Soldier(new Location(i_row, i_col), SoldierTypes.eSoldierTypes.Regular, i_playerTitle);
            GetPlayerByTitle(i_playerTitle).AddSoldier(k_soldier);

            return k_soldier;
        }

        private Player GetPlayerByTitle(PlayerTitles.ePlayerTitles i_playerTitle)
        {
            Player k_player = null;

            if(m_Players[0].PlayerTitle == i_playerTitle)
            {
                k_player = m_Players[0];
            }
            else
            {
                k_player = m_Players[1];
            }

            return k_player;   
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

        public ActionResult SetCheckersMove(Move i_Move, Player i_CurrentPlayer)
        { 
            ActionResult k_actionResult;
            List<Move> k_legalMoves = GetLegalMovesOfPlayer(i_CurrentPlayer); //change to title parameter

            if(IsExistInMovesArray(k_legalMoves, i_Move))
            {
                SetMoveInBoard(i_Move);
                k_actionResult = new ActionResult(true, string.Empty);
            }
            else
            {
                k_actionResult = new ActionResult(false, "Invalid Move");
            }

            return k_actionResult;
        }

        public void SetMoveInBoard(Move i_Move)
        {
        }

        private List<Move> GetLegalMovesOfPlayer(Player i_CurrentPlayer)
        {
            List<Move> k_LegalMoves = new List<Move>();
            List<Move> k_LegalEatMoves = new List<Move>();
            List<Move> k_FinalMoveList = null;

            foreach(Soldier soldier in i_CurrentPlayer.Soldiers)
            {
                List<Move> k_LegalSoldierEatMoves = GetLegalEatMovesOfSoldier(soldier);

                if ( k_LegalSoldierEatMoves == null)
                {
                   k_LegalMoves.AddRange(GetLegalMovesOfSoldier(soldier));
                   
                }
                else
                {
                    k_LegalEatMoves.AddRange(k_LegalSoldierEatMoves);
                }
            }

            if(k_LegalEatMoves == null)
            {
                k_FinalMoveList = k_LegalMoves;
            }
            else
            {
                k_FinalMoveList = k_LegalEatMoves;
            }

            return k_FinalMoveList;
        }

        private List<Move> GetLegalEatMovesOfSoldier(Soldier i_soldier)
        {
            Location k_CurrentLocation = i_soldier.Location;
            List<Location> k_NextPossibleLocationsInBoard = GetNextPossibleLocationsInBoard(i_soldier);
            List<Move> k_FinalEatMoves = new List<Move>();

            foreach (Location location in k_NextPossibleLocationsInBoard)
            {
                if (!Board[location.Row, location.Col].IsCellEmpty())
                {
                    if(Board[location.Row, location.Col].Soldier.Owner != i_soldier.Owner)
                    {
                        if (i_soldier.Owner == PlayerTitles.ePlayerTitles.PlayerOne)
                        {
                            if (location.Col > i_soldier.Location.Col)
                            {
                                if (LocationExistInBoard(new Location(location.Col + 1, location.Row + 1)) && Board[location.Row + 1, location.Row + 1].IsCellEmpty())
                                {
                                    k_FinalEatMoves.Add(new Move(i_soldier.Location, new Location(location.Row + 1, location.Col + 1)));
                                }
                            }

                            else
                            {
                                if (LocationExistInBoard(new Location(location.Col - 1, location.Row + 1)) && Board[location.Row - 1, location.Row + 1].IsCellEmpty())
                                {
                                    k_FinalEatMoves.Add(new Move(i_soldier.Location, new Location(location.Row + 1, location.Col - 1)));
                                }
                            }
                        }

                        else
                        {
                            if (location.Col > i_soldier.Location.Col)
                            {
                                if (LocationExistInBoard(new Location(location.Col + 1, location.Row - 1)) && Board[location.Row + 1, location.Row + 1].IsCellEmpty())
                                {
                                    k_FinalEatMoves.Add(new Move(i_soldier.Location, new Location(location.Row - 1, location.Col + 1)));
                                }
                            }

                            else
                            {
                                if (LocationExistInBoard(new Location(location.Col - 1, location.Row - 1)) && Board[location.Row - 1, location.Row + 1].IsCellEmpty())
                                {
                                    k_FinalEatMoves.Add(new Move(i_soldier.Location, new Location(location.Row - 1, location.Col - 1)));
                                }
                            }
                        }
                    }
                }
            }

            return k_FinalEatMoves;
        }

        private List<Location> GetNextPossibleLocationsInBoard(Soldier i_Soldier)
        {
            List<Location> k_Locations = new List<Location>();

            if (i_Soldier.Owner == PlayerTitles.ePlayerTitles.PlayerOne)
            {
                if (LocationExistInBoard(new Location(i_Soldier.Location.Col - 1, i_Soldier.Location.Row + 1))) //left diagonal
                {
                    k_Locations.Add(new Location(i_Soldier.Location.Col - 1, i_Soldier.Location.Row + 1));
                }
                if (LocationExistInBoard(new Location(i_Soldier.Location.Col + 1, i_Soldier.Location.Row + 1)))
                {
                    k_Locations.Add(new Location(i_Soldier.Location.Col - 1, i_Soldier.Location.Row + 1));
                }
            }

            else
            {
                if (LocationExistInBoard(new Location(i_Soldier.Location.Col + 1, i_Soldier.Location.Row - 1))) //left diagonal
                {
                    k_Locations.Add(new Location(i_Soldier.Location.Col + 1, i_Soldier.Location.Row - 1));
                }
                if (LocationExistInBoard(new Location(i_Soldier.Location.Col - 1, i_Soldier.Location.Row - 1)))
                {
                    k_Locations.Add(new Location(i_Soldier.Location.Col - 1, i_Soldier.Location.Row - 1));
                }
            }

            return k_Locations;
        }

        private bool LocationExistInBoard(Location i_Location)
        {
            bool k_isInBoard = true; 

            if(i_Location.Row >= m_BoardSize || i_Location.Col >= m_BoardSize)
            {
                k_isInBoard = false;
            }

            return k_isInBoard;
        }

        private List<Move> GetLegalMovesOfSoldier(Soldier i_Soldier)
        {
            List<Move> k_LegalMoves = new List<Move>();
            List<Location> k_PossibleNextLocations = GetNextPossibleLocationsInBoard(i_Soldier);

            foreach(Location location in k_PossibleNextLocations)
            {
                if(Board[location.Row, location.Col].IsCellEmpty())
                {
                    k_LegalMoves.Add(new Move(i_Soldier.Location, location));
                }
            }

            return k_LegalMoves;
        }

        private bool IsExistInMovesArray(List<Move> i_MoveArray, Move i_Move)
        {
            return false;
        }

        /*private void CheckForEatMoves(List<Move> i_moves)
        {
            bool k_thereIsAnEatMove = false; 
            foreach(Move move in i_moves)
            {
                if(move.IsSoldierWasEaten())
                {
                    k_thereIsAnEatMove = true;
                }
            }

            if(k_thereIsAnEatMove)
            {
                foreach(Move move in i_moves)
                {
                    if(!move.IsSoldierWasEaten())
                    {
                        i_moves.Remove(move);
                    }
                }
            }
        }
        */
    }
}
