using BusinessLogic.Enums;

namespace BusinessLogic.Dtos
{
    public class GameSummery
    {
        private eGameStatus m_endGameState;
        private string m_WinnerName;
        private int m_Score;
        private ePlayerTitles m_WinnerTitle;

        public ePlayerTitles WinnerTitle
        {
            get { return m_WinnerTitle; }
            set { m_WinnerTitle = value; }
        }

        public eGameStatus EndGameState
        {
            get { return m_endGameState; }
            set { m_endGameState = value; }
        }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public string WinnerName
        {
            get { return m_WinnerName; }
            set { m_WinnerName = value; }
        }
    }
}
