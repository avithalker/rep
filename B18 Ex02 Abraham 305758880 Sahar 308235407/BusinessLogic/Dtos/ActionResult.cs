namespace BusinessLogic.Dtos
{
    public class ActionResult
    {
        private bool m_IsSucceed;
        private string m_Message;

        public string Message
        {
            get { return m_Message; }
        }

        public bool IsSucceed
        {
            get { return m_IsSucceed; }
        }

        public ActionResult(bool i_IsSucceed,string i_Message)
        {
            m_IsSucceed = i_IsSucceed;
            m_Message = i_Message;
        }
    }
}
