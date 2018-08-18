using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale
{
    public class UserDataCache
    {
        public List<Checkin> m_UsersCheckins;
        public List<Page> m_MusicPages { get; set; }
        public Dictionary<String, Object> m_UsersGeneralDetails { get; set; }
    }
}
