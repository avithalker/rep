using FacebookWrapper.ObjectModel;
using DesktopFacebook.CustomFeatures.SmartFilter.FiltersData;
using System.Collections.Generic;

namespace DesktopFacebook.CustomFeatures.SmartFilter.Filters
{
    public interface IFriendsFilter
    {
        List<User> Filter(List<User> i_FriendList, FilterData i_FilterData);
    }
}
