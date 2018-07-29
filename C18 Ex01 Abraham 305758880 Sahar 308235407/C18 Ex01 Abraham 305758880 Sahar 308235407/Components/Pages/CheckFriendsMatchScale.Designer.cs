namespace DesktopFacebook.Components.Pages
{
    partial class CheckFriendsMatchScale
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
            this.label1 = new System.Windows.Forms.Label();
            this.FriendsListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FriendshipMatchValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "choose a friend to check your match scale:";
            // 
            // FriendsListBox
            // 
            this.FriendsListBox.FormattingEnabled = true;
            this.FriendsListBox.Location = new System.Drawing.Point(66, 92);
            this.FriendsListBox.Name = "FriendsListBox";
            this.FriendsListBox.Size = new System.Drawing.Size(417, 342);
            this.FriendsListBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "your friendship match scale is:";
            // 
            // FriendshipMatchValue
            // 
            this.FriendshipMatchValue.AutoSize = true;
            this.FriendshipMatchValue.Location = new System.Drawing.Point(413, 488);
            this.FriendshipMatchValue.Name = "FriendshipMatchValue";
            this.FriendshipMatchValue.Size = new System.Drawing.Size(0, 25);
            this.FriendshipMatchValue.TabIndex = 3;
            // 
            // CheckFriendsMatchScale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FriendshipMatchValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FriendsListBox);
            this.Controls.Add(this.label1);
            this.Name = "CheckFriendsMatchScale";
            this.Size = new System.Drawing.Size(1198, 836);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox FriendsListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FriendshipMatchValue;
    }
}
