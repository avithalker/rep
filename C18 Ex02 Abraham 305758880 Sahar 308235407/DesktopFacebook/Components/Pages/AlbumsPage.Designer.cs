namespace DesktopFacebook.Components.Pages
{
    partial class AlbumsPage
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
            this.SelectedAlbumNameLabel = new System.Windows.Forms.Label();
            this.AlbumPicturesPanel = new System.Windows.Forms.Panel();
            this.AlbumsPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // SelectedAlbumNameLabel
            // 
            this.SelectedAlbumNameLabel.AutoSize = true;
            this.SelectedAlbumNameLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedAlbumNameLabel.Location = new System.Drawing.Point(230, 12);
            this.SelectedAlbumNameLabel.Name = "SelectedAlbumNameLabel";
            this.SelectedAlbumNameLabel.Size = new System.Drawing.Size(163, 16);
            this.SelectedAlbumNameLabel.TabIndex = 6;
            this.SelectedAlbumNameLabel.Text = "Non album was selected";
            // 
            // AlbumPicturesPanel
            // 
            this.AlbumPicturesPanel.AutoScroll = true;
            this.AlbumPicturesPanel.Location = new System.Drawing.Point(230, 41);
            this.AlbumPicturesPanel.Name = "AlbumPicturesPanel";
            this.AlbumPicturesPanel.Size = new System.Drawing.Size(465, 428);
            this.AlbumPicturesPanel.TabIndex = 5;
            // 
            // AlbumsPanel
            // 
            this.AlbumsPanel.AutoScroll = true;
            this.AlbumsPanel.Location = new System.Drawing.Point(10, 1);
            this.AlbumsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.AlbumsPanel.Name = "AlbumsPanel";
            this.AlbumsPanel.Size = new System.Drawing.Size(207, 480);
            this.AlbumsPanel.TabIndex = 4;
            // 
            // AlbumsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectedAlbumNameLabel);
            this.Controls.Add(this.AlbumPicturesPanel);
            this.Controls.Add(this.AlbumsPanel);
            this.Name = "AlbumsPage";
            this.Size = new System.Drawing.Size(704, 482);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectedAlbumNameLabel;
        private System.Windows.Forms.Panel AlbumPicturesPanel;
        private System.Windows.Forms.Panel AlbumsPanel;
    }
}
