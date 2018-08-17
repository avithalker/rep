namespace DesktopFacebook.Forms
{
    public partial class UserProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfileForm));
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UsersDetailsControlTab = new System.Windows.Forms.TabControl();
            this.UserWallTab = new System.Windows.Forms.TabPage();
            this.ClearImagePictureBox1 = new DesktopFacebook.Components.UserControls.ClickablePictureBox();
            this.AttachPhotoPictureBox1 = new DesktopFacebook.Components.UserControls.ClickablePictureBox();
            this.PreviewPhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.PostTextBox = new System.Windows.Forms.RichTextBox();
            this.PostButton = new System.Windows.Forms.Button();
            this.FriendsTab = new System.Windows.Forms.TabPage();
            this.AlbumsTab = new System.Windows.Forms.TabPage();
            this.CheckInsTab = new System.Windows.Forms.TabPage();
            this.EventsTab = new System.Windows.Forms.TabPage();
            this.SmartPostTab = new System.Windows.Forms.TabPage();
            this.FriendshipMatchTab = new System.Windows.Forms.TabPage();
            this.PictureFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.UserProfilePicture = new System.Windows.Forms.PictureBox();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GenderLabel = new System.Windows.Forms.Label();
            this.RelationshipLabel = new System.Windows.Forms.Label();
            this.BirthDateLabel = new System.Windows.Forms.Label();
            this.UserGenderLabel = new System.Windows.Forms.Label();
            this.UserRelationshipLabel = new System.Windows.Forms.Label();
            this.HomeTownLable = new System.Windows.Forms.Label();
            this.CurrentCityLabel = new System.Windows.Forms.Label();
            this.UserHomeTown = new System.Windows.Forms.Label();
            this.UsersBirthdate = new System.Windows.Forms.Label();
            this.UserCurrentCity = new System.Windows.Forms.Label();
            this.UsersDetailsControlTab.SuspendLayout();
            this.UserWallTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClearImagePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttachPhotoPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPhotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.UserNameLabel.Location = new System.Drawing.Point(18, 406);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(0, 65);
            this.UserNameLabel.TabIndex = 5;
            // 
            // UsersDetailsControlTab
            // 
            this.UsersDetailsControlTab.Controls.Add(this.UserWallTab);
            this.UsersDetailsControlTab.Controls.Add(this.FriendsTab);
            this.UsersDetailsControlTab.Controls.Add(this.AlbumsTab);
            this.UsersDetailsControlTab.Controls.Add(this.CheckInsTab);
            this.UsersDetailsControlTab.Controls.Add(this.EventsTab);
            this.UsersDetailsControlTab.Controls.Add(this.SmartPostTab);
            this.UsersDetailsControlTab.Controls.Add(this.FriendshipMatchTab);
            this.UsersDetailsControlTab.Location = new System.Drawing.Point(610, 12);
            this.UsersDetailsControlTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UsersDetailsControlTab.Name = "UsersDetailsControlTab";
            this.UsersDetailsControlTab.SelectedIndex = 0;
            this.UsersDetailsControlTab.Size = new System.Drawing.Size(1424, 977);
            this.UsersDetailsControlTab.TabIndex = 9;
            this.UsersDetailsControlTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.UsersDetailsControlTab_Selected);
            // 
            // UserWallTab
            // 
            this.UserWallTab.AutoScroll = true;
            this.UserWallTab.Controls.Add(this.ClearImagePictureBox1);
            this.UserWallTab.Controls.Add(this.AttachPhotoPictureBox1);
            this.UserWallTab.Controls.Add(this.PreviewPhotoPictureBox);
            this.UserWallTab.Controls.Add(this.PostTextBox);
            this.UserWallTab.Controls.Add(this.PostButton);
            this.UserWallTab.Location = new System.Drawing.Point(8, 39);
            this.UserWallTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UserWallTab.Name = "UserWallTab";
            this.UserWallTab.Size = new System.Drawing.Size(1408, 930);
            this.UserWallTab.TabIndex = 4;
            this.UserWallTab.Text = "My wall";
            this.UserWallTab.UseVisualStyleBackColor = true;
            // 
            // ClearImagePictureBox1
            // 
            this.ClearImagePictureBox1.Image = global::DesktopFacebook.Properties.Resources.Clear;
            this.ClearImagePictureBox1.Location = new System.Drawing.Point(1090, 29);
            this.ClearImagePictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ClearImagePictureBox1.Name = "ClearImagePictureBox1";
            this.ClearImagePictureBox1.Size = new System.Drawing.Size(50, 48);
            this.ClearImagePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ClearImagePictureBox1.TabIndex = 7;
            this.ClearImagePictureBox1.TabStop = false;
            this.ClearImagePictureBox1.Visible = false;
            this.ClearImagePictureBox1.Click += new System.EventHandler(this.ClearImagePictureBox1_Click);
            // 
            // AttachPhotoPictureBox1
            // 
            this.AttachPhotoPictureBox1.ErrorImage = null;
            this.AttachPhotoPictureBox1.Image = global::DesktopFacebook.Properties.Resources.ImagePlaceHolder;
            this.AttachPhotoPictureBox1.Location = new System.Drawing.Point(30, 196);
            this.AttachPhotoPictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.AttachPhotoPictureBox1.Name = "AttachPhotoPictureBox1";
            this.AttachPhotoPictureBox1.Size = new System.Drawing.Size(84, 67);
            this.AttachPhotoPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AttachPhotoPictureBox1.TabIndex = 6;
            this.AttachPhotoPictureBox1.TabStop = false;
            this.AttachPhotoPictureBox1.Click += new System.EventHandler(this.AttachPhotoPictureBox1_Click);
            // 
            // PreviewPhotoPictureBox
            // 
            this.PreviewPhotoPictureBox.Location = new System.Drawing.Point(1090, 29);
            this.PreviewPhotoPictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PreviewPhotoPictureBox.Name = "PreviewPhotoPictureBox";
            this.PreviewPhotoPictureBox.Size = new System.Drawing.Size(280, 269);
            this.PreviewPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPhotoPictureBox.TabIndex = 4;
            this.PreviewPhotoPictureBox.TabStop = false;
            // 
            // PostTextBox
            // 
            this.PostTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.PostTextBox.Location = new System.Drawing.Point(30, 29);
            this.PostTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PostTextBox.Name = "PostTextBox";
            this.PostTextBox.Size = new System.Drawing.Size(1044, 152);
            this.PostTextBox.TabIndex = 2;
            this.PostTextBox.Text = "What\'s on your mind?";
            this.PostTextBox.MouseEnter += new System.EventHandler(this.PostTextBox_MouseEnter);
            this.PostTextBox.MouseLeave += new System.EventHandler(this.PostTextBox_MouseLeave);
            // 
            // PostButton
            // 
            this.PostButton.Location = new System.Drawing.Point(188, 221);
            this.PostButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PostButton.Name = "PostButton";
            this.PostButton.Size = new System.Drawing.Size(204, 42);
            this.PostButton.TabIndex = 0;
            this.PostButton.Text = "Post";
            this.PostButton.UseVisualStyleBackColor = true;
            this.PostButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // FriendsTab
            // 
            this.FriendsTab.AutoScroll = true;
            this.FriendsTab.Location = new System.Drawing.Point(8, 39);
            this.FriendsTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FriendsTab.Name = "FriendsTab";
            this.FriendsTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FriendsTab.Size = new System.Drawing.Size(1408, 930);
            this.FriendsTab.TabIndex = 0;
            this.FriendsTab.Text = "Friends";
            this.FriendsTab.UseVisualStyleBackColor = true;
            // 
            // AlbumsTab
            // 
            this.AlbumsTab.Location = new System.Drawing.Point(8, 39);
            this.AlbumsTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AlbumsTab.Name = "AlbumsTab";
            this.AlbumsTab.Size = new System.Drawing.Size(1408, 930);
            this.AlbumsTab.TabIndex = 2;
            this.AlbumsTab.Text = "Albums";
            this.AlbumsTab.UseVisualStyleBackColor = true;
            // 
            // CheckInsTab
            // 
            this.CheckInsTab.Location = new System.Drawing.Point(8, 39);
            this.CheckInsTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckInsTab.Name = "CheckInsTab";
            this.CheckInsTab.Size = new System.Drawing.Size(1408, 930);
            this.CheckInsTab.TabIndex = 3;
            this.CheckInsTab.Text = "CheckIns";
            this.CheckInsTab.UseVisualStyleBackColor = true;
            // 
            // EventsTab
            // 
            this.EventsTab.Location = new System.Drawing.Point(8, 39);
            this.EventsTab.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.EventsTab.Name = "EventsTab";
            this.EventsTab.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.EventsTab.Size = new System.Drawing.Size(1408, 930);
            this.EventsTab.TabIndex = 5;
            this.EventsTab.Text = "Events";
            this.EventsTab.UseVisualStyleBackColor = true;
            // 
            // SmartPostTab
            // 
            this.SmartPostTab.Location = new System.Drawing.Point(8, 39);
            this.SmartPostTab.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SmartPostTab.Name = "SmartPostTab";
            this.SmartPostTab.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SmartPostTab.Size = new System.Drawing.Size(1408, 930);
            this.SmartPostTab.TabIndex = 6;
            this.SmartPostTab.Text = "Smart post";
            this.SmartPostTab.UseVisualStyleBackColor = true;
            // 
            // FriendshipMatchTab
            // 
            this.FriendshipMatchTab.Location = new System.Drawing.Point(8, 39);
            this.FriendshipMatchTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FriendshipMatchTab.Name = "FriendshipMatchTab";
            this.FriendshipMatchTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FriendshipMatchTab.Size = new System.Drawing.Size(1408, 930);
            this.FriendshipMatchTab.TabIndex = 7;
            this.FriendshipMatchTab.Text = "Friendship Match";
            this.FriendshipMatchTab.UseVisualStyleBackColor = true;
            // 
            // PictureFileDialog
            // 
            this.PictureFileDialog.FileName = "openFileDialog1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // UserProfilePicture
            // 
            this.UserProfilePicture.Location = new System.Drawing.Point(12, 12);
            this.UserProfilePicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UserProfilePicture.Name = "UserProfilePicture";
            this.UserProfilePicture.Size = new System.Drawing.Size(420, 390);
            this.UserProfilePicture.TabIndex = 0;
            this.UserProfilePicture.TabStop = false;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(12, 942);
            this.LogoutButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(180, 46);
            this.LogoutButton.TabIndex = 14;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenderLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GenderLabel.Location = new System.Drawing.Point(4, 537);
            this.GenderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(131, 39);
            this.GenderLabel.TabIndex = 2;
            this.GenderLabel.Text = "Gender:";
            // 
            // RelationshipLabel
            // 
            this.RelationshipLabel.AutoSize = true;
            this.RelationshipLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RelationshipLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.RelationshipLabel.Location = new System.Drawing.Point(4, 617);
            this.RelationshipLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RelationshipLabel.Name = "RelationshipLabel";
            this.RelationshipLabel.Size = new System.Drawing.Size(294, 39);
            this.RelationshipLabel.TabIndex = 3;
            this.RelationshipLabel.Text = "Relationship status:";
            // 
            // BirthDateLabel
            // 
            this.BirthDateLabel.AutoSize = true;
            this.BirthDateLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BirthDateLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BirthDateLabel.Location = new System.Drawing.Point(4, 694);
            this.BirthDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BirthDateLabel.Name = "BirthDateLabel";
            this.BirthDateLabel.Size = new System.Drawing.Size(172, 39);
            this.BirthDateLabel.TabIndex = 4;
            this.BirthDateLabel.Text = "Birth Date:";
            // 
            // UserGenderLabel
            // 
            this.UserGenderLabel.AutoSize = true;
            this.UserGenderLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Gender", true));
            this.UserGenderLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserGenderLabel.Location = new System.Drawing.Point(328, 542);
            this.UserGenderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserGenderLabel.Name = "UserGenderLabel";
            this.UserGenderLabel.Size = new System.Drawing.Size(0, 33);
            this.UserGenderLabel.TabIndex = 6;
            // 
            // UserRelationshipLabel
            // 
            this.UserRelationshipLabel.AutoSize = true;
            this.UserRelationshipLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "RelationshipStatus", true));
            this.UserRelationshipLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserRelationshipLabel.Location = new System.Drawing.Point(328, 621);
            this.UserRelationshipLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserRelationshipLabel.Name = "UserRelationshipLabel";
            this.UserRelationshipLabel.Size = new System.Drawing.Size(126, 33);
            this.UserRelationshipLabel.TabIndex = 7;
            this.UserRelationshipLabel.Text = "Unknown";
            // 
            // HomeTownLable
            // 
            this.HomeTownLable.AutoSize = true;
            this.HomeTownLable.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeTownLable.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HomeTownLable.Location = new System.Drawing.Point(4, 769);
            this.HomeTownLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HomeTownLable.Name = "HomeTownLable";
            this.HomeTownLable.Size = new System.Drawing.Size(189, 39);
            this.HomeTownLable.TabIndex = 10;
            this.HomeTownLable.Text = "HomeTown:";
            // 
            // CurrentCityLabel
            // 
            this.CurrentCityLabel.AutoSize = true;
            this.CurrentCityLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentCityLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CurrentCityLabel.Location = new System.Drawing.Point(4, 838);
            this.CurrentCityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentCityLabel.Name = "CurrentCityLabel";
            this.CurrentCityLabel.Size = new System.Drawing.Size(194, 39);
            this.CurrentCityLabel.TabIndex = 11;
            this.CurrentCityLabel.Text = "Current city:";
            // 
            // UserHomeTown
            // 
            this.UserHomeTown.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Hometown.Name", true));
            this.UserHomeTown.Font = new System.Drawing.Font("Tahoma", 10F);
            this.UserHomeTown.Location = new System.Drawing.Point(328, 769);
            this.UserHomeTown.Name = "UserHomeTown";
            this.UserHomeTown.Size = new System.Drawing.Size(163, 35);
            this.UserHomeTown.TabIndex = 15;
            this.UserHomeTown.Text = "UnKnown";
            // 
            // UsersBirthdate
            // 
            this.UsersBirthdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Birthday", true));
            this.UsersBirthdate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.UsersBirthdate.Location = new System.Drawing.Point(328, 700);
            this.UsersBirthdate.Name = "UsersBirthdate";
            this.UsersBirthdate.Size = new System.Drawing.Size(136, 33);
            this.UsersBirthdate.TabIndex = 16;
            this.UsersBirthdate.Text = "UnKnown";
            // 
            // UserCurrentCity
            // 
            this.UserCurrentCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Location.Name", true));
            this.UserCurrentCity.Font = new System.Drawing.Font("Tahoma", 10F);
            this.UserCurrentCity.Location = new System.Drawing.Point(329, 850);
            this.UserCurrentCity.Name = "UserCurrentCity";
            this.UserCurrentCity.Size = new System.Drawing.Size(125, 27);
            this.UserCurrentCity.TabIndex = 17;
            this.UserCurrentCity.Text = "Unknown";
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(2104, 1077);
            this.Controls.Add(this.UserCurrentCity);
            this.Controls.Add(this.UsersBirthdate);
            this.Controls.Add(this.UserHomeTown);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.CurrentCityLabel);
            this.Controls.Add(this.HomeTownLable);
            this.Controls.Add(this.UsersDetailsControlTab);
            this.Controls.Add(this.UserRelationshipLabel);
            this.Controls.Add(this.UserGenderLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.BirthDateLabel);
            this.Controls.Add(this.RelationshipLabel);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.UserProfilePicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserProfileForm";
            this.Text = "UserProfileForm";
            this.Shown += new System.EventHandler(this.UserProfileForm_Shown);
            this.UsersDetailsControlTab.ResumeLayout(false);
            this.UserWallTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClearImagePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttachPhotoPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPhotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UserProfilePicture;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TabControl UsersDetailsControlTab;
        private System.Windows.Forms.TabPage FriendsTab;
        private System.Windows.Forms.TabPage AlbumsTab;
        private System.Windows.Forms.TabPage CheckInsTab;
        private System.Windows.Forms.TabPage UserWallTab;
        private System.Windows.Forms.Button PostButton;
        private System.Windows.Forms.RichTextBox PostTextBox;
        private System.Windows.Forms.OpenFileDialog PictureFileDialog;
        private System.Windows.Forms.PictureBox PreviewPhotoPictureBox;
        private Components.UserControls.ClickablePictureBox AttachPhotoPictureBox1;
        private Components.UserControls.ClickablePictureBox ClearImagePictureBox1;
        private System.Windows.Forms.TabPage EventsTab;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TabPage SmartPostTab;
        private System.Windows.Forms.TabPage FriendshipMatchTab;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Label UserHomeTown;
        private System.Windows.Forms.Label CurrentCityLabel;
        private System.Windows.Forms.Label HomeTownLable;
        private System.Windows.Forms.Label UserRelationshipLabel;
        private System.Windows.Forms.Label UserGenderLabel;
        private System.Windows.Forms.Label BirthDateLabel;
        private System.Windows.Forms.Label RelationshipLabel;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label UsersBirthdate;
        private System.Windows.Forms.Label UserCurrentCity;
    }
}