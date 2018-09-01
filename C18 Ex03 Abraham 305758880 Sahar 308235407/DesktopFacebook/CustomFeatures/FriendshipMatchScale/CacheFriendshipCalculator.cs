using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale
{
    public class CacheFriendshipCalculator
    {
        public FriendshipMatchScaleCalculator m_FriendshipCalculator { get; set; }

        public Dictionary<string, int> m_CachedFriendshipMatchValues { get; set; }

        public CacheFriendshipCalculator(User m_loginUser)
        {
            m_FriendshipCalculator = new FriendshipMatchScaleCalculator(m_loginUser);
        }

        public int Calculate(User i_friend)
        {
            int result;

            if (m_CachedFriendshipMatchValues != null && m_CachedFriendshipMatchValues.ContainsKey(i_friend.Id))
            {
                return m_CachedFriendshipMatchValues[i_friend.Id];
            }
            else
            {
                result = m_FriendshipCalculator.Calculate(i_friend);
                saveFriendshipMatchValueToCache(i_friend.Id, result);
                m_CachedFriendshipMatchValues[i_friend.Id] = result;
                return result;
            }
        }

        private void saveFriendshipMatchValueToCache(string i_id, int i_result)
        {
            if (m_CachedFriendshipMatchValues == null)
            {
                m_CachedFriendshipMatchValues = new Dictionary<string, int>();
            }

            m_CachedFriendshipMatchValues[i_id] = i_result;
        }
    }
}
