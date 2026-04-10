namespace DataBaseA
{
    partial class CertificateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Certificate basic info
        private System.Windows.Forms.TextBox textBoxCertName;
        private System.Windows.Forms.TextBox textBoxAuthority;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssue;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpiry;

        // Certification exam info
        private System.Windows.Forms.TextBox textBoxSupervisorName;
        private System.Windows.Forms.TextBox textBoxExaminationBody;
        private System.Windows.Forms.TextBox textBoxExaminationSignature;
        private System.Windows.Forms.TextBox textBoxRemarks;

        // Tests
        private System.Windows.Forms.DataGridView dataGridViewTests;

        // Save button
        private System.Windows.Forms.Button buttonSave;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxCertName = new System.Windows.Forms.TextBox();
            this.textBoxAuthority = new System.Windows.Forms.TextBox();
            this.dateTimePickerIssue = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerExpiry = new System.Windows.Forms.DateTimePicker();
            this.textBoxSupervisorName = new System.Windows.Forms.TextBox();
            this.textBoxExaminationBody = new System.Windows.Forms.TextBox();
            this.textBoxExaminationSignature = new System.Windows.Forms.TextBox();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.dataGridViewTests = new System.Windows.Forms.DataGridView();
            this.TestType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InspectorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridViewProcesses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCertName
            // 
            this.textBoxCertName.Location = new System.Drawing.Point(20, 20);
            this.textBoxCertName.Name = "textBoxCertName";
            this.textBoxCertName.Size = new System.Drawing.Size(200, 20);
            this.textBoxCertName.TabIndex = 0;
            // 
            // textBoxAuthority
            // 
            this.textBoxAuthority.Location = new System.Drawing.Point(526, 564);
            this.textBoxAuthority.Name = "textBoxAuthority";
            this.textBoxAuthority.Size = new System.Drawing.Size(200, 20);
            this.textBoxAuthority.TabIndex = 1;
            // 
            // dateTimePickerIssue
            // 
            this.dateTimePickerIssue.Location = new System.Drawing.Point(681, 651);
            this.dateTimePickerIssue.Name = "dateTimePickerIssue";
            this.dateTimePickerIssue.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerIssue.TabIndex = 2;
            // 
            // dateTimePickerExpiry
            // 
            this.dateTimePickerExpiry.Location = new System.Drawing.Point(681, 699);
            this.dateTimePickerExpiry.Name = "dateTimePickerExpiry";
            this.dateTimePickerExpiry.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerExpiry.TabIndex = 3;
            // 
            // textBoxSupervisorName
            // 
            this.textBoxSupervisorName.Location = new System.Drawing.Point(25, 564);
            this.textBoxSupervisorName.Name = "textBoxSupervisorName";
            this.textBoxSupervisorName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSupervisorName.TabIndex = 17;
            // 
            // textBoxExaminationBody
            // 
            this.textBoxExaminationBody.Location = new System.Drawing.Point(191, 564);
            this.textBoxExaminationBody.Name = "textBoxExaminationBody";
            this.textBoxExaminationBody.Size = new System.Drawing.Size(100, 20);
            this.textBoxExaminationBody.TabIndex = 18;
            // 
            // textBoxExaminationSignature
            // 
            this.textBoxExaminationSignature.Location = new System.Drawing.Point(371, 564);
            this.textBoxExaminationSignature.Name = "textBoxExaminationSignature";
            this.textBoxExaminationSignature.Size = new System.Drawing.Size(100, 20);
            this.textBoxExaminationSignature.TabIndex = 19;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Location = new System.Drawing.Point(25, 504);
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(600, 20);
            this.textBoxRemarks.TabIndex = 20;
            // 
            // dataGridViewTests
            // 
            this.dataGridViewTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestType,
            this.Result,
            this.InspectorName,
            this.TestDate,
            this.Notes});
            this.dataGridViewTests.Location = new System.Drawing.Point(20, 626);
            this.dataGridViewTests.Name = "dataGridViewTests";
            this.dataGridViewTests.Size = new System.Drawing.Size(600, 78);
            this.dataGridViewTests.TabIndex = 25;
            // 
            // TestType
            // 
            this.TestType.HeaderText = "Test Type";
            this.TestType.Name = "TestType";
            // 
            // Result
            // 
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            // 
            // InspectorName
            // 
            this.InspectorName.HeaderText = "Inspector Name";
            this.InspectorName.Name = "InspectorName";
            // 
            // TestDate
            // 
            this.TestDate.HeaderText = "Test Date";
            this.TestDate.Name = "TestDate";
            // 
            // Notes
            // 
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(20, 726);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.TabIndex = 26;
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Certification name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 548);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Issuing Authority";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(678, 626);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Issuing Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(678, 674);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Expiry Date";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 548);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Supervisor name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(188, 548);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Examination body";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(368, 548);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 13);
            this.label17.TabIndex = 43;
            this.label17.Text = "Examination signature";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(27, 488);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 13);
            this.label18.TabIndex = 44;
            this.label18.Text = "Remarks";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(27, 598);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 13);
            this.label23.TabIndex = 49;
            this.label23.Text = "Tests";
            // 
            // dataGridViewProcesses
            // 
            this.dataGridViewProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcesses.Location = new System.Drawing.Point(20, 59);
            this.dataGridViewProcesses.Name = "dataGridViewProcesses";
            this.dataGridViewProcesses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProcesses.Size = new System.Drawing.Size(271, 157);
            this.dataGridViewProcesses.TabIndex = 53;
            // 
            // CertificateForm
            // 
            this.ClientSize = new System.Drawing.Size(1062, 786);
            this.Controls.Add(this.dataGridViewProcesses);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCertName);
            this.Controls.Add(this.textBoxAuthority);
            this.Controls.Add(this.dateTimePickerIssue);
            this.Controls.Add(this.dateTimePickerExpiry);
            this.Controls.Add(this.textBoxSupervisorName);
            this.Controls.Add(this.textBoxExaminationBody);
            this.Controls.Add(this.textBoxExaminationSignature);
            this.Controls.Add(this.textBoxRemarks);
            this.Controls.Add(this.dataGridViewTests);
            this.Controls.Add(this.buttonSave);
            this.Name = "CertificateForm";
            this.Text = "Add Certificate";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn InspectorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridView dataGridViewProcesses;
    }
}