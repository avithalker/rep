using BusinessLogic;
using BusinessLogic.Enums;
using System;

namespace CheckersApp
{
    public static class UIManager
    {
        public static string GetPlayerName(int i_PlayerNumber)
        {
            bool isNameValid;
            string playerName;

            do
            {
                isNameValid = true;
                Console.WriteLine("Enter the name of player number {0}:", i_PlayerNumber);
                playerName = Console.ReadLine();
                if (playerName.Length > GlobalDefines.k_MaxNameLength)
                {
                    isNameValid = false;
                    Console.WriteLine("Invalid name. Max name length is {0}. Try again.", GlobalDefines.k_MaxNameLength);
                }

            } while (!isNameValid);

            return playerName;
        }

        public static int GetBoardSize()
        {
            int boardSize;
            bool isSizeValid;
            bool isInputValid;

            do
            {
                isSizeValid = true;
                Console.WriteLine("Enter the board size:");
                isInputValid = int.TryParse(Console.ReadLine(), out boardSize);
                if (!isInputValid || GlobalDefines.rs_AllowedBoardSizes.Contains(boardSize))
                {
                    isSizeValid = false;
                    Console.WriteLine("Invalid board size!. try again.");
                }
            } while (!isSizeValid);

            return boardSize;
        }

        public static GameModes.eGameModes GetGameMode()
        {
            int gameModeInput;
            bool isGameModeValid;
            bool isInputValid;

            do
            {
                isGameModeValid = true;
                Console.WriteLine("Enter the game mode. {0}- for {1}, {2}- for {3}:", (int)GameModes.eGameModes.OnePlayerGame, GameModes.eGameModes.OnePlayerGame, (int)GameModes.eGameModes.TwoPlayersGame, GameModes.eGameModes.TwoPlayersGame);
                isInputValid = int.TryParse(Console.ReadLine(), out gameModeInput);
                if (!isInputValid || (gameModeInput != (int)GameModes.eGameModes.OnePlayerGame && gameModeInput != (int)GameModes.eGameModes.TwoPlayersGame))
                {
                    Console.WriteLine("Invalid game mode was entered! try again.");
                    isGameModeValid = false;
                }
            } while (!isGameModeValid);

            return (GameModes.eGameModes)gameModeInput;
        }

        public static string GetPlayerMove(string i_PlayerName)
        {
            string playerMove;

            Console.WriteLine("{0}, please enter your next move:");
            playerMove = Console.ReadLine();

            return playerMove;
        }

        public void PrintGameBoard(Cell [,] i_GameBoard, int i_BoardSize)
        {
            char currentRowSign = 'a';
            int k_RowsPerCell = 2;

            PrintColumnHeaders(i_BoardSize);
            for (int i = 0; i < i_BoardSize * k_RowsPerCell; i++) 
            {
                if (i % 2 == 0) 
                {
                    Console.Write(" ");
                    PrintRowDelimiterLine(i_BoardSize);
                }
                else
                {
                    Console.Write("{0}", currentRowSign);
                    currentRowSign++;
                    for (int j = 0; j < i_BoardSize; j++)
                    {
                        bool isLastCellInRow = j == i_BoardSize - 1;
                        PrintCell(i_GameBoard[i, j], isLastCellInRow);
                    }

                    Console.WriteLine();
                }
            }

            PrintRowDelimiterLine(i_BoardSize);
        }

        private static void PrintColumnHeaders(int i_BoardSize)
        {
            char currentColumnSign = 'A';

            Console.Write(" ");
            for (int i = 0; i < i_BoardSize; i++)
            {
                Console.Write("  {0}  ", currentColumnSign);
                currentColumnSign++;
            }

            Console.WriteLine();
        }

        private static void PrintRowDelimiterLine(int i_BoardSize)
        {
            char k_DelimiterSign = '=';
            int k_SignPerCell = 5;
            int signInRow = i_BoardSize * k_SignPerCell;

            for(int i = 0; i < signInRow; i++)
            {
                Console.Write("{0}", k_DelimiterSign);
            }

            Console.WriteLine();
        }

        private static void PrintCell(Cell i_Cell,bool i_IsLastInRow)
        {
            char k_CellDelimiter = '|';
            if (!i_IsLastInRow)
            {
                Console.Write("{0} {1} ",k_CellDelimiter,"cell content");
            }
            else
            {
                Console.Write("{0} {1} {0}", k_CellDelimiter, "cell content");
            }
        }
    }
}

