namespace DesktopFacebook.CustomFeatures.SmartFilter.FiltersData
{
    public class AgeRangeFilterData : FilterData
    {
        private bool m_IsUnder18;

        public bool IsUnder18
        {
            get { return m_IsUnder18; }
            set { m_IsUnder18 = value; }
        }

        public AgeRangeFilterData() : base(eFilterType.AgeRangeFilter)
        {
        }
    }
}
