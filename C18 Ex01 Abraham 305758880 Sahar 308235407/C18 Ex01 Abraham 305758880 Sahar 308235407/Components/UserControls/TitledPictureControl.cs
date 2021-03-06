﻿using System;
using System.Windows.Forms;

namespace DesktopFacebook.Components.UserControls
{
    public partial class TitledPictureControl : UserControl
    {
        private string m_Id;

        public string Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public TitledPictureControl(string i_ImageUrl, string i_Title, string i_Id)
        {
            InitializeComponent();
            WireAllControls(this);
            m_Id = i_Id;
            TitleLabel.Text = i_Title;
            if (!string.IsNullOrEmpty(i_ImageUrl))
            {
                PhotoPictureBox.LoadAsync(i_ImageUrl);
            }
        }

        private void WireAllControls(Control i_MainLayoutControl)
        {
            foreach (Control childControl in i_MainLayoutControl.Controls)
            {
                childControl.Click += ctl_Click;
                if (childControl.HasChildren)
                {
                    WireAllControls(childControl);
                }
            }
        }

        private void ctl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }
    }
}
