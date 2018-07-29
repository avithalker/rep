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
        private User m_usersFriend;

        public FriendshipMatchScaleCalculator(User i_loginUser, User i_usersFriend)
        {
            m_loginUser = i_loginUser;
            m_usersFriend = i_usersFriend;
        }

        public int CalculateMusicMatchPercentValue()
        {
            List<Page> MusicPageListOfLoginUser = getUsersMusicPageLIst(m_loginUser);
            List<Page> MusicPageListOfUsersFriend = getUsersMusicPageLIst(m_usersFriend);
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

        public int CalculateEntertainmentPlacesMatch()
        {
            int numOfMatches = 0;

            foreach (Checkin checkin in m_usersFriend.Checkins)
            {
               foreach(Checkin friendsCheckin in m_loginUser.Checkins)
                {
                    if(checkin.Place.Category == friendsCheckin.Place.Category)
                    {
                        numOfMatches++;
                    }
                }
            }

            return (numOfMatches / m_usersFriend.Checkins.Count) * 100;
        }

        public int CalculatePrivateInfoMatch()
        {
            int numOfMatches = 0;

            if(m_loginUser.Hometown == m_usersFriend.Hometown)
            {
                numOfMatches++;
            }
            if(m_loginUser.RelationshipStatus == m_usersFriend.RelationshipStatus)
            {
                numOfMatches++;
            }
            if(getUsersCurrentWork(m_loginUser).Position == getUsersCurrentWork(m_usersFriend).Position)
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

        public int Calculate()
        {
            int entertainmentPercentMatch = CalculateEntertainmentPlacesMatch() * 1 / 3;
            int privateInfoMatch = CalculatePrivateInfoMatch() * 1 / 3;
            int musicMatch = CalculateMusicMatchPercentValue() * 1 / 3;

            return (musicMatch + privateInfoMatch + entertainmentPercentMatch);
        }

        private bool isMusicPage(Page i_page)
        {
            return i_page.Category == "Musician/Band";
        }
    }
}
