using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using DesktopFacebook.Business;

namespace DesktopFacebook.Components.Pages
{
    public partial class EventsPage : UserControl
    {
        private FacebookUserManager m_UserManager;

        public EventsPage(FacebookUserManager m_FacebookUserManager)
        {
            InitializeComponent();
            m_UserManager = m_FacebookUserManager;
        }

        private void EventDatePicker_ValueChanged(object sender, EventArgs e)
        {
            List<Event> onThisDayEvnets = m_UserManager.FindEventsByDate(EventDatePicker.Value);

            fillEventListBox(onThisDayEvnets);
            cleanEventDetails();
        }

        private void EventsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillEventDetails(EventsListBox.SelectedItem as Event);
        }

        private void fillEventListBox(List<Event> i_OnThisDayEvnets)
        {
            EventsListBox.DisplayMember = "Name";
            EventsListBox.Items.Clear();
            foreach (Event dayEvent in i_OnThisDayEvnets)
            {
                EventsListBox.Items.Add(dayEvent);
            }
        }

        private void fillEventDetails(Event i_Event)
        {
            DescriptionOutputLabel.Text = i_Event.Description;
            EventNameOutputLabel.Text = i_Event.Name;
            LocationOutputLabel.Text = i_Event.Location;
            StartDateOutputLabel.Text = string.Empty;
            try
            {
                StatusOutputLabel.Text = m_UserManager.GetRsvpForEvent(i_Event.Id).ToString();
            }
            catch(Exception)
            {
                StatusOutputLabel.Text = "Unknown";
            }
            
            if (i_Event.EndTime.HasValue)
            {
                EndDateOutputLabel.Text = i_Event.EndTime.Value.ToString("dd-MM-yyyy hh:mm");
            }
            else
            {
                EndDateOutputLabel.Text = "Unkown";
            }

            if (i_Event.StartTime.HasValue)
            {
                StartDateOutputLabel.Text = i_Event.StartTime.Value.ToString("dd-MM-yyyy hh:mm");
            }
            else
            {
                StartDateOutputLabel.Text = "Unkown";
            }
        }

        private void cleanEventDetails()
        {
            DescriptionOutputLabel.Text = string.Empty;
            EndDateOutputLabel.Text = string.Empty;
            EventNameOutputLabel.Text = string.Empty;
            LocationOutputLabel.Text = string.Empty;
            StartDateOutputLabel.Text = string.Empty;
            StatusOutputLabel.Text = string.Empty;
        }
    }
}
