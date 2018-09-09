namespace DesktopFacebook.Components.Pages
{
    partial class FriendshipMatchScalePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChooseAFriendLabel = new System.Windows.Forms.Label();
            this.MatchScaleLabel = new System.Windows.Forms.Label();
            this.FriendshipMatchValue = new System.Windows.Forms.Label();
            this.FriendshipMatchButton = new System.Windows.Forms.Button();
            this.FriendsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CategoriesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ChooseAFriendLabel
            // 
            this.ChooseAFriendLabel.AutoSize = true;
            this.ChooseAFriendLabel.Location = new System.Drawing.Point(41, 56);
            this.ChooseAFriendLabel.Name = "ChooseAFriendLabel";
            this.ChooseAFriendLabel.Size = new System.Drawing.Size(422, 25);
            this.ChooseAFriendLabel.TabIndex = 0;
            this.ChooseAFriendLabel.Text = "choose a friend to check your match scale:";
            // 
            // MatchScaleLabel
            // 
            this.MatchScaleLabel.AutoSize = true;
            this.MatchScaleLabel.Location = new System.Drawing.Point(41, 526);
            this.MatchScaleLabel.Name = "MatchScaleLabel";
            this.MatchScaleLabel.Size = new System.Drawing.Size(303, 25);
            this.MatchScaleLabel.TabIndex = 2;
            this.MatchScaleLabel.Text = "your friendship match scale is:";
            // 
            // FriendshipMatchValue
            // 
            this.FriendshipMatchValue.AutoSize = true;
            this.FriendshipMatchValue.Font = new System.Drawing.Font("Microsoft New Tai Lue", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FriendshipMatchValue.Location = new System.Drawing.Point(363, 526);
            this.FriendshipMatchValue.Name = "FriendshipMatchValue";
            this.FriendshipMatchValue.Size = new System.Drawing.Size(0, 52);
            this.FriendshipMatchValue.TabIndex = 3;
            // 
            // FriendshipMatchButton
            // 
            this.FriendshipMatchButton.Location = new System.Drawing.Point(46, 441);
            this.FriendshipMatchButton.Name = "FriendshipMatchButton";
            this.FriendshipMatchButton.Size = new System.Drawing.Size(368, 57);
            this.FriendshipMatchButton.TabIndex = 4;
            this.FriendshipMatchButton.Text = "Check Friendship Match Scale";
            this.FriendshipMatchButton.UseVisualStyleBackColor = true;
            this.FriendshipMatchButton.Click += new System.EventHandler(this.FriendshipMatchButton_Click);
            // 
            // FriendsListBox
            // 
            this.FriendsListBox.FormattingEnabled = true;
            this.FriendsListBox.ItemHeight = 25;
            this.FriendsListBox.Location = new System.Drawing.Point(46, 84);
            this.FriendsListBox.Name = "FriendsListBox";
            this.FriendsListBox.Size = new System.Drawing.Size(368, 354);
            this.FriendsListBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Match values by Categories:";
            // 
            // CategoriesListBox
            // 
            this.CategoriesListBox.FormattingEnabled = true;
            this.CategoriesListBox.ItemHeight = 25;
            this.CategoriesListBox.Location = new System.Drawing.Point(573, 107);
            this.CategoriesListBox.Name = "CategoriesListBox";
            this.CategoriesListBox.Size = new System.Drawing.Size(291, 254);
            this.CategoriesListBox.TabIndex = 7;
            // 
            // FriendshipMatchScalePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CategoriesListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FriendsListBox);
            this.Controls.Add(this.FriendshipMatchButton);
            this.Controls.Add(this.FriendshipMatchValue);
            this.Controls.Add(this.MatchScaleLabel);
            this.Controls.Add(this.ChooseAFriendLabel);
            this.Name = "FriendshipMatchScalePage";
            this.Size = new System.Drawing.Size(1198, 836);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChooseAFriendLabel;
        private System.Windows.Forms.Label MatchScaleLabel;
        private System.Windows.Forms.Label FriendshipMatchValue;
        private System.Windows.Forms.Button FriendshipMatchButton;
        private System.Windows.Forms.ListBox FriendsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox CategoriesListBox;
    }
}
