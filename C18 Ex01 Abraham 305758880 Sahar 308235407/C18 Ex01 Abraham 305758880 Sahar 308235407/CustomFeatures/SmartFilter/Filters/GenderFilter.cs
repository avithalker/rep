using System.Collections.Generic;
using DesktopFacebook.CustomFeatures.SmartFilter.FiltersData;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.SmartFilter.Filters
{
    public class GenderFilter : IFriendsFilter
    {
        public List<User> Filter(List<User> i_FriendList, FilterData i_FilterData)
        {
            List<User> filteredList = new List<User>();
            GenderFilterData genderFilterData = i_FilterData as GenderFilterData;

            foreach (User friend in i_FriendList)
            {
                if (!friend.Gender.HasValue)
                {
                    continue;
                }

                if (friend.Gender.Value == genderFilterData.Gender)
                {
                    filteredList.Add(friend);
                }
            }

            return filteredList;
        }
    }
}
