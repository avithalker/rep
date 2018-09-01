using DesktopFacebook.CustomFeatures.SmartFilter.Filters;

namespace DesktopFacebook.CustomFeatures.SmartFilter
{
    public static class FilterFactory
    {
        public static IFriendsFilter GetCompatibleFilter(eFilterType i_FilterType)
        {
            switch (i_FilterType)
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
