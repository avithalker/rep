namespace DesktopFacebook.Components.UserControls
{
    partial class FacebookPostControl
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
            this.PostTextBox = new System.Windows.Forms.RichTextBox();
            this.PostButton = new System.Windows.Forms.Button();
            this.ClearImagePictureBox1 = new DesktopFacebook.Components.UserControls.ClickablePictureBox();
            this.AttachPhotoPictureBox1 = new DesktopFacebook.Components.UserControls.ClickablePictureBox();
            this.PreviewPhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.PictureFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ClearImagePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttachPhotoPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPhotoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PostTextBox
            // 
            this.PostTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.PostTextBox.Location = new System.Drawing.Point(17, 0);
            this.PostTextBox.Name = "PostTextBox";
            this.PostTextBox.Size = new System.Drawing.Size(524, 81);
            this.PostTextBox.TabIndex = 9;
            this.PostTextBox.Text = "What\'s on your mind?";
            this.PostTextBox.MouseEnter += new System.EventHandler(this.PostTextBox_MouseEnter);
            this.PostTextBox.MouseLeave += new System.EventHandler(this.PostTextBox_MouseLeave);
            // 
            // PostButton
            // 
            this.PostButton.Location = new System.Drawing.Point(96, 100);
            this.PostButton.Margin = new System.Windows.Forms.Padding(2);
            this.PostButton.Name = "PostButton";
            this.PostButton.Size = new System.Drawing.Size(102, 22);
            this.PostButton.TabIndex = 8;
            this.PostButton.Text = "Post";
            this.PostButton.UseVisualStyleBackColor = true;
            this.PostButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // ClearImagePictureBox1
            // 
            this.ClearImagePictureBox1.Image = global::DesktopFacebook.Properties.Resources.Clear;
            this.ClearImagePictureBox1.Location = new System.Drawing.Point(547, 0);
            this.ClearImagePictureBox1.Name = "ClearImagePictureBox1";
            this.ClearImagePictureBox1.Size = new System.Drawing.Size(25, 25);
            this.ClearImagePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ClearImagePictureBox1.TabIndex = 12;
            this.ClearImagePictureBox1.TabStop = false;
            this.ClearImagePictureBox1.Visible = false;
            this.ClearImagePictureBox1.Click += new System.EventHandler(this.ClearImagePictureBox1_Click);
            // 
            // AttachPhotoPictureBox1
            // 
            this.AttachPhotoPictureBox1.ErrorImage = null;
            this.AttachPhotoPictureBox1.Image = global::DesktopFacebook.Properties.Resources.ImagePlaceHolder;
            this.AttachPhotoPictureBox1.Location = new System.Drawing.Point(17, 87);
            this.AttachPhotoPictureBox1.Name = "AttachPhotoPictureBox1";
            this.AttachPhotoPictureBox1.Size = new System.Drawing.Size(42, 35);
            this.AttachPhotoPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AttachPhotoPictureBox1.TabIndex = 11;
            this.AttachPhotoPictureBox1.TabStop = false;
            this.AttachPhotoPictureBox1.Click += new System.EventHandler(this.AttachPhotoPictureBox1_Click);
            // 
            // PreviewPhotoPictureBox
            // 
            this.PreviewPhotoPictureBox.Location = new System.Drawing.Point(547, 0);
            this.PreviewPhotoPictureBox.Name = "PreviewPhotoPictureBox";
            this.PreviewPhotoPictureBox.Size = new System.Drawing.Size(140, 140);
            this.PreviewPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPhotoPictureBox.TabIndex = 10;
            this.PreviewPhotoPictureBox.TabStop = false;
            // 
            // PictureFileDialog
            // 
            this.PictureFileDialog.FileName = "openFileDialog1";
            // 
            // FacebookPostControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClearImagePictureBox1);
            this.Controls.Add(this.AttachPhotoPictureBox1);
            this.Controls.Add(this.PreviewPhotoPictureBox);
            this.Controls.Add(this.PostTextBox);
            this.Controls.Add(this.PostButton);
            this.Name = "FacebookPostControl";
            this.Size = new System.Drawing.Size(704, 140);
            ((System.ComponentModel.ISupportInitialize)(this.ClearImagePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttachPhotoPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPhotoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ClickablePictureBox ClearImagePictureBox1;
        private ClickablePictureBox AttachPhotoPictureBox1;
        private System.Windows.Forms.PictureBox PreviewPhotoPictureBox;
        private System.Windows.Forms.RichTextBox PostTextBox;
        private System.Windows.Forms.Button PostButton;
        private System.Windows.Forms.OpenFileDialog PictureFileDialog;
    }
}
