﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using DesktopFacebook.Business;

namespace DesktopFacebook.Components.Pages
{
    public partial class CheckinPage : UserControl
    {
        private FacebookUserManager m_FacebookUserManager;
        private DataFetchIndicator m_DataFetchIndicator;

        public CheckinPage(FacebookUserManager i_FacebookUserManager, DataFetchIndicator i_DataFetchIndicator)
        {
            InitializeComponent();
            m_FacebookUserManager = i_FacebookUserManager;
            m_DataFetchIndicator = i_DataFetchIndicator;
        }

        public void FetchCheckins()
        {
            checkinBindingSource.DataSource = m_FacebookUserManager.NativeClient.Checkins;
            m_DataFetchIndicator.AreCheckinWereFetch = true;
        }

        private void CheckinsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Checkin selectedCheckin = CheckinsListBox.SelectedItem as Checkin;
            fillExtendedChekinData(selectedCheckin);
        }
        
        private void fillExtendedChekinData(Checkin selectedCheckin)
        {
            CheckinMessgeOutputLabel.Text = selectedCheckin.Message;
            CheckinLocationOutputLabel.Text = selectedCheckin.Place.Name;
            if (selectedCheckin.CreatedTime.HasValue)
            {
                CheckinDateOutputLbel.Text = selectedCheckin.CreatedTime.Value.ToString("dd/MM/yyyy hh:mm");
            }
            else
            {
                CheckinDateOutputLbel.Text = string.Empty;
            }

            List<string> friendsName = new List<string>();
            foreach (User friend in selectedCheckin.WithUsers)
            {
                friendsName.Add(friend.Name);
            }

            CheckinFriendsOutputLabel.Text = string.Join(", ", friendsName);
        }
    }
}
