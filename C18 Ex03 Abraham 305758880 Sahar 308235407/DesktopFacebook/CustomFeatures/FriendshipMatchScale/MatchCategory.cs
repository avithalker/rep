using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale
{
    public abstract class MatchCategory
    {
        protected User m_LoginUserData;

        public MatchCategory(User i_LoginUser)
        {
            m_LoginUserData = i_LoginUser;
        }

        public string CategoryName { get; set; }
        public int MatchValue { get; set; }
        public abstract int GetMatchValue(User i_friend);
    }
}
