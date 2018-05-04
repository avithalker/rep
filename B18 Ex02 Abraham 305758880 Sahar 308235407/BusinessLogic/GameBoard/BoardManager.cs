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

        public ActionResult SetCheckersMove(string i_Action, Player i_CurrentPlayer)
        { 
            Move k_desiredMove = new Move(i_Action);
            ActionResult k_actionResult;
            List<Move> k_leagelMoves = GetLeagalMovesOfPlayer(i_CurrentPlayer); //change to title parameter

            if(IsExistInMovesArray(k_leagelMoves, k_desiredMove))
            {
                SetMoveInBoard(k_desiredMove);
                k_actionResult = new ActionResult(true, string.Empty);
            }
            else
            {
                k_actionResult = new ActionResult(false, "Invalid Move");  //need to create 2 differenr error-types....
            }

            return k_actionResult;
        }

        public void SetMoveInBoard(Move i_Move)
        {
        }

        private List<Move> GetLeagalMovesOfPlayer(Player i_CurrentPlayer)
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
            return null;
        }

        private List<Move> GetLegalMovesOfSoldier(Soldier i_Soldier)
        {
            /*Cell[] k_cells = GetCellsToMoveByPlayer(i_Soldier);
            bool k_HasEatMove = false;

            if(ThereIsASoldierToEat(k_cells))
            {
                foreach(Cell cell in k_cells)
                {
                    if(cell.)
                }
            }
          */

            return null;
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
