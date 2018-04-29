namespace CheckersApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            ApplicationManager appManager = new ApplicationManager();

            appManager.InitializeGame();
            appManager.StartGame();
        }
    }
}
