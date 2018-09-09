namespace DesktopFacebook.Components.UserControls
{
    partial class WallPostControl
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
            this.PostLabel = new System.Windows.Forms.Label();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PosterNameLabel = new System.Windows.Forms.Label();
            this.PostDateLabel = new System.Windows.Forms.Label();
            this.TotalLikesLabel = new System.Windows.Forms.Label();
            this.DeletePostButton1 = new DesktopFacebook.Components.UserControls.ClickablePictureBox();
            this.WallPostLikeButton1 = new DesktopFacebook.Components.UserControls.ClickablePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DeletePostButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WallPostLikeButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // PostLabel
            // 
            this.PostLabel.AutoSize = true;
            this.PostLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostLabel.Location = new System.Drawing.Point(19, 41);
            this.PostLabel.Name = "PostLabel";
            this.PostLabel.Size = new System.Drawing.Size(57, 16);
            this.PostLabel.TabIndex = 0;
            this.PostLabel.Text = "Post text";
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentTextBox.Location = new System.Drawing.Point(22, 99);
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(280, 23);
            this.CommentTextBox.TabIndex = 1;
            this.CommentTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommentTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Posted by:";
            // 
            // PosterNameLabel
            // 
            this.PosterNameLabel.AutoSize = true;
            this.PosterNameLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PosterNameLabel.Location = new System.Drawing.Point(103, 70);
            this.PosterNameLabel.Name = "PosterNameLabel";
            this.PosterNameLabel.Size = new System.Drawing.Size(41, 16);
            this.PosterNameLabel.TabIndex = 3;
            this.PosterNameLabel.Text = "Name";
            // 
            // PostDateLabel
            // 
            this.PostDateLabel.AutoSize = true;
            this.PostDateLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostDateLabel.Location = new System.Drawing.Point(489, 41);
            this.PostDateLabel.Name = "PostDateLabel";
            this.PostDateLabel.Size = new System.Drawing.Size(34, 16);
            this.PostDateLabel.TabIndex = 4;
            this.PostDateLabel.Text = "Date";
            // 
            // TotalLikesLabel
            // 
            this.TotalLikesLabel.AutoSize = true;
            this.TotalLikesLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalLikesLabel.Location = new System.Drawing.Point(63, 137);
            this.TotalLikesLabel.Name = "TotalLikesLabel";
            this.TotalLikesLabel.Size = new System.Drawing.Size(16, 16);
            this.TotalLikesLabel.TabIndex = 6;
            this.TotalLikesLabel.Text = "0";
            // 
            // DeletePostButton1
            // 
            this.DeletePostButton1.Image = global::DesktopFacebook.Properties.Resources.Delete;
            this.DeletePostButton1.Location = new System.Drawing.Point(3, 0);
            this.DeletePostButton1.Name = "DeletePostButton1";
            this.DeletePostButton1.Size = new System.Drawing.Size(30, 30);
            this.DeletePostButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeletePostButton1.TabIndex = 9;
            this.DeletePostButton1.TabStop = false;
            this.DeletePostButton1.Click += new System.EventHandler(this.DeletePostButton1_Click);
            // 
            // WallPostLikeButton1
            // 
            this.WallPostLikeButton1.BackColor = System.Drawing.Color.Transparent;
            this.WallPostLikeButton1.Image = global::DesktopFacebook.Properties.Resources.Like;
            this.WallPostLikeButton1.Location = new System.Drawing.Point(22, 128);
            this.WallPostLikeButton1.Name = "WallPostLikeButton1";
            this.WallPostLikeButton1.Size = new System.Drawing.Size(30, 30);
            this.WallPostLikeButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WallPostLikeButton1.TabIndex = 10;
            this.WallPostLikeButton1.TabStop = false;
            this.WallPostLikeButton1.Click += new System.EventHandler(this.WallPostLikeButton1_Click);
            // 
            // WallPostControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.WallPostLikeButton1);
            this.Controls.Add(this.DeletePostButton1);
            this.Controls.Add(this.TotalLikesLabel);
            this.Controls.Add(this.PostDateLabel);
            this.Controls.Add(this.PosterNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.PostLabel);
            this.Name = "WallPostControl";
            this.Size = new System.Drawing.Size(618, 176);
            ((System.ComponentModel.ISupportInitialize)(this.DeletePostButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WallPostLikeButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PostLabel;
        private System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PosterNameLabel;
        private System.Windows.Forms.Label PostDateLabel;
        private System.Windows.Forms.Label TotalLikesLabel;
        private ClickablePictureBox DeletePostButton1;
        private ClickablePictureBox WallPostLikeButton1;
    }
}
