using System.Collections.Generic;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale
{
    public class FriendshipMatchScaleCalculator
    {
        private User m_loginUser;

        public FriendshipMatchScaleCalculator(User i_loginUser)
        {
            m_loginUser = i_loginUser;
        }

        private int calculateMusicMatchPercentValue(User i_friend)
        {
            List<Page> MusicPageListOfLoginUser = getUsersMusicPageLIst(m_loginUser);
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

        private int calculateEntertainmentPlacesMatch(User i_friend)
        {
            int numOfMatches = 0;
            int matchResult = 0;

            if (i_friend.Checkins.Count != 0)
            {
                foreach (Checkin checkin in i_friend.Checkins)
                {
                    foreach (Checkin friendsCheckin in m_loginUser.Checkins)
                    {
                        if (checkin.Place.Category == friendsCheckin.Place.Category)
                        {
                            numOfMatches++;
                        }
                    }
                }

                matchResult = (numOfMatches / i_friend.Checkins.Count) * 100;
            }

            return matchResult;
        }

        private int calculatePrivateInfoMatch(User i_friend)
        {
            int numOfMatches = 0;

            if ((i_friend.Hometown != null) && (m_loginUser.Hometown != null) && m_loginUser.Hometown == i_friend.Hometown)
            {
                numOfMatches++;
            }

            if ((m_loginUser.RelationshipStatus != null) && (i_friend.RelationshipStatus != null) && (m_loginUser.RelationshipStatus == i_friend.RelationshipStatus))
            {
                numOfMatches++;
            }

            if (getUsersLastPosition(m_loginUser) != null && getUsersLastPosition(i_friend) != null && getUsersCurrentWork(m_loginUser).Position == getUsersCurrentWork(i_friend).Position)
            {
                numOfMatches++;
            }

            return (numOfMatches / 3) * 100;
        }

        private Page getUsersLastPosition(User i_user)
        {
            WorkExperience currentWork = null;
            Page lastPosition = null;

            if (i_user.WorkExperiences != null && i_user.WorkExperiences.Count() != 0)
            {
                currentWork = getUsersCurrentWork(i_user);
            }

            if (currentWork != null)
            {
                lastPosition = currentWork.Position;
            }

            return lastPosition;
        }

        private WorkExperience getUsersCurrentWork(User i_user)
        {
            WorkExperience currentWork = null;

            if (i_user.WorkExperiences != null && i_user.WorkExperiences.Count() != 0)
            {
                foreach (WorkExperience work in i_user.WorkExperiences)
                {
                    if (string.IsNullOrEmpty(work.EndDate.ToString()))
                    {
                        currentWork = work;
                    }
                }
            }

            return currentWork;
        }

        public int Calculate(User i_friend)
        {
            int entertainmentPercentMatch = calculateEntertainmentPlacesMatch(i_friend) * 1 / 3;
            int privateInfoMatch = calculatePrivateInfoMatch(i_friend) * 1 / 3;
            int musicMatch = calculateMusicMatchPercentValue(i_friend) * 1 / 3;

            return musicMatch + privateInfoMatch + entertainmentPercentMatch;
        }

        private bool isMusicPage(Page i_page)
        {
            return i_page.Category == "Musician/Band";
        }
    }
}
