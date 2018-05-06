using System;
using BusinessLogic;
using BusinessLogic.GameBoard;
using BusinessLogic.Enums;
using Ex02.ConsoleUtils;
using BusinessLogic.Dtos;

namespace CheckersApp
{
    public static class UIManager
    {
        public static void CleanScreen()
        {
            Screen.Clear();
        }

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
            }
            while (!isNameValid);

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
                if (!isInputValid || !GlobalDefines.Rs_AllowedBoardSizes.Contains(boardSize))
                {
                    isSizeValid = false;
                    Console.WriteLine("Invalid board size!. try again.");
                }
            }
            while (!isSizeValid);

            return boardSize;
        }

        public static bool IsGameRestartRequired()
        {
            bool isInputValid;
            char answer;

            do
            {
                Console.WriteLine("Do you want to restart the game (Y/N)? ");
                isInputValid = char.TryParse(Console.ReadLine(), out answer);
                if (isInputValid)
                {
                    if (answer != 'Y' && answer != 'N')
                    {
                        isInputValid = false;
                    }
                }

                if (!isInputValid)
                {
                    Console.WriteLine("Invalid input was entered. Try again.");
                }
            }
            while (!isInputValid);

            return answer == 'Y';
        }

        public static eGameModes GetGameMode()
        {
            int gameModeInput;
            bool isGameModeValid;
            bool isInputValid;

            do
            {
                isGameModeValid = true;
                Console.WriteLine("Enter the game mode. {0}- for {1}, {2}- for {3}:", (int)eGameModes.OnePlayerGame, eGameModes.OnePlayerGame, (int)eGameModes.TwoPlayersGame, eGameModes.TwoPlayersGame);
                isInputValid = int.TryParse(Console.ReadLine(), out gameModeInput);
                if (!isInputValid || (gameModeInput != (int)eGameModes.OnePlayerGame && gameModeInput != (int)eGameModes.TwoPlayersGame))
                {
                    Console.WriteLine("Invalid game mode was entered! try again.");
                    isGameModeValid = false;
                }
            }
            while (!isGameModeValid);

            return (eGameModes)gameModeInput;
        }

        public static string GetPlayerMove(string i_PlayerName)
        {
            string playerMove;

            Console.WriteLine("{0}, please enter your next move:", i_PlayerName);
            playerMove = Console.ReadLine();

            return playerMove;
        }

        public static void PrintLastMove(CheckerMoveInfo i_LastMove)
        {
            Console.WriteLine("{0}'s move was: {1}>{2}", i_LastMove.PlayerName, i_LastMove.PreviousCell, i_LastMove.CurrentCell);
        }

        public static void PrintPlayerTurnAnnouncment(string i_PlayerName, char i_PlayerSign)
        {
            Console.WriteLine("{0}'s turn! ({1})", i_PlayerName, i_PlayerSign);
        }

        public static void PrintEndGameAnnouncment(GameSummery i_GameSummery)
        {
            Console.WriteLine("The game was ended");
            switch (i_GameSummery.EndGameState)
            {
                case eGameStatus.Tie:
                    {
                        Console.WriteLine("There is a Tie between the players");
                    }

                    break;
                case eGameStatus.Winner:
                    {
                        Console.WriteLine("The Winner is:{0} with score of:{1}", i_GameSummery.WinnerName, i_GameSummery.Score);
                    }

                    break;
            }
        }

        public static void PrintGeneralAnnouncment(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        public static void PrintGameBoard(Cell[,] i_GameBoard, int i_BoardSize)
        {
            char currentRowSign = 'a';
            int k_RowsPerCell = 2;
            int rowIndex = 0;

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
                        PrintCell(i_GameBoard[rowIndex, j], isLastCellInRow);
                    }

                    rowIndex++;
                    Console.WriteLine();
                }
            }

            PrintRowDelimiterLine(i_BoardSize);
        }

        private static void PrintColumnHeaders(int i_BoardSize)
        {
            char currentColumnSign = 'A';

            Console.Write("  ");
            for (int i = 0; i < i_BoardSize; i++)
            {
                Console.Write(" {0}  ", currentColumnSign);
                currentColumnSign++;
            }

            Console.WriteLine();
        }

        private static void PrintRowDelimiterLine(int i_BoardSize)
        {
            char k_DelimiterSign = '=';
            int k_SignPerCell = 4;
            int k_signInRow = (i_BoardSize * k_SignPerCell) + 1;

            for (int i = 0; i < k_signInRow; i++)
            {
                Console.Write("{0}", k_DelimiterSign);
            }

            Console.WriteLine();
        }

        private static void PrintCell(Cell i_Cell, bool i_IsLastInRow)
        {
            char k_CellDelimiter = '|';
            char cellContent;

            if (i_Cell.IsCellEmpty())
            {
                cellContent = ' ';
            }
            else
            {
                cellContent = GlobalDefines.GetSoldierSign(i_Cell.Soldier.Owner, i_Cell.Soldier.SoldierType);
            }

            if (!i_IsLastInRow)
            {
                Console.Write("{0} {1} ", k_CellDelimiter, cellContent);
            }
            else
            {
                Console.Write("{0} {1} {0}", k_CellDelimiter, cellContent);
            }
        }
    }
}