using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale.MatchCategoryTypes
{
    public class CheckinsMatchCategory : MatchCategory
    {
        public CheckinsMatchCategory(User i_LoginUser) : base(i_LoginUser)
        {
            CategoryName = "Entertainment Places";
        }

        public override int GetMatchValue(User i_friend)
        {
            int numOfMatches = 0;
            int matchResult = 0;
            List<string> userCheckinCategories = getCheckinsCategories(m_LoginUserData);
            List<string> friendCheckinCategories = getCheckinsCategories(i_friend);

            if (i_friend.Checkins.Count != 0)
            {
                foreach (string userCategory in userCheckinCategories)
                {
                    foreach (string friendCategory in friendCheckinCategories)
                    {
                        if (userCategory == friendCategory)
                        {
                            numOfMatches++;
                        }
                    }
                }

                matchResult = (numOfMatches / i_friend.Checkins.Count) * 100;
            }

            return matchResult;
        }

        private List<string> getCheckinsCategories(User i_user)
        {
            List<string> categories = new List<string>();
            if (i_user.Checkins.Count != 0)
            {
                foreach (Checkin checkin in i_user.Checkins)
                {
                    if (checkin.Place.Category != null && !categories.Contains(checkin.Place.Category))
                    {
                        categories.Add(checkin.Place.Category);
                    }
                }
            }

            return categories;
        }
    }
}
