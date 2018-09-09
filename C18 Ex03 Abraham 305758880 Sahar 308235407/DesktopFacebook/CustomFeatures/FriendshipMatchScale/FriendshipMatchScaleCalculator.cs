using System;
using System.Collections.Generic;
using System.Linq;
using DesktopFacebook.CustomFeatures.FriendshipMatchScale.MatchCategoryTypes;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale
{
    public class FriendshipMatchScaleCalculator
    {
        private User m_loginUser;

        internal MatchCategoryContainer MatchCategoryContainer { get; }
        public MusicMatchCategory m_MusicMatchCategory;
        public CheckinsMatchCategory m_CheckinsMatchCategory;
        public PrivateDetailsMatchCategory m_PrivateDetailsMatchCategory;


        public FriendshipMatchScaleCalculator(User i_loginUser)
        {
            m_loginUser = i_loginUser;
            MatchCategoryContainer = new MatchCategoryContainer(createMatchCategories());
        }
        private List<MatchCategory> createMatchCategories()
        {
            m_MusicMatchCategory = new MusicMatchCategory(m_loginUser);
            m_CheckinsMatchCategory = new CheckinsMatchCategory(m_loginUser);
            m_PrivateDetailsMatchCategory = new PrivateDetailsMatchCategory(m_loginUser);

            List<MatchCategory> result = new List<MatchCategory> { m_MusicMatchCategory, m_CheckinsMatchCategory, m_PrivateDetailsMatchCategory };

            return result;
        }
        public int Calculate(User i_friend)
        { 
   
            int entertainmentPercentMatch = m_CheckinsMatchCategory.GetMatchValue(i_friend) * 1 / 3;
            int privateInfoMatch = m_PrivateDetailsMatchCategory.GetMatchValue(i_friend) * 1 / 3;
            int musicMatch = m_MusicMatchCategory.GetMatchValue(i_friend) * 1 / 3;

            return musicMatch + privateInfoMatch + entertainmentPercentMatch;
        }

    }
}
