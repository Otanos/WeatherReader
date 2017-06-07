namespace WeatherReader
{
    partial class Form1
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
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.DataField = new System.Windows.Forms.RichTextBox();
            this.CheckWeatherButton = new System.Windows.Forms.Button();
            this.CityDropdown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(18, 12);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 0;
            // 
            // DataField
            // 
            this.DataField.Location = new System.Drawing.Point(187, 12);
            this.DataField.Name = "DataField";
            this.DataField.Size = new System.Drawing.Size(339, 245);
            this.DataField.TabIndex = 2;
            this.DataField.Text = "";
            // 
            // CheckWeatherButton
            // 
            this.CheckWeatherButton.Location = new System.Drawing.Point(18, 213);
            this.CheckWeatherButton.Name = "CheckWeatherButton";
            this.CheckWeatherButton.Size = new System.Drawing.Size(157, 44);
            this.CheckWeatherButton.TabIndex = 3;
            this.CheckWeatherButton.Text = "Check Weather";
            this.CheckWeatherButton.UseVisualStyleBackColor = true;
            this.CheckWeatherButton.Click += new System.EventHandler(this.CheckWeatherButton_Click);
            // 
            // CityDropdown
            // 
            this.CityDropdown.FormattingEnabled = true;
            this.CityDropdown.Location = new System.Drawing.Point(18, 186);
            this.CityDropdown.Name = "CityDropdown";
            this.CityDropdown.Size = new System.Drawing.Size(157, 21);
            this.CityDropdown.TabIndex = 7;
            this.CityDropdown.SelectionChangeCommitted += new System.EventHandler(this.CityDropdown_SelectionChangeCommitted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 266);
            this.Controls.Add(this.CityDropdown);
            this.Controls.Add(this.CheckWeatherButton);
            this.Controls.Add(this.DataField);
            this.Controls.Add(this.Calendar);
            this.Name = "Form1";
            this.Text = "WeatherReader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.RichTextBox DataField;
        private System.Windows.Forms.Button CheckWeatherButton;
        private System.Windows.Forms.ComboBox CityDropdown;
    }
}

