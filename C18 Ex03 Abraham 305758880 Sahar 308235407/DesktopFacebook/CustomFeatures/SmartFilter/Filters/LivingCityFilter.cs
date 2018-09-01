using System.Collections.Generic;
using DesktopFacebook.CustomFeatures.SmartFilter.FiltersData;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.SmartFilter.Filters
{
    public class LivingCityFilter : IFriendsFilter
    {
        public List<User> Filter(List<User> i_FriendList, FilterData i_FilterData)
        {
            List<User> filteredList = new List<User>();
            LivingCityFilterData livingCityFilterData = i_FilterData as LivingCityFilterData;

            foreach (User friend in i_FriendList)
            {
                if (friend.Location == null || string.IsNullOrEmpty(friend.Location.Name))
                {
                    continue;
                }

                if (string.Compare(livingCityFilterData.LivingCity.ToLower(), friend.Location.Name.ToLower()) == 0)
                {
                    filteredList.Add(friend);
                }
            }

            return filteredList;
        }
    }
}
