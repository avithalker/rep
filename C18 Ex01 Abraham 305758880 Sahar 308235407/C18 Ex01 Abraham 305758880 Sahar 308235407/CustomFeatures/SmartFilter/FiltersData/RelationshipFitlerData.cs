using static FacebookWrapper.ObjectModel.User;

namespace DesktopFacebook.CustomFeatures.SmartFilter.FiltersData
{
    public class RelationshipFitlerData : FilterData
    {
        private eRelationshipStatus m_RelationshipStatus;

        public eRelationshipStatus RelationshipStatus
        {
            get { return m_RelationshipStatus; }
            set { m_RelationshipStatus = value; }
        }

        public RelationshipFitlerData() : base(eFilterType.RelationshipFilter)
        {
        }
    }
}
