namespace DesktopFacebook.CustomFeatures.SmartFilter.FiltersData
{
    public class LivingCityFilterData : FilterData
    {
        private string m_LivingCity;

        public string LivingCity
        {
            get { return m_LivingCity; }
            set { m_LivingCity = value; }
        }

        public LivingCityFilterData() : base(eFilterType.LivingCityFilter)
        {
        }
    }
}
