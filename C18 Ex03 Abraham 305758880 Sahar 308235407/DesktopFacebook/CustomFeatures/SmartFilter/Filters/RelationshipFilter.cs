using System.Collections.Generic;
using DesktopFacebook.CustomFeatures.SmartFilter.FiltersData;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.CustomFeatures.SmartFilter.Filters
{
    public class RelationshipFilter : IFriendsFilter
    {
        public List<User> Filter(List<User> i_FriendList, FilterData i_FilterData)
        {
            List<User> filteredList = new List<User>();
            RelationshipFitlerData relationshipFitlerData = i_FilterData as RelationshipFitlerData;

            foreach (User friend in i_FriendList)
            {
                if (!friend.RelationshipStatus.HasValue)
                {
                    continue;
                }

                if (friend.RelationshipStatus.Value == relationshipFitlerData.RelationshipStatus)
                {
                    filteredList.Add(friend);
                }
            }

            return filteredList;
        }
    }
}
