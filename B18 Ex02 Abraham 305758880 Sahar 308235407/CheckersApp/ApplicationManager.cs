using BusinessLogic;
using BusinessLogic.Configuration;
using BusinessLogic.Dtos;
using BusinessLogic.Enums;

namespace CheckersApp
{
    public class ApplicationManager
    {
        private GameManager m_GameManager;

        public ApplicationManager()
        {
            m_GameManager = new GameManager();
        }

        public void Run()
        {
            bool restartGame = true;

            initializeGame();
            while (restartGame)
            {
                startGame();
                restartGame = endGame();
            }

            endRun();
        }

        private void endRun()
        {
            UIManager.PrintGeneralAnnouncment("Thank you for playing. the game was ended. bye bye!");
        }

        private void initializeGame()
        {
            int currentPlayer = 1;
            GameConfiguration gameConfiguration = new GameConfiguration();
            PlayerConfiguration mainPlayerConfiguration = new PlayerConfiguration();

            mainPlayerConfiguration.PlayerName = UIManager.GetPlayerName(currentPlayer);
            mainPlayerConfiguration.PlayerType = ePlayerTypes.Human;
            gameConfiguration.AddPlayerConfiguration(mainPlayerConfiguration);
            gameConfiguration.BoardSize = UIManager.GetBoardSize();
            gameConfiguration.GameMode = UIManager.GetGameMode();
            if (gameConfiguration.GameMode == eGameModes.TwoPlayersGame)
            {
                PlayerConfiguration secondaryPlayerConfiguration = new PlayerConfiguration();

                currentPlayer++;
                secondaryPlayerConfiguration.PlayerName = UIManager.GetPlayerName(currentPlayer);
                secondaryPlayerConfiguration.PlayerType = ePlayerTypes.Human;
                gameConfiguration.AddPlayerConfiguration(secondaryPlayerConfiguration);
            }

            m_GameManager.InitializeGame(gameConfiguration);
        }

        private void startGame()
        {
            m_GameManager.StartGame();
            handleGameLoop();
        }
        
        private bool endGame()
        {
            bool isRestartRequired;

            UIManager.PrintEndGameAnnouncment(m_GameManager.GetGameSummery());
            isRestartRequired = UIManager.IsGameRestartRequired();
            return isRestartRequired;
        }

        private void handleGameLoop()
        {
            PlayerInfo currentPlayer = null;

            while (!m_GameManager.IsGameEnded())
            {
                showGameView();
                currentPlayer = m_GameManager.GetCurrentPlayerTurn();
                UIManager.PrintPlayerTurnAnnouncment(currentPlayer.PlayerName, currentPlayer.PlayerSign);
                handlePlayerMove(currentPlayer);
            }

            showGameView();
        }

        private void handlePlayerMove(PlayerInfo i_CurrentPlayer)
        {
            ActionResult actionResult;
            string playerAction;
            do
            {
                playerAction = UIManager.GetPlayerMove(i_CurrentPlayer.PlayerName);
                actionResult = m_GameManager.HandlePlayerAction(playerAction);
                if(!actionResult.IsSucceed)
                {
                    UIManager.PrintGeneralAnnouncment(actionResult.Message);
                }
            }
            while (!actionResult.IsSucceed);
        }

        private void showGameView()
        {
            UIManager.CleanScreen();
            UIManager.PrintGameBoard(m_GameManager.Board, m_GameManager.BoardSize);
            if (m_GameManager.LastCheckerMove != null)
            {
                UIManager.PrintLastMove(m_GameManager.LastCheckerMove);
            }
        }
    }
}
