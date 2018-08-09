using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using DesktopFacebook.Business;
using DesktopFacebook.CustomFeatures.SmartFilter;
using DesktopFacebook.CustomFeatures.SmartFilter.FiltersData;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Components.Pages
{
    public partial class SmartPostPage : UserControl
    {
        private FacebookUserManager m_FacebookUserManager;

        public SmartPostPage(FacebookUserManager i_FacebookUserManager)
        {
            InitializeComponent();

            m_FacebookUserManager = i_FacebookUserManager;
            facebookPostControl1.UserManager = i_FacebookUserManager;
        }

        private void GenderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MaleRadioButton.Enabled = GenderCheckBox.Checked;
            FemaleRadioButton.Enabled = GenderCheckBox.Checked;
        }

        private void RealtionshipCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            MarriedRadioButton.Enabled = RealtionshipCheckbox.Checked;
            DivorcedRadioButton.Enabled = RealtionshipCheckbox.Checked;
            SingleRadioButton.Enabled = RealtionshipCheckbox.Checked;
        }

        private void LivingCityCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            LivingCityTextbox.Enabled = LivingCityCheckbox.Checked;
        }

        private void AgeFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            minus18RadioButton.Enabled = AgeFilterCheckBox.Checked;
            Plus18RadioButton.Enabled = AgeFilterCheckBox.Checked;
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            FilteredFriendsListbox.Items.Clear();
            findMatch();
        }

        private void findMatch()
        {
            List<FilterData> filterToUse = getRelevantFilters();
            List<User> matchFriends = FilterActivator.FilterFriendList(m_FacebookUserManager.GetFriendsAsList(), filterToUse);

            fillFilteredListBox(matchFriends);
            facebookPostControl1.TaggedFriends = string.Join(",", matchFriends.Select(x => x.Id).ToList());
        }

        private void fillFilteredListBox(List<User> i_Friends)
        {
            FilteredFriendsListbox.DisplayMember = "Name";
            FilteredFriendsListbox.Items.AddRange(i_Friends.ToArray());
        }

        private List<FilterData> getRelevantFilters()
        {
            List<FilterData> filterToUse = new List<FilterData>();

            if (GenderCheckBox.Checked)
            {
                filterToUse.Add(getGenderFilterData());
            }

            if (AgeFilterCheckBox.Checked)
            {
                filterToUse.Add(getAgeFilterData());
            }

            if (RealtionshipCheckbox.Checked)
            {
                filterToUse.Add(getRelationshipFilterData());
            }

            if (LivingCityCheckbox.Checked)
            {
                filterToUse.Add(getLivingCityFilterData());
            }

            return filterToUse;
        }
            
        private FilterData getGenderFilterData()
        {
            GenderFilterData filterData = new GenderFilterData();

            if (MaleRadioButton.Checked)
            {
                filterData.Gender = User.eGender.male;
            }
            else
            {
                filterData.Gender = User.eGender.female;
            }

            return filterData;
        }

        private FilterData getLivingCityFilterData()
        {
            LivingCityFilterData filterData = new LivingCityFilterData();

            filterData.LivingCity = LivingCityTextbox.Text;
            return filterData;
        }

        private FilterData getAgeFilterData()
        {
            AgeRangeFilterData filterData = new AgeRangeFilterData();

            filterData.IsUnder18 = minus18RadioButton.Checked;
            return filterData;
        }

        private FilterData getRelationshipFilterData()
        {
            RelationshipFitlerData filterData = new RelationshipFitlerData();

            if (SingleRadioButton.Checked)
            {
                filterData.RelationshipStatus = User.eRelationshipStatus.Single;
            }
            else if (MarriedRadioButton.Checked)
            {
                filterData.RelationshipStatus = User.eRelationshipStatus.Married;
            }
            else
            {
                filterData.RelationshipStatus = User.eRelationshipStatus.Divorced;
            }

            return filterData;
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            facebookPostControl1.TaggedFriends = string.Empty;
            FilteredFriendsListbox.Items.Clear();
            GenderCheckBox.Checked = false;
            AgeFilterCheckBox.Checked = false;
            LivingCityCheckbox.Checked = false;
            RealtionshipCheckbox.Checked = false;
        }
    }
}
