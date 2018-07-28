namespace DesktopFacebook.CustomFeatures.SmartFilter.FiltersData
{
    public abstract class FilterData
    {
        private eFilterType m_FilterType;

        public FilterData(eFilterType i_FilterType)
        {
            m_FilterType = i_FilterType;
        }

        public eFilterType FilterType
        {
            get { return m_FilterType; }
        }
    }
}
