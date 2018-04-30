using BusinessLogic.Enums;

namespace BusinessLogic.Dtos
{
    public class GameSummery
    {
        private EndGameStates.eEndGameStates m_endGameState;
        private string m_WinnerName;
        private int m_Score;

        public EndGameStates.eEndGameStates EndGameState
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
