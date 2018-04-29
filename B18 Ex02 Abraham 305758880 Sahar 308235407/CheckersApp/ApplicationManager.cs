using BusinessLogic.Configuration;
using BusinessLogic.Enums;

namespace CheckersApp
{
    public class ApplicationManager
    {
        
        public void InitializeGame()
        {
            int currentPlayer = 1;
            GameConfiguration gameConfiguration = new GameConfiguration();
            PlayerConfiguration mainPlayerConfiguration = new PlayerConfiguration();

            mainPlayerConfiguration.PlayerName = UIManager.GetPlayerName(currentPlayer);
            mainPlayerConfiguration.PlayerType = PlayerTypes.ePlayerTypes.Human;
            gameConfiguration.AddPlayerConfiguration(mainPlayerConfiguration);
            gameConfiguration.BoardSize = UIManager.GetBoardSize();
            gameConfiguration.GameMode = UIManager.GetGameMode();
            if(gameConfiguration.GameMode ==GameModes.eGameModes.TwoPlayersGame)
            {
                PlayerConfiguration secondaryPlayerConfiguration = new PlayerConfiguration();

                currentPlayer++;
                secondaryPlayerConfiguration.PlayerName = UIManager.GetPlayerName(currentPlayer);
                secondaryPlayerConfiguration.PlayerType = PlayerTypes.ePlayerTypes.Human;
                gameConfiguration.AddPlayerConfiguration(secondaryPlayerConfiguration);
            }

            //todo: initialize the game manager here with the game configuration

        }

        public void StartGame()
        {

        }
    }
}
