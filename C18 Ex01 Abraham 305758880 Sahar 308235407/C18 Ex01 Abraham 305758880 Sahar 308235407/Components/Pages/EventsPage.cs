using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void EventsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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

    }
}
