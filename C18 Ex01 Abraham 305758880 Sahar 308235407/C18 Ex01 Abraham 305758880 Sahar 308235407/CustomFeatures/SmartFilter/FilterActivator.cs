using DesktopFacebook.CustomFeatures.SmartFilter.Filters;
using DesktopFacebook.CustomFeatures.SmartFilter.FiltersData;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;

namespace DesktopFacebook.CustomFeatures.SmartFilter
{
    public static class FilterActivator
    {
        public static List<User> FilterFriendList(List<User> i_FriendList, List<FilterData> i_FiltersToUse)
        {
            List<User> filteredList = i_FriendList;
            foreach(FilterData filterData in i_FiltersToUse)
            {
                IFriendsFilter filter = getCompatibleFilter(filterData.FilterType);

                filteredList = filter.Filter(filteredList, filterData);
            }

            return filteredList;
        }

        private static IFriendsFilter getCompatibleFilter(eFilterType i_FilterType)
        {
            switch(i_FilterType)
            {
                case eFilterType.AgeRangeFilter:
                    {
                        return new AgeFilter();
                    }
                case eFilterType.GenderFilter:
                    {
                        return new GenderFilter();
                    }
                case eFilterType.LivingCityFilter:
                    {
                        return new LivingCityFilter();
                    }
                case eFilterType.RelationshipFilter:
                    {
                        return new RelationshipFilter();
                    }
            }

            return null;
        }
    }
}
