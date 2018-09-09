using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale.MatchCategoryTypes
{
    public class PrivateDetailsMatchCategory : MatchCategory
    {
        public PrivateDetailsMatchCategory(User i_LoginUser) : base(i_LoginUser)
        {
            CategoryName = "Private Details";
        }

        public override int GetMatchValue(User i_friend)
        {
            int numOfMatches = 0;

            if ((i_friend.Hometown != null) && (m_LoginUserData.Hometown != null) && m_LoginUserData.Hometown == i_friend.Hometown)
            {
                numOfMatches++;
            }

            if ((m_LoginUserData.RelationshipStatus != null) && (i_friend.RelationshipStatus != null) && (m_LoginUserData.RelationshipStatus == i_friend.RelationshipStatus))
            {
                numOfMatches++;
            }

            return (numOfMatches / 2) * 100;
        }
    }
}
