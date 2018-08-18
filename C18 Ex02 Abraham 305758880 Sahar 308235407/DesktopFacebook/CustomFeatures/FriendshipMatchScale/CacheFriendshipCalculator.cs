using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;


namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale
{
    public class CacheFriendshipCalculator
    {
        public FriendshipMatchScaleCalculator m_FriendshipCalculator { get; set; }
        public UserDataCache m_userDataCache { get; set; }
        public Dictionary<String, List<Checkin>> m_FriendsCheckins { get; set; }
        public Dictionary<String, int> m_CachedFriendshipMatchValues { get; set; }

        public CacheFriendshipCalculator()
        {
            //fetchUserData()
        }
        public int Calculate()
        {
            return 0;
        }
    }
}
