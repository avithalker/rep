using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale
{
    public class FriendshipMatchScaleCalculator
    {
        private int m_matchScaleValue;
        private User m_loginUser;
        

        public FriendshipMatchScaleCalculator(User i_loginUser)
        {
            m_loginUser = i_loginUser;
        }

        public int CalculateMusicMatchPercentValue(User i_friend)
        {
            List<Page> MusicPageListOfLoginUser = getUsersMusicPageLIst(m_loginUser);
            List<Page> MusicPageListOfUsersFriend = getUsersMusicPageLIst(i_friend);
            int numOfMatches = 0;
            
            foreach(Page page in MusicPageListOfUsersFriend)
            {
                foreach(Page loginUserpage in MusicPageListOfLoginUser)
                {
                    if(page.Id == loginUserpage.Id)
                    {
                        numOfMatches++;
                    }
                }
            }

            return (numOfMatches / MusicPageListOfLoginUser.Count) * 100 ;
        }

        private List<Page> getUsersMusicPageLIst(User i_user)
        {
            List<Page> MusicPageList = new List<Page>();

            foreach (Page page in i_user.LikedPages.Where(isMusicPage))
            {
                if(page.Category.ToString() == "Musician/Band")
                {
                    MusicPageList.Add(page);
                }
            }

            return MusicPageList;
        }

        public int CalculateEntertainmentPlacesMatch(User i_friend)
        {
            int numOfMatches = 0;

            foreach (Checkin checkin in i_friend.Checkins)
            {
               foreach(Checkin friendsCheckin in m_loginUser.Checkins)
                {
                    if(checkin.Place.Category == friendsCheckin.Place.Category)
                    {
                        numOfMatches++;
                    }
                }
            }

            return (numOfMatches / i_friend.Checkins.Count) * 100;
        }

        public int CalculatePrivateInfoMatch(User i_friend)
        {
            int numOfMatches = 0;

            if(m_loginUser.Hometown == i_friend.Hometown)
            {
                numOfMatches++;
            }
            if(m_loginUser.RelationshipStatus == i_friend.RelationshipStatus)
            {
                numOfMatches++;
            }
            if(getUsersCurrentWork(m_loginUser).Position == getUsersCurrentWork(i_friend).Position)
            {
                numOfMatches++;
            }

            return (numOfMatches / 3) * 100;
        }

        private WorkExperience getUsersCurrentWork(User i_user)
        {
            foreach(WorkExperience work in i_user.WorkExperiences)
            {
                if ((string.IsNullOrEmpty((work.EndDate.ToString()))))
                {
                    return work;
                }
            }

            return null;
        }

        public int Calculate(User i_friend)
        {
            int entertainmentPercentMatch = CalculateEntertainmentPlacesMatch(i_friend) * 1 / 3;
            int privateInfoMatch = CalculatePrivateInfoMatch(i_friend) * 1 / 3;
            int musicMatch = CalculateMusicMatchPercentValue(i_friend) * 1 / 3;

            return (musicMatch + privateInfoMatch + entertainmentPercentMatch);
        }

        private bool isMusicPage(Page i_page)
        {
            return i_page.Category == "Musician/Band";
        }
    }
}
