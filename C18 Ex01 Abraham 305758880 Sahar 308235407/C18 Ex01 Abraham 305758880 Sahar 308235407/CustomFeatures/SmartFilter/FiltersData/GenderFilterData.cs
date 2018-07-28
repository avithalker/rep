using static FacebookWrapper.ObjectModel.User;

namespace DesktopFacebook.CustomFeatures.SmartFilter.FiltersData
{
    public class GenderFilterData:FilterData
    {
        private eGender m_Gender;

        public eGender Gender
        {
            get { return m_Gender; }
            set { m_Gender = value; }
        }

        public GenderFilterData():base(eFilterType.GenderFilter)
        {

        }
    }
}
