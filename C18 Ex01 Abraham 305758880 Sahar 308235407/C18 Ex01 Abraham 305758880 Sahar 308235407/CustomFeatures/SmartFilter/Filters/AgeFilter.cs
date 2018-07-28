using System;
using System.Collections.Generic;
using DesktopFacebook.CustomFeatures.SmartFilter.FiltersData;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.SmartFilter.Filters
{
    public class AgeFilter : IFriendsFilter
    {
        public List<User> Filter(List<User> i_FriendList, FilterData i_FilterData)
        {
            List<User> filteredList = new List<User>();
            AgeRangeFilterData ageFilterData = i_FilterData as AgeRangeFilterData;

            foreach(User friend in i_FriendList)
            {
                if(string.IsNullOrEmpty(friend.Birthday))
                {
                    continue;
                }

                int age = DateTime.Now.Year - DateTime.Parse(friend.Birthday).Year;

                if(age < 18 && ageFilterData.IsUnder18 || age>=18 && !ageFilterData.IsUnder18)
                {
                    filteredList.Add(friend);
                }
            }

            return filteredList;
        }
    }
}
