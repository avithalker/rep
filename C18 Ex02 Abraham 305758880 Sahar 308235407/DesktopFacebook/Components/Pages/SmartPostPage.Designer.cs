namespace DesktopFacebook.Components.Pages
{
    partial class SmartPostPage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Plus18RadioButton = new System.Windows.Forms.RadioButton();
            this.minus18RadioButton = new System.Windows.Forms.RadioButton();
            this.AgeFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.GenderCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DivorcedRadioButton = new System.Windows.Forms.RadioButton();
            this.MarriedRadioButton = new System.Windows.Forms.RadioButton();
            this.SingleRadioButton = new System.Windows.Forms.RadioButton();
            this.RealtionshipCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LivingCityTextbox = new System.Windows.Forms.TextBox();
            this.LivingCityCheckbox = new System.Windows.Forms.CheckBox();
            this.FilteredFriendsListbox = new System.Windows.Forms.ListBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.facebookPostControl1 = new DesktopFacebook.Components.UserControls.FacebookPostControl();
            this.CleanButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Plus18RadioButton);
            this.groupBox1.Controls.Add(this.minus18RadioButton);
            this.groupBox1.Controls.Add(this.AgeFilterCheckBox);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 274);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 92);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Age range";
            // 
            // Plus18RadioButton
            // 
            this.Plus18RadioButton.AutoSize = true;
            this.Plus18RadioButton.Enabled = false;
            this.Plus18RadioButton.Location = new System.Drawing.Point(83, 57);
            this.Plus18RadioButton.Name = "Plus18RadioButton";
            this.Plus18RadioButton.Size = new System.Drawing.Size(48, 20);
            this.Plus18RadioButton.TabIndex = 2;
            this.Plus18RadioButton.Text = "+18";
            this.Plus18RadioButton.UseVisualStyleBackColor = true;
            // 
            // minus18RadioButton
            // 
            this.minus18RadioButton.AutoSize = true;
            this.minus18RadioButton.Checked = true;
            this.minus18RadioButton.Enabled = false;
            this.minus18RadioButton.Location = new System.Drawing.Point(6, 57);
            this.minus18RadioButton.Name = "minus18RadioButton";
            this.minus18RadioButton.Size = new System.Drawing.Size(45, 20);
            this.minus18RadioButton.TabIndex = 1;
            this.minus18RadioButton.TabStop = true;
            this.minus18RadioButton.Text = "-18";
            this.minus18RadioButton.UseVisualStyleBackColor = true;
            // 
            // AgeFilterCheckBox
            // 
            this.AgeFilterCheckBox.AutoSize = true;
            this.AgeFilterCheckBox.Location = new System.Drawing.Point(6, 31);
            this.AgeFilterCheckBox.Name = "AgeFilterCheckBox";
            this.AgeFilterCheckBox.Size = new System.Drawing.Size(61, 20);
            this.AgeFilterCheckBox.TabIndex = 0;
            this.AgeFilterCheckBox.Text = "Active";
            this.AgeFilterCheckBox.UseVisualStyleBackColor = true;
            this.AgeFilterCheckBox.CheckedChanged += new System.EventHandler(this.AgeFilterCheckBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FemaleRadioButton);
            this.groupBox2.Controls.Add(this.MaleRadioButton);
            this.groupBox2.Controls.Add(this.GenderCheckBox);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 87);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gender";
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Enabled = false;
            this.FemaleRadioButton.Location = new System.Drawing.Point(89, 57);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(68, 20);
            this.FemaleRadioButton.TabIndex = 2;
            this.FemaleRadioButton.Text = "Female";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Checked = true;
            this.MaleRadioButton.Enabled = false;
            this.MaleRadioButton.Location = new System.Drawing.Point(6, 57);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(53, 20);
            this.MaleRadioButton.TabIndex = 1;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "Male";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // GenderCheckBox
            // 
            this.GenderCheckBox.AutoSize = true;
            this.GenderCheckBox.Location = new System.Drawing.Point(6, 31);
            this.GenderCheckBox.Name = "GenderCheckBox";
            this.GenderCheckBox.Size = new System.Drawing.Size(61, 20);
            this.GenderCheckBox.TabIndex = 0;
            this.GenderCheckBox.Text = "Active";
            this.GenderCheckBox.UseVisualStyleBackColor = true;
            this.GenderCheckBox.CheckedChanged += new System.EventHandler(this.GenderCheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DivorcedRadioButton);
            this.groupBox3.Controls.Add(this.MarriedRadioButton);
            this.groupBox3.Controls.Add(this.SingleRadioButton);
            this.groupBox3.Controls.Add(this.RealtionshipCheckbox);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(213, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 87);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Relationship";
            // 
            // DivorcedRadioButton
            // 
            this.DivorcedRadioButton.AutoSize = true;
            this.DivorcedRadioButton.Enabled = false;
            this.DivorcedRadioButton.Location = new System.Drawing.Point(152, 57);
            this.DivorcedRadioButton.Name = "DivorcedRadioButton";
            this.DivorcedRadioButton.Size = new System.Drawing.Size(75, 20);
            this.DivorcedRadioButton.TabIndex = 3;
            this.DivorcedRadioButton.Text = "Divorced";
            this.DivorcedRadioButton.UseVisualStyleBackColor = true;
            // 
            // MarriedRadioButton
            // 
            this.MarriedRadioButton.AutoSize = true;
            this.MarriedRadioButton.Enabled = false;
            this.MarriedRadioButton.Location = new System.Drawing.Point(73, 57);
            this.MarriedRadioButton.Name = "MarriedRadioButton";
            this.MarriedRadioButton.Size = new System.Drawing.Size(70, 20);
            this.MarriedRadioButton.TabIndex = 2;
            this.MarriedRadioButton.Text = "Married";
            this.MarriedRadioButton.UseVisualStyleBackColor = true;
            // 
            // SingleRadioButton
            // 
            this.SingleRadioButton.AutoSize = true;
            this.SingleRadioButton.Checked = true;
            this.SingleRadioButton.Enabled = false;
            this.SingleRadioButton.Location = new System.Drawing.Point(6, 57);
            this.SingleRadioButton.Name = "SingleRadioButton";
            this.SingleRadioButton.Size = new System.Drawing.Size(61, 20);
            this.SingleRadioButton.TabIndex = 1;
            this.SingleRadioButton.TabStop = true;
            this.SingleRadioButton.Text = "Single";
            this.SingleRadioButton.UseVisualStyleBackColor = true;
            // 
            // RealtionshipCheckbox
            // 
            this.RealtionshipCheckbox.AutoSize = true;
            this.RealtionshipCheckbox.Location = new System.Drawing.Point(6, 31);
            this.RealtionshipCheckbox.Name = "RealtionshipCheckbox";
            this.RealtionshipCheckbox.Size = new System.Drawing.Size(61, 20);
            this.RealtionshipCheckbox.TabIndex = 0;
            this.RealtionshipCheckbox.Text = "Active";
            this.RealtionshipCheckbox.UseVisualStyleBackColor = true;
            this.RealtionshipCheckbox.CheckedChanged += new System.EventHandler(this.RealtionshipCheckbox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LivingCityTextbox);
            this.groupBox4.Controls.Add(this.LivingCityCheckbox);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(213, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(163, 114);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Living city";
            // 
            // LivingCityTextbox
            // 
            this.LivingCityTextbox.Enabled = false;
            this.LivingCityTextbox.Location = new System.Drawing.Point(6, 69);
            this.LivingCityTextbox.Name = "LivingCityTextbox";
            this.LivingCityTextbox.Size = new System.Drawing.Size(100, 23);
            this.LivingCityTextbox.TabIndex = 1;
            // 
            // LivingCityCheckbox
            // 
            this.LivingCityCheckbox.AutoSize = true;
            this.LivingCityCheckbox.Location = new System.Drawing.Point(6, 31);
            this.LivingCityCheckbox.Name = "LivingCityCheckbox";
            this.LivingCityCheckbox.Size = new System.Drawing.Size(61, 20);
            this.LivingCityCheckbox.TabIndex = 0;
            this.LivingCityCheckbox.Text = "Active";
            this.LivingCityCheckbox.UseVisualStyleBackColor = true;
            this.LivingCityCheckbox.CheckedChanged += new System.EventHandler(this.LivingCityCheckbox_CheckedChanged);
            // 
            // FilteredFriendsListbox
            // 
            this.FilteredFriendsListbox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilteredFriendsListbox.FormattingEnabled = true;
            this.FilteredFriendsListbox.ItemHeight = 16;
            this.FilteredFriendsListbox.Location = new System.Drawing.Point(484, 160);
            this.FilteredFriendsListbox.Name = "FilteredFriendsListbox";
            this.FilteredFriendsListbox.Size = new System.Drawing.Size(188, 228);
            this.FilteredFriendsListbox.TabIndex = 5;
            // 
            // FilterButton
            // 
            this.FilterButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterButton.Location = new System.Drawing.Point(15, 415);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(75, 34);
            this.FilterButton.TabIndex = 6;
            this.FilterButton.Text = "Filter";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // facebookPostControl1
            // 
            this.facebookPostControl1.Location = new System.Drawing.Point(0, 3);
            this.facebookPostControl1.Name = "facebookPostControl1";
            this.facebookPostControl1.Size = new System.Drawing.Size(701, 151);
            this.facebookPostControl1.TabIndex = 0;
            // 
            // CleanButton
            // 
            this.CleanButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CleanButton.Location = new System.Drawing.Point(113, 415);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(82, 34);
            this.CleanButton.TabIndex = 7;
            this.CleanButton.Text = "Clean filter";
            this.CleanButton.UseVisualStyleBackColor = true;
            this.CleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // SmartPostPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CleanButton);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.FilteredFriendsListbox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.facebookPostControl1);
            this.Name = "SmartPostPage";
            this.Size = new System.Drawing.Size(704, 482);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.FacebookPostControl facebookPostControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox AgeFilterCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox GenderCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox RealtionshipCheckbox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox LivingCityCheckbox;
        private System.Windows.Forms.ListBox FilteredFriendsListbox;
        private System.Windows.Forms.RadioButton Plus18RadioButton;
        private System.Windows.Forms.RadioButton minus18RadioButton;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.RadioButton DivorcedRadioButton;
        private System.Windows.Forms.RadioButton MarriedRadioButton;
        private System.Windows.Forms.RadioButton SingleRadioButton;
        private System.Windows.Forms.TextBox LivingCityTextbox;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.Button CleanButton;
    }
}
