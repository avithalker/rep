namespace DesktopFacebook
{
    public class DataFetchIndicator
    {
        private bool m_ArePostsWereFetch;
        private bool m_AreFriendsWereFetch;
        private bool m_AreAlbumsWereFetch;
        private bool m_AreCheckinsWereFetch;

        public bool AreCheckinWereFetch
        {
            get { return m_AreCheckinsWereFetch; }
            set { m_AreCheckinsWereFetch = value; }
        }

        public bool AreAlbumsWereFetch
        {
            get { return m_AreAlbumsWereFetch; }
            set { m_AreAlbumsWereFetch = value; }
        }

        public bool AreFriendsWereFetch
        {
            get { return m_AreFriendsWereFetch; }
            set { m_AreFriendsWereFetch = value; }
        }

        public bool ArePostsWereFetch
        {
            get { return m_ArePostsWereFetch; }
            set { m_ArePostsWereFetch = value; }
        }
    }
}
