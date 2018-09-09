using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale.MatchCategoryTypes
{
    public class MusicMatchCategory : MatchCategory
    {
        public MusicMatchCategory(User i_LoginUser) : base(i_LoginUser)
        {
            CategoryName = "Music";
        }

        public override int GetMatchValue(User i_friend)
        {
            List<Page> MusicPageListOfLoginUser = getUsersMusicPageLIst(m_LoginUserData);
            List<Page> MusicPageListOfUsersFriend = getUsersMusicPageLIst(i_friend);
            int numOfMatches = 0;
            int matchValue = 0;

            if (MusicPageListOfLoginUser.Count() != 0 && MusicPageListOfUsersFriend.Count() != 0)
            {
                foreach (Page page in MusicPageListOfUsersFriend)
                {
                    foreach (Page loginUserpage in MusicPageListOfLoginUser)
                    {
                        if (page.Id == loginUserpage.Id)
                        {
                            numOfMatches++;
                        }
                    }
                }

                matchValue = (numOfMatches / MusicPageListOfLoginUser.Count) * 100;
            }

            MatchValue = matchValue;

            return matchValue;
        }

        private List<Page> getUsersMusicPageLIst(User i_user)
        {
            List<Page> MusicPageList = new List<Page>();

            foreach (Page page in i_user.LikedPages.Where(isMusicPage))
            {
                if (page.Category.ToString() == "Musician/Band")
                {
                    MusicPageList.Add(page);
                }
            }

            return MusicPageList;
        }

        private bool isMusicPage(Page i_page)
        {
            return i_page.Category == "Musician/Band";
        }
    }
}
