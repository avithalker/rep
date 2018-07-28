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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfileForm));
            this.GenderLabel = new System.Windows.Forms.Label();
            this.RelationshipLabel = new System.Windows.Forms.Label();
            this.BirthDateLabel = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserGenderLabel = new System.Windows.Forms.Label();
            this.UserRelationshipLabel = new System.Windows.Forms.Label();
            this.UsersBirthdate = new System.Windows.Forms.Label();
            this.UsersDetailsControlTab = new System.Windows.Forms.TabControl();
            this.UserWallTab = new System.Windows.Forms.TabPage();
            this.ClearImagePictureBox1 = new DesktopFacebook.Components.UserControls.ClickablePictureBox();
            this.AttachPhotoPictureBox1 = new DesktopFacebook.Components.UserControls.ClickablePictureBox();
            this.PreviewPhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.PostTextBox = new System.Windows.Forms.RichTextBox();
            this.PostButton = new System.Windows.Forms.Button();
            this.FriendsTab = new System.Windows.Forms.TabPage();
            this.AlbumsTab = new System.Windows.Forms.TabPage();
            this.SelectedAlbumNameLabel = new System.Windows.Forms.Label();
            this.AlbumPicturesPanel = new System.Windows.Forms.Panel();
            this.AlbumsPanel = new System.Windows.Forms.Panel();
            this.PostsTab = new System.Windows.Forms.TabPage();
            this.RecentPostsLink = new System.Windows.Forms.LinkLabel();
            this.TopFiveLink = new System.Windows.Forms.LinkLabel();
            this.RecentPostsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TopFivePostsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckInsTab = new System.Windows.Forms.TabPage();
            this.CheckinGroupBox = new System.Windows.Forms.GroupBox();
            this.CheckinFriendsOutputLabel = new System.Windows.Forms.Label();
            this.CheckinDateOutputLbel = new System.Windows.Forms.Label();
            this.CheckinLocationOutputLabel = new System.Windows.Forms.Label();
            this.CheckinMessgeOutputLabel = new System.Windows.Forms.Label();
            this.CheckinFriendsLbael = new System.Windows.Forms.Label();
            this.CheckinDateLabel = new System.Windows.Forms.Label();
            this.CheckinMessageLabel = new System.Windows.Forms.Label();
            this.CheckinLocationLabel = new System.Windows.Forms.Label();
            this.CheckinListLabel = new System.Windows.Forms.Label();
            this.CheckinsListBox = new System.Windows.Forms.ListBox();
            this.HomeTownLable = new System.Windows.Forms.Label();
            this.CurrentCityLabel = new System.Windows.Forms.Label();
            this.UserHomeTownLabel = new System.Windows.Forms.Label();
            this.UserCurrentCityLabel = new System.Windows.Forms.Label();
            this.PictureFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.UserProfilePicture = new System.Windows.Forms.PictureBox();
            this.UsersDetailsControlTab.SuspendLayout();
            this.UserWallTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClearImagePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttachPhotoPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPhotoPictureBox)).BeginInit();
            this.AlbumsTab.SuspendLayout();
            this.PostsTab.SuspendLayout();
            this.CheckInsTab.SuspendLayout();
            this.CheckinGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenderLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GenderLabel.Location = new System.Drawing.Point(2, 279);
            this.GenderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(66, 19);
            this.GenderLabel.TabIndex = 2;
            this.GenderLabel.Text = "Gender:";
            // 
            // RelationshipLabel
            // 
            this.RelationshipLabel.AutoSize = true;
            this.RelationshipLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RelationshipLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.RelationshipLabel.Location = new System.Drawing.Point(2, 321);
            this.RelationshipLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RelationshipLabel.Name = "RelationshipLabel";
            this.RelationshipLabel.Size = new System.Drawing.Size(147, 19);
            this.RelationshipLabel.TabIndex = 3;
            this.RelationshipLabel.Text = "Relationship status:";
            // 
            // BirthDateLabel
            // 
            this.BirthDateLabel.AutoSize = true;
            this.BirthDateLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BirthDateLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BirthDateLabel.Location = new System.Drawing.Point(2, 361);
            this.BirthDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BirthDateLabel.Name = "BirthDateLabel";
            this.BirthDateLabel.Size = new System.Drawing.Size(85, 19);
            this.BirthDateLabel.TabIndex = 4;
            this.BirthDateLabel.Text = "Birth Date:";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.UserNameLabel.Location = new System.Drawing.Point(9, 211);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(0, 33);
            this.UserNameLabel.TabIndex = 5;
            // 
            // UserGenderLabel
            // 
            this.UserGenderLabel.AutoSize = true;
            this.UserGenderLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserGenderLabel.Location = new System.Drawing.Point(164, 282);
            this.UserGenderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserGenderLabel.Name = "UserGenderLabel";
            this.UserGenderLabel.Size = new System.Drawing.Size(0, 17);
            this.UserGenderLabel.TabIndex = 6;
            // 
            // UserRelationshipLabel
            // 
            this.UserRelationshipLabel.AutoSize = true;
            this.UserRelationshipLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserRelationshipLabel.Location = new System.Drawing.Point(164, 323);
            this.UserRelationshipLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserRelationshipLabel.Name = "UserRelationshipLabel";
            this.UserRelationshipLabel.Size = new System.Drawing.Size(66, 17);
            this.UserRelationshipLabel.TabIndex = 7;
            this.UserRelationshipLabel.Text = "Unknown";
            // 
            // UsersBirthdate
            // 
            this.UsersBirthdate.AutoSize = true;
            this.UsersBirthdate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersBirthdate.Location = new System.Drawing.Point(164, 364);
            this.UsersBirthdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsersBirthdate.Name = "UsersBirthdate";
            this.UsersBirthdate.Size = new System.Drawing.Size(0, 17);
            this.UsersBirthdate.TabIndex = 8;
            // 
            // UsersDetailsControlTab
            // 
            this.UsersDetailsControlTab.Controls.Add(this.UserWallTab);
            this.UsersDetailsControlTab.Controls.Add(this.FriendsTab);
            this.UsersDetailsControlTab.Controls.Add(this.AlbumsTab);
            this.UsersDetailsControlTab.Controls.Add(this.CheckInsTab);
            this.UsersDetailsControlTab.Controls.Add(this.PostsTab);
            this.UsersDetailsControlTab.Location = new System.Drawing.Point(305, 6);
            this.UsersDetailsControlTab.Margin = new System.Windows.Forms.Padding(2);
            this.UsersDetailsControlTab.Name = "UsersDetailsControlTab";
            this.UsersDetailsControlTab.SelectedIndex = 0;
            this.UsersDetailsControlTab.Size = new System.Drawing.Size(712, 508);
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
            this.UserWallTab.Location = new System.Drawing.Point(4, 22);
            this.UserWallTab.Margin = new System.Windows.Forms.Padding(2);
            this.UserWallTab.Name = "UserWallTab";
            this.UserWallTab.Size = new System.Drawing.Size(704, 482);
            this.UserWallTab.TabIndex = 4;
            this.UserWallTab.Text = "My wall";
            this.UserWallTab.UseVisualStyleBackColor = true;
            // 
            // ClearImagePictureBox1
            // 
            this.ClearImagePictureBox1.Image = global::DesktopFacebook.Properties.Resources.Clear;
            this.ClearImagePictureBox1.Location = new System.Drawing.Point(545, 15);
            this.ClearImagePictureBox1.Name = "ClearImagePictureBox1";
            this.ClearImagePictureBox1.Size = new System.Drawing.Size(25, 25);
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
            this.AttachPhotoPictureBox1.Location = new System.Drawing.Point(15, 102);
            this.AttachPhotoPictureBox1.Name = "AttachPhotoPictureBox1";
            this.AttachPhotoPictureBox1.Size = new System.Drawing.Size(42, 35);
            this.AttachPhotoPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AttachPhotoPictureBox1.TabIndex = 6;
            this.AttachPhotoPictureBox1.TabStop = false;
            this.AttachPhotoPictureBox1.Click += new System.EventHandler(this.AttachPhotoPictureBox1_Click);
            // 
            // PreviewPhotoPictureBox
            // 
            this.PreviewPhotoPictureBox.Location = new System.Drawing.Point(545, 15);
            this.PreviewPhotoPictureBox.Name = "PreviewPhotoPictureBox";
            this.PreviewPhotoPictureBox.Size = new System.Drawing.Size(140, 140);
            this.PreviewPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPhotoPictureBox.TabIndex = 4;
            this.PreviewPhotoPictureBox.TabStop = false;
            // 
            // PostTextBox
            // 
            this.PostTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.PostTextBox.Location = new System.Drawing.Point(15, 15);
            this.PostTextBox.Name = "PostTextBox";
            this.PostTextBox.Size = new System.Drawing.Size(524, 81);
            this.PostTextBox.TabIndex = 2;
            this.PostTextBox.Text = "What\'s on your mind?";
            this.PostTextBox.MouseEnter += new System.EventHandler(this.PostTextBox_MouseEnter);
            this.PostTextBox.MouseLeave += new System.EventHandler(this.PostTextBox_MouseLeave);
            // 
            // PostButton
            // 
            this.PostButton.Location = new System.Drawing.Point(94, 115);
            this.PostButton.Margin = new System.Windows.Forms.Padding(2);
            this.PostButton.Name = "PostButton";
            this.PostButton.Size = new System.Drawing.Size(102, 22);
            this.PostButton.TabIndex = 0;
            this.PostButton.Text = "Post";
            this.PostButton.UseVisualStyleBackColor = true;
            this.PostButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // FriendsTab
            // 
            this.FriendsTab.AutoScroll = true;
            this.FriendsTab.Location = new System.Drawing.Point(4, 22);
            this.FriendsTab.Margin = new System.Windows.Forms.Padding(2);
            this.FriendsTab.Name = "FriendsTab";
            this.FriendsTab.Padding = new System.Windows.Forms.Padding(2);
            this.FriendsTab.Size = new System.Drawing.Size(704, 482);
            this.FriendsTab.TabIndex = 0;
            this.FriendsTab.Text = "Friends";
            this.FriendsTab.UseVisualStyleBackColor = true;
            // 
            // AlbumsTab
            // 
            this.AlbumsTab.Controls.Add(this.SelectedAlbumNameLabel);
            this.AlbumsTab.Controls.Add(this.AlbumPicturesPanel);
            this.AlbumsTab.Controls.Add(this.AlbumsPanel);
            this.AlbumsTab.Location = new System.Drawing.Point(4, 22);
            this.AlbumsTab.Margin = new System.Windows.Forms.Padding(2);
            this.AlbumsTab.Name = "AlbumsTab";
            this.AlbumsTab.Size = new System.Drawing.Size(704, 482);
            this.AlbumsTab.TabIndex = 2;
            this.AlbumsTab.Text = "Albums";
            this.AlbumsTab.UseVisualStyleBackColor = true;
            // 
            // SelectedAlbumNameLabel
            // 
            this.SelectedAlbumNameLabel.AutoSize = true;
            this.SelectedAlbumNameLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedAlbumNameLabel.Location = new System.Drawing.Point(222, 13);
            this.SelectedAlbumNameLabel.Name = "SelectedAlbumNameLabel";
            this.SelectedAlbumNameLabel.Size = new System.Drawing.Size(163, 16);
            this.SelectedAlbumNameLabel.TabIndex = 3;
            this.SelectedAlbumNameLabel.Text = "Non album was selected";
            // 
            // AlbumPicturesPanel
            // 
            this.AlbumPicturesPanel.AutoScroll = true;
            this.AlbumPicturesPanel.Location = new System.Drawing.Point(222, 42);
            this.AlbumPicturesPanel.Name = "AlbumPicturesPanel";
            this.AlbumPicturesPanel.Size = new System.Drawing.Size(465, 428);
            this.AlbumPicturesPanel.TabIndex = 2;
            // 
            // AlbumsPanel
            // 
            this.AlbumsPanel.AutoScroll = true;
            this.AlbumsPanel.Location = new System.Drawing.Point(2, 2);
            this.AlbumsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.AlbumsPanel.Name = "AlbumsPanel";
            this.AlbumsPanel.Size = new System.Drawing.Size(207, 480);
            this.AlbumsPanel.TabIndex = 1;
            // 
            // PostsTab
            // 
            this.PostsTab.Controls.Add(this.RecentPostsLink);
            this.PostsTab.Controls.Add(this.TopFiveLink);
            this.PostsTab.Controls.Add(this.RecentPostsListBox);
            this.PostsTab.Controls.Add(this.label2);
            this.PostsTab.Controls.Add(this.TopFivePostsListBox);
            this.PostsTab.Controls.Add(this.label1);
            this.PostsTab.Location = new System.Drawing.Point(4, 22);
            this.PostsTab.Margin = new System.Windows.Forms.Padding(2);
            this.PostsTab.Name = "PostsTab";
            this.PostsTab.Padding = new System.Windows.Forms.Padding(2);
            this.PostsTab.Size = new System.Drawing.Size(704, 482);
            this.PostsTab.TabIndex = 1;
            this.PostsTab.Text = "Posts";
            this.PostsTab.UseVisualStyleBackColor = true;
            // 
            // RecentPostsLink
            // 
            this.RecentPostsLink.AutoSize = true;
            this.RecentPostsLink.Location = new System.Drawing.Point(478, 30);
            this.RecentPostsLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RecentPostsLink.Name = "RecentPostsLink";
            this.RecentPostsLink.Size = new System.Drawing.Size(95, 13);
            this.RecentPostsLink.TabIndex = 5;
            this.RecentPostsLink.TabStop = true;
            this.RecentPostsLink.Text = "Fetch recent posts";
            this.RecentPostsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RecentPostsLink_LinkClicked);
            // 
            // TopFiveLink
            // 
            this.TopFiveLink.AutoSize = true;
            this.TopFiveLink.Location = new System.Drawing.Point(150, 30);
            this.TopFiveLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TopFiveLink.Name = "TopFiveLink";
            this.TopFiveLink.Size = new System.Drawing.Size(100, 13);
            this.TopFiveLink.TabIndex = 4;
            this.TopFiveLink.TabStop = true;
            this.TopFiveLink.Text = "Fetch top five posts";
            this.TopFiveLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TopFiveLink_LinkClicked);
            // 
            // RecentPostsListBox
            // 
            this.RecentPostsListBox.FormattingEnabled = true;
            this.RecentPostsListBox.Location = new System.Drawing.Point(308, 44);
            this.RecentPostsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.RecentPostsListBox.Name = "RecentPostsListBox";
            this.RecentPostsListBox.Size = new System.Drawing.Size(266, 160);
            this.RecentPostsListBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Recent Posts";
            // 
            // TopFivePostsListBox
            // 
            this.TopFivePostsListBox.FormattingEnabled = true;
            this.TopFivePostsListBox.Location = new System.Drawing.Point(17, 44);
            this.TopFivePostsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.TopFivePostsListBox.Name = "TopFivePostsListBox";
            this.TopFivePostsListBox.Size = new System.Drawing.Size(235, 160);
            this.TopFivePostsListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top 5 Posts:";
            // 
            // CheckInsTab
            // 
            this.CheckInsTab.Controls.Add(this.CheckinGroupBox);
            this.CheckInsTab.Controls.Add(this.CheckinListLabel);
            this.CheckInsTab.Controls.Add(this.CheckinsListBox);
            this.CheckInsTab.Location = new System.Drawing.Point(4, 22);
            this.CheckInsTab.Margin = new System.Windows.Forms.Padding(2);
            this.CheckInsTab.Name = "CheckInsTab";
            this.CheckInsTab.Size = new System.Drawing.Size(704, 482);
            this.CheckInsTab.TabIndex = 3;
            this.CheckInsTab.Text = "CheckIns";
            this.CheckInsTab.UseVisualStyleBackColor = true;
            // 
            // CheckinGroupBox
            // 
            this.CheckinGroupBox.Controls.Add(this.CheckinFriendsOutputLabel);
            this.CheckinGroupBox.Controls.Add(this.CheckinDateOutputLbel);
            this.CheckinGroupBox.Controls.Add(this.CheckinLocationOutputLabel);
            this.CheckinGroupBox.Controls.Add(this.CheckinMessgeOutputLabel);
            this.CheckinGroupBox.Controls.Add(this.CheckinFriendsLbael);
            this.CheckinGroupBox.Controls.Add(this.CheckinDateLabel);
            this.CheckinGroupBox.Controls.Add(this.CheckinMessageLabel);
            this.CheckinGroupBox.Controls.Add(this.CheckinLocationLabel);
            this.CheckinGroupBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckinGroupBox.Location = new System.Drawing.Point(331, 69);
            this.CheckinGroupBox.Name = "CheckinGroupBox";
            this.CheckinGroupBox.Size = new System.Drawing.Size(334, 244);
            this.CheckinGroupBox.TabIndex = 3;
            this.CheckinGroupBox.TabStop = false;
            this.CheckinGroupBox.Text = "Extended information";
            // 
            // CheckinFriendsOutputLabel
            // 
            this.CheckinFriendsOutputLabel.AutoSize = true;
            this.CheckinFriendsOutputLabel.Location = new System.Drawing.Point(114, 162);
            this.CheckinFriendsOutputLabel.Name = "CheckinFriendsOutputLabel";
            this.CheckinFriendsOutputLabel.Size = new System.Drawing.Size(0, 16);
            this.CheckinFriendsOutputLabel.TabIndex = 6;
            // 
            // CheckinDateOutputLbel
            // 
            this.CheckinDateOutputLbel.AutoSize = true;
            this.CheckinDateOutputLbel.Location = new System.Drawing.Point(114, 122);
            this.CheckinDateOutputLbel.Name = "CheckinDateOutputLbel";
            this.CheckinDateOutputLbel.Size = new System.Drawing.Size(0, 16);
            this.CheckinDateOutputLbel.TabIndex = 4;
            // 
            // CheckinLocationOutputLabel
            // 
            this.CheckinLocationOutputLabel.AutoSize = true;
            this.CheckinLocationOutputLabel.Location = new System.Drawing.Point(114, 81);
            this.CheckinLocationOutputLabel.Name = "CheckinLocationOutputLabel";
            this.CheckinLocationOutputLabel.Size = new System.Drawing.Size(0, 16);
            this.CheckinLocationOutputLabel.TabIndex = 5;
            // 
            // CheckinMessgeOutputLabel
            // 
            this.CheckinMessgeOutputLabel.AutoSize = true;
            this.CheckinMessgeOutputLabel.Location = new System.Drawing.Point(114, 41);
            this.CheckinMessgeOutputLabel.Name = "CheckinMessgeOutputLabel";
            this.CheckinMessgeOutputLabel.Size = new System.Drawing.Size(0, 16);
            this.CheckinMessgeOutputLabel.TabIndex = 4;
            // 
            // CheckinFriendsLbael
            // 
            this.CheckinFriendsLbael.AutoSize = true;
            this.CheckinFriendsLbael.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckinFriendsLbael.Location = new System.Drawing.Point(6, 162);
            this.CheckinFriendsLbael.Name = "CheckinFriendsLbael";
            this.CheckinFriendsLbael.Size = new System.Drawing.Size(59, 16);
            this.CheckinFriendsLbael.TabIndex = 3;
            this.CheckinFriendsLbael.Text = "Friends:";
            // 
            // CheckinDateLabel
            // 
            this.CheckinDateLabel.AutoSize = true;
            this.CheckinDateLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckinDateLabel.Location = new System.Drawing.Point(6, 122);
            this.CheckinDateLabel.Name = "CheckinDateLabel";
            this.CheckinDateLabel.Size = new System.Drawing.Size(44, 16);
            this.CheckinDateLabel.TabIndex = 2;
            this.CheckinDateLabel.Text = "Date:";
            // 
            // CheckinMessageLabel
            // 
            this.CheckinMessageLabel.AutoSize = true;
            this.CheckinMessageLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckinMessageLabel.Location = new System.Drawing.Point(6, 41);
            this.CheckinMessageLabel.Name = "CheckinMessageLabel";
            this.CheckinMessageLabel.Size = new System.Drawing.Size(70, 16);
            this.CheckinMessageLabel.TabIndex = 1;
            this.CheckinMessageLabel.Text = "Message:";
            // 
            // CheckinLocationLabel
            // 
            this.CheckinLocationLabel.AutoSize = true;
            this.CheckinLocationLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckinLocationLabel.Location = new System.Drawing.Point(6, 81);
            this.CheckinLocationLabel.Name = "CheckinLocationLabel";
            this.CheckinLocationLabel.Size = new System.Drawing.Size(68, 16);
            this.CheckinLocationLabel.TabIndex = 0;
            this.CheckinLocationLabel.Text = "Location:";
            // 
            // CheckinListLabel
            // 
            this.CheckinListLabel.AutoSize = true;
            this.CheckinListLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckinListLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CheckinListLabel.Location = new System.Drawing.Point(23, 24);
            this.CheckinListLabel.Name = "CheckinListLabel";
            this.CheckinListLabel.Size = new System.Drawing.Size(109, 19);
            this.CheckinListLabel.TabIndex = 2;
            this.CheckinListLabel.Text = "Checkin list:";
            // 
            // CheckinsListBox
            // 
            this.CheckinsListBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckinsListBox.FormattingEnabled = true;
            this.CheckinsListBox.ItemHeight = 16;
            this.CheckinsListBox.Location = new System.Drawing.Point(27, 69);
            this.CheckinsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.CheckinsListBox.Name = "CheckinsListBox";
            this.CheckinsListBox.Size = new System.Drawing.Size(236, 244);
            this.CheckinsListBox.TabIndex = 0;
            this.CheckinsListBox.SelectedIndexChanged += new System.EventHandler(this.CheckinsListBox_SelectedIndexChanged);
            // 
            // HomeTownLable
            // 
            this.HomeTownLable.AutoSize = true;
            this.HomeTownLable.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeTownLable.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HomeTownLable.Location = new System.Drawing.Point(2, 400);
            this.HomeTownLable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HomeTownLable.Name = "HomeTownLable";
            this.HomeTownLable.Size = new System.Drawing.Size(97, 19);
            this.HomeTownLable.TabIndex = 10;
            this.HomeTownLable.Text = "HomeTown:";
            // 
            // CurrentCityLabel
            // 
            this.CurrentCityLabel.AutoSize = true;
            this.CurrentCityLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentCityLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CurrentCityLabel.Location = new System.Drawing.Point(2, 436);
            this.CurrentCityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentCityLabel.Name = "CurrentCityLabel";
            this.CurrentCityLabel.Size = new System.Drawing.Size(97, 19);
            this.CurrentCityLabel.TabIndex = 11;
            this.CurrentCityLabel.Text = "Current city:";
            // 
            // UserHomeTownLabel
            // 
            this.UserHomeTownLabel.AutoSize = true;
            this.UserHomeTownLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserHomeTownLabel.Location = new System.Drawing.Point(164, 403);
            this.UserHomeTownLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserHomeTownLabel.Name = "UserHomeTownLabel";
            this.UserHomeTownLabel.Size = new System.Drawing.Size(66, 17);
            this.UserHomeTownLabel.TabIndex = 12;
            this.UserHomeTownLabel.Text = "Unknown";
            // 
            // UserCurrentCityLabel
            // 
            this.UserCurrentCityLabel.AutoSize = true;
            this.UserCurrentCityLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserCurrentCityLabel.Location = new System.Drawing.Point(164, 436);
            this.UserCurrentCityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserCurrentCityLabel.Name = "UserCurrentCityLabel";
            this.UserCurrentCityLabel.Size = new System.Drawing.Size(66, 17);
            this.UserCurrentCityLabel.TabIndex = 13;
            this.UserCurrentCityLabel.Text = "Unknown";
            // 
            // PictureFileDialog
            // 
            this.PictureFileDialog.FileName = "openFileDialog1";
            // 
            // UserProfilePicture
            // 
            this.UserProfilePicture.Location = new System.Drawing.Point(6, 6);
            this.UserProfilePicture.Margin = new System.Windows.Forms.Padding(2);
            this.UserProfilePicture.Name = "UserProfilePicture";
            this.UserProfilePicture.Size = new System.Drawing.Size(210, 203);
            this.UserProfilePicture.TabIndex = 0;
            this.UserProfilePicture.TabStop = false;
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1096, 585);
            this.Controls.Add(this.UserCurrentCityLabel);
            this.Controls.Add(this.UserHomeTownLabel);
            this.Controls.Add(this.CurrentCityLabel);
            this.Controls.Add(this.HomeTownLable);
            this.Controls.Add(this.UsersDetailsControlTab);
            this.Controls.Add(this.UsersBirthdate);
            this.Controls.Add(this.UserRelationshipLabel);
            this.Controls.Add(this.UserGenderLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.BirthDateLabel);
            this.Controls.Add(this.RelationshipLabel);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.UserProfilePicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserProfileForm";
            this.Text = "UserProfileForm";
            this.Shown += new System.EventHandler(this.UserProfileForm_Shown);
            this.UsersDetailsControlTab.ResumeLayout(false);
            this.UserWallTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClearImagePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttachPhotoPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPhotoPictureBox)).EndInit();
            this.AlbumsTab.ResumeLayout(false);
            this.AlbumsTab.PerformLayout();
            this.PostsTab.ResumeLayout(false);
            this.PostsTab.PerformLayout();
            this.CheckInsTab.ResumeLayout(false);
            this.CheckInsTab.PerformLayout();
            this.CheckinGroupBox.ResumeLayout(false);
            this.CheckinGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UserProfilePicture;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label RelationshipLabel;
        private System.Windows.Forms.Label BirthDateLabel;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label UserGenderLabel;
        private System.Windows.Forms.Label UserRelationshipLabel;
        private System.Windows.Forms.Label UsersBirthdate;
        private System.Windows.Forms.TabControl UsersDetailsControlTab;
        private System.Windows.Forms.TabPage FriendsTab;
        private System.Windows.Forms.TabPage PostsTab;
        private System.Windows.Forms.TabPage AlbumsTab;
        private System.Windows.Forms.TabPage CheckInsTab;
        private System.Windows.Forms.TabPage UserWallTab;
        private System.Windows.Forms.Button PostButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox TopFivePostsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox RecentPostsListBox;
        private System.Windows.Forms.LinkLabel RecentPostsLink;
        private System.Windows.Forms.LinkLabel TopFiveLink;
        private System.Windows.Forms.ListBox CheckinsListBox;
        private System.Windows.Forms.Panel AlbumsPanel;
        private System.Windows.Forms.Label HomeTownLable;
        private System.Windows.Forms.Label CurrentCityLabel;
        private System.Windows.Forms.Label UserHomeTownLabel;
        private System.Windows.Forms.Label UserCurrentCityLabel;
        private System.Windows.Forms.RichTextBox PostTextBox;
        private System.Windows.Forms.OpenFileDialog PictureFileDialog;
        private System.Windows.Forms.PictureBox PreviewPhotoPictureBox;
        private Components.UserControls.ClickablePictureBox AttachPhotoPictureBox1;
        private Components.UserControls.ClickablePictureBox ClearImagePictureBox1;
        private System.Windows.Forms.Panel AlbumPicturesPanel;
        private System.Windows.Forms.Label SelectedAlbumNameLabel;
        private System.Windows.Forms.GroupBox CheckinGroupBox;
        private System.Windows.Forms.Label CheckinFriendsOutputLabel;
        private System.Windows.Forms.Label CheckinDateOutputLbel;
        private System.Windows.Forms.Label CheckinLocationOutputLabel;
        private System.Windows.Forms.Label CheckinMessgeOutputLabel;
        private System.Windows.Forms.Label CheckinFriendsLbael;
        private System.Windows.Forms.Label CheckinDateLabel;
        private System.Windows.Forms.Label CheckinMessageLabel;
        private System.Windows.Forms.Label CheckinLocationLabel;
        private System.Windows.Forms.Label CheckinListLabel;
    }
}