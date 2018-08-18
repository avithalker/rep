using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale
{
    public class CacheFriendshipCalculator
    {
        public FriendshipMatchScaleCalculator m_FriendshipCalculator { get; set; }
        //public List<String> m_CachedFriendsId { get; set; } 
        public Dictionary<String, List<Checkin>> m_FriendsCheckins { get; set; }
        public Dictionary<String, int> m_CachedFriendshipMatchValues { get; set; }
        public List<Checkin> m_UsersCheckins;
        public List<Page> m_MusicPages { get; set; }
        public Dictionary<String, Object> m_UsersGeneralDetails {get; set;}

      
        public int Calculate()
        {
            return 0;
        }
    }
}
