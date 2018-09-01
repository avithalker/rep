using System.Collections.Generic;
using DesktopFacebook.CustomFeatures.SmartFilter.Filters;
using DesktopFacebook.CustomFeatures.SmartFilter.FiltersData;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.SmartFilter
{
    public static class FilterActivator
    {
        public static List<User> FilterFriendList(List<User> i_FriendList, List<FilterData> i_FiltersToUse)
        {
            List<User> filteredList = i_FriendList;
            foreach (FilterData filterData in i_FiltersToUse)
            {
                IFriendsFilter filter = FilterFactory.GetCompatibleFilter(filterData.FilterType);

                filteredList = filter.Filter(filteredList, filterData);
            }

            return filteredList;
        }
    }
}
