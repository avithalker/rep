using BusinessLogic.Configuration;
using BusinessLogic.Dtos;
using BusinessLogic.GameBoard;

namespace BusinessLogic
{
    partial class GameManager
    {

        public int BoardSize
        {
            get { return 8; } // return the real board size!!!!
        }

        public Cell [,] Board
        {
            get { return null; } // return the real board!!!
        }

        public CheckerMoveInfo LastCheckerMove
        {
            get { return null; } // return the last move! if no last move, will return null
        }

        public void InitializeGame(GameConfiguration i_GameConfiguration)
        {

        }

        public void StartGame()
        {

        }

        public bool IsGameEnded()
        {
            return false;
        }

        public PlayerInfo GetCurrentPlayerTurn()
        {
            return new PlayerInfo(); //here need to return the current player that need to play! fill the player info with the data!
        }

        public ActionResult HandlePlayerAction(string i_Action) // handle player move/Quit game
        {
            return new ActionResult(true, string.Empty); // here need to return if the action succeeded or not. if not, fill the message.
        }

        public GameSummery GetGameSummery()
        {
            return new GameSummery(); // here need to return all the end game info like the winner name, score, game state(TIE/WINNER)
        }
    }
}
