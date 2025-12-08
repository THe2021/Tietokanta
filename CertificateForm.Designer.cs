namespace DataBaseA
{
    partial class CertificateForm
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxCertName = new System.Windows.Forms.TextBox();
            this.textBoxAuthority = new System.Windows.Forms.TextBox();
            this.dateTimePickerIssue = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerExpiry = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(317, 279);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "button1";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxCertName
            // 
            this.textBoxCertName.Location = new System.Drawing.Point(293, 91);
            this.textBoxCertName.Name = "textBoxCertName";
            this.textBoxCertName.Size = new System.Drawing.Size(100, 20);
            this.textBoxCertName.TabIndex = 1;
            // 
            // textBoxAuthority
            // 
            this.textBoxAuthority.Location = new System.Drawing.Point(292, 122);
            this.textBoxAuthority.Name = "textBoxAuthority";
            this.textBoxAuthority.Size = new System.Drawing.Size(100, 20);
            this.textBoxAuthority.TabIndex = 2;
            // 
            // dateTimePickerIssue
            // 
            this.dateTimePickerIssue.Location = new System.Drawing.Point(294, 197);
            this.dateTimePickerIssue.Name = "dateTimePickerIssue";
            this.dateTimePickerIssue.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerIssue.TabIndex = 4;
            // 
            // dateTimePickerExpiry
            // 
            this.dateTimePickerExpiry.Location = new System.Drawing.Point(296, 234);
            this.dateTimePickerExpiry.Name = "dateTimePickerExpiry";
            this.dateTimePickerExpiry.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerExpiry.TabIndex = 5;
            // 
            // CertificateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePickerExpiry);
            this.Controls.Add(this.dateTimePickerIssue);
            this.Controls.Add(this.textBoxAuthority);
            this.Controls.Add(this.textBoxCertName);
            this.Controls.Add(this.buttonSave);
            this.Name = "CertificateForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxCertName;
        private System.Windows.Forms.TextBox textBoxAuthority;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssue;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpiry;
    }
}