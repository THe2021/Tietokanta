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

        // Additional certificate info
        private System.Windows.Forms.TextBox textBoxProductType;
        private System.Windows.Forms.TextBox textBoxFillerDesignation;
        private System.Windows.Forms.TextBox textBoxFillerTradeName;
        private System.Windows.Forms.TextBox textBoxFillerType;
        private System.Windows.Forms.ComboBox comboBoxPolarity;
        private System.Windows.Forms.TextBox textBoxAuxiliaries;
        private System.Windows.Forms.TextBox textBoxShieldingGas;
        private System.Windows.Forms.NumericUpDown numericMaterialThickness;
        private System.Windows.Forms.NumericUpDown numericDepositedThickness;
        private System.Windows.Forms.NumericUpDown numericPipeDiameter;
        private System.Windows.Forms.ComboBox comboBoxWeldingPosition;
        private System.Windows.Forms.TextBox textBoxWeldDetails;
        private System.Windows.Forms.CheckBox checkBoxIsMultilayer;

        // Certification exam info
        private System.Windows.Forms.TextBox textBoxSupervisorName;
        private System.Windows.Forms.TextBox textBoxExaminationBody;
        private System.Windows.Forms.TextBox textBoxExaminationSignature;
        private System.Windows.Forms.TextBox textBoxRemarks;

        // Multi-value info
        private System.Windows.Forms.CheckedListBox checkedListBoxJointTypes;
        private System.Windows.Forms.CheckedListBox checkedListBoxProcesses;
        private System.Windows.Forms.CheckedListBox checkedListBoxParentMaterials;
        private System.Windows.Forms.CheckedListBox checkedListBoxFillerGroups;

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
            this.textBoxProductType = new System.Windows.Forms.TextBox();
            this.textBoxFillerDesignation = new System.Windows.Forms.TextBox();
            this.textBoxFillerTradeName = new System.Windows.Forms.TextBox();
            this.textBoxFillerType = new System.Windows.Forms.TextBox();
            this.comboBoxPolarity = new System.Windows.Forms.ComboBox();
            this.textBoxAuxiliaries = new System.Windows.Forms.TextBox();
            this.textBoxShieldingGas = new System.Windows.Forms.TextBox();
            this.numericMaterialThickness = new System.Windows.Forms.NumericUpDown();
            this.numericDepositedThickness = new System.Windows.Forms.NumericUpDown();
            this.numericPipeDiameter = new System.Windows.Forms.NumericUpDown();
            this.comboBoxWeldingPosition = new System.Windows.Forms.ComboBox();
            this.textBoxWeldDetails = new System.Windows.Forms.TextBox();
            this.checkBoxIsMultilayer = new System.Windows.Forms.CheckBox();
            this.textBoxSupervisorName = new System.Windows.Forms.TextBox();
            this.textBoxExaminationBody = new System.Windows.Forms.TextBox();
            this.textBoxExaminationSignature = new System.Windows.Forms.TextBox();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.checkedListBoxJointTypes = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxProcesses = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxParentMaterials = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxFillerGroups = new System.Windows.Forms.CheckedListBox();
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaterialThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDepositedThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPipeDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTests)).BeginInit();
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
            this.textBoxAuthority.Location = new System.Drawing.Point(240, 20);
            this.textBoxAuthority.Name = "textBoxAuthority";
            this.textBoxAuthority.Size = new System.Drawing.Size(200, 20);
            this.textBoxAuthority.TabIndex = 1;
            // 
            // dateTimePickerIssue
            // 
            this.dateTimePickerIssue.Location = new System.Drawing.Point(20, 60);
            this.dateTimePickerIssue.Name = "dateTimePickerIssue";
            this.dateTimePickerIssue.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerIssue.TabIndex = 2;
            // 
            // dateTimePickerExpiry
            // 
            this.dateTimePickerExpiry.Location = new System.Drawing.Point(240, 60);
            this.dateTimePickerExpiry.Name = "dateTimePickerExpiry";
            this.dateTimePickerExpiry.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerExpiry.TabIndex = 3;
            // 
            // textBoxProductType
            // 
            this.textBoxProductType.Location = new System.Drawing.Point(20, 100);
            this.textBoxProductType.Name = "textBoxProductType";
            this.textBoxProductType.Size = new System.Drawing.Size(100, 20);
            this.textBoxProductType.TabIndex = 4;
            // 
            // textBoxFillerDesignation
            // 
            this.textBoxFillerDesignation.Location = new System.Drawing.Point(240, 100);
            this.textBoxFillerDesignation.Name = "textBoxFillerDesignation";
            this.textBoxFillerDesignation.Size = new System.Drawing.Size(100, 20);
            this.textBoxFillerDesignation.TabIndex = 5;
            // 
            // textBoxFillerTradeName
            // 
            this.textBoxFillerTradeName.Location = new System.Drawing.Point(460, 100);
            this.textBoxFillerTradeName.Name = "textBoxFillerTradeName";
            this.textBoxFillerTradeName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFillerTradeName.TabIndex = 6;
            // 
            // textBoxFillerType
            // 
            this.textBoxFillerType.Location = new System.Drawing.Point(680, 100);
            this.textBoxFillerType.Name = "textBoxFillerType";
            this.textBoxFillerType.Size = new System.Drawing.Size(100, 20);
            this.textBoxFillerType.TabIndex = 7;
            // 
            // comboBoxPolarity
            // 
            this.comboBoxPolarity.Location = new System.Drawing.Point(20, 140);
            this.comboBoxPolarity.Name = "comboBoxPolarity";
            this.comboBoxPolarity.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPolarity.TabIndex = 8;
            // 
            // textBoxAuxiliaries
            // 
            this.textBoxAuxiliaries.Location = new System.Drawing.Point(240, 140);
            this.textBoxAuxiliaries.Name = "textBoxAuxiliaries";
            this.textBoxAuxiliaries.Size = new System.Drawing.Size(100, 20);
            this.textBoxAuxiliaries.TabIndex = 9;
            // 
            // textBoxShieldingGas
            // 
            this.textBoxShieldingGas.Location = new System.Drawing.Point(460, 140);
            this.textBoxShieldingGas.Name = "textBoxShieldingGas";
            this.textBoxShieldingGas.Size = new System.Drawing.Size(100, 20);
            this.textBoxShieldingGas.TabIndex = 10;
            // 
            // numericMaterialThickness
            // 
            this.numericMaterialThickness.Location = new System.Drawing.Point(20, 180);
            this.numericMaterialThickness.Name = "numericMaterialThickness";
            this.numericMaterialThickness.Size = new System.Drawing.Size(120, 20);
            this.numericMaterialThickness.TabIndex = 11;
            // 
            // numericDepositedThickness
            // 
            this.numericDepositedThickness.Location = new System.Drawing.Point(240, 180);
            this.numericDepositedThickness.Name = "numericDepositedThickness";
            this.numericDepositedThickness.Size = new System.Drawing.Size(120, 20);
            this.numericDepositedThickness.TabIndex = 12;
            // 
            // numericPipeDiameter
            // 
            this.numericPipeDiameter.Location = new System.Drawing.Point(460, 180);
            this.numericPipeDiameter.Name = "numericPipeDiameter";
            this.numericPipeDiameter.Size = new System.Drawing.Size(120, 20);
            this.numericPipeDiameter.TabIndex = 13;
            // 
            // comboBoxWeldingPosition
            // 
            this.comboBoxWeldingPosition.Location = new System.Drawing.Point(20, 220);
            this.comboBoxWeldingPosition.Name = "comboBoxWeldingPosition";
            this.comboBoxWeldingPosition.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWeldingPosition.TabIndex = 14;
            // 
            // textBoxWeldDetails
            // 
            this.textBoxWeldDetails.Location = new System.Drawing.Point(240, 220);
            this.textBoxWeldDetails.Name = "textBoxWeldDetails";
            this.textBoxWeldDetails.Size = new System.Drawing.Size(100, 20);
            this.textBoxWeldDetails.TabIndex = 15;
            // 
            // checkBoxIsMultilayer
            // 
            this.checkBoxIsMultilayer.Location = new System.Drawing.Point(460, 220);
            this.checkBoxIsMultilayer.Name = "checkBoxIsMultilayer";
            this.checkBoxIsMultilayer.Size = new System.Drawing.Size(104, 24);
            this.checkBoxIsMultilayer.TabIndex = 16;
            // 
            // textBoxSupervisorName
            // 
            this.textBoxSupervisorName.Location = new System.Drawing.Point(20, 260);
            this.textBoxSupervisorName.Name = "textBoxSupervisorName";
            this.textBoxSupervisorName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSupervisorName.TabIndex = 17;
            // 
            // textBoxExaminationBody
            // 
            this.textBoxExaminationBody.Location = new System.Drawing.Point(240, 260);
            this.textBoxExaminationBody.Name = "textBoxExaminationBody";
            this.textBoxExaminationBody.Size = new System.Drawing.Size(100, 20);
            this.textBoxExaminationBody.TabIndex = 18;
            // 
            // textBoxExaminationSignature
            // 
            this.textBoxExaminationSignature.Location = new System.Drawing.Point(460, 260);
            this.textBoxExaminationSignature.Name = "textBoxExaminationSignature";
            this.textBoxExaminationSignature.Size = new System.Drawing.Size(100, 20);
            this.textBoxExaminationSignature.TabIndex = 19;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Location = new System.Drawing.Point(20, 300);
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(600, 20);
            this.textBoxRemarks.TabIndex = 20;
            // 
            // checkedListBoxJointTypes
            // 
            this.checkedListBoxJointTypes.CheckOnClick = true;
            this.checkedListBoxJointTypes.Location = new System.Drawing.Point(20, 380);
            this.checkedListBoxJointTypes.Name = "checkedListBoxJointTypes";
            this.checkedListBoxJointTypes.Size = new System.Drawing.Size(120, 79);
            this.checkedListBoxJointTypes.TabIndex = 21;
            // 
            // checkedListBoxProcesses
            // 
            this.checkedListBoxProcesses.CheckOnClick = true;
            this.checkedListBoxProcesses.Location = new System.Drawing.Point(160, 380);
            this.checkedListBoxProcesses.Name = "checkedListBoxProcesses";
            this.checkedListBoxProcesses.Size = new System.Drawing.Size(120, 79);
            this.checkedListBoxProcesses.TabIndex = 22;
            // 
            // checkedListBoxParentMaterials
            // 
            this.checkedListBoxParentMaterials.CheckOnClick = true;
            this.checkedListBoxParentMaterials.Location = new System.Drawing.Point(300, 380);
            this.checkedListBoxParentMaterials.Name = "checkedListBoxParentMaterials";
            this.checkedListBoxParentMaterials.Size = new System.Drawing.Size(120, 79);
            this.checkedListBoxParentMaterials.TabIndex = 23;
            // 
            // checkedListBoxFillerGroups
            // 
            this.checkedListBoxFillerGroups.CheckOnClick = true;
            this.checkedListBoxFillerGroups.Location = new System.Drawing.Point(440, 380);
            this.checkedListBoxFillerGroups.Name = "checkedListBoxFillerGroups";
            this.checkedListBoxFillerGroups.Size = new System.Drawing.Size(120, 79);
            this.checkedListBoxFillerGroups.TabIndex = 24;
            // 
            // dataGridViewTests
            // 
            this.dataGridViewTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestType,
            this.Result,
            this.InspectorName,
            this.TestDate,
            this.Notes});
            this.dataGridViewTests.Location = new System.Drawing.Point(20, 480);
            this.dataGridViewTests.Name = "dataGridViewTests";
            this.dataGridViewTests.Size = new System.Drawing.Size(600, 150);
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
            this.buttonSave.Location = new System.Drawing.Point(20, 650);
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
            this.label2.Location = new System.Drawing.Point(243, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Issuing Authority";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Issuing Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Expiry Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Product type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Polarity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Auxillaries";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(459, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Shielding gas";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Material thickness";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(237, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Deposited thickness";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(461, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Pipe diameter";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Welding position";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(242, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Weld details";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(459, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Multilayer";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 247);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Supervisor name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(242, 247);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Examination body";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(461, 247);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 13);
            this.label17.TabIndex = 43;
            this.label17.Text = "Examination signature";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 284);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 13);
            this.label18.TabIndex = 44;
            this.label18.Text = "Remarks";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(23, 364);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 45;
            this.label19.Text = "Joint type";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(157, 364);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 46;
            this.label20.Text = "Processes";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(297, 364);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 13);
            this.label21.TabIndex = 47;
            this.label21.Text = "Parent materials";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(437, 364);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(105, 13);
            this.label22.TabIndex = 48;
            this.label22.Text = "Filler Material Groups";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(23, 464);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 13);
            this.label23.TabIndex = 49;
            this.label23.Text = "Tests";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(242, 86);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 13);
            this.label24.TabIndex = 50;
            this.label24.Text = "Filler designation";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(458, 84);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 13);
            this.label25.TabIndex = 51;
            this.label25.Text = "Filler trade name";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(677, 86);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 13);
            this.label26.TabIndex = 52;
            this.label26.Text = "Filler type";
            // 
            // CertificateForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCertName);
            this.Controls.Add(this.textBoxAuthority);
            this.Controls.Add(this.dateTimePickerIssue);
            this.Controls.Add(this.dateTimePickerExpiry);
            this.Controls.Add(this.textBoxProductType);
            this.Controls.Add(this.textBoxFillerDesignation);
            this.Controls.Add(this.textBoxFillerTradeName);
            this.Controls.Add(this.textBoxFillerType);
            this.Controls.Add(this.comboBoxPolarity);
            this.Controls.Add(this.textBoxAuxiliaries);
            this.Controls.Add(this.textBoxShieldingGas);
            this.Controls.Add(this.numericMaterialThickness);
            this.Controls.Add(this.numericDepositedThickness);
            this.Controls.Add(this.numericPipeDiameter);
            this.Controls.Add(this.comboBoxWeldingPosition);
            this.Controls.Add(this.textBoxWeldDetails);
            this.Controls.Add(this.checkBoxIsMultilayer);
            this.Controls.Add(this.textBoxSupervisorName);
            this.Controls.Add(this.textBoxExaminationBody);
            this.Controls.Add(this.textBoxExaminationSignature);
            this.Controls.Add(this.textBoxRemarks);
            this.Controls.Add(this.checkedListBoxJointTypes);
            this.Controls.Add(this.checkedListBoxProcesses);
            this.Controls.Add(this.checkedListBoxParentMaterials);
            this.Controls.Add(this.checkedListBoxFillerGroups);
            this.Controls.Add(this.dataGridViewTests);
            this.Controls.Add(this.buttonSave);
            this.Name = "CertificateForm";
            this.Text = "Add Certificate";
            ((System.ComponentModel.ISupportInitialize)(this.numericMaterialThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDepositedThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPipeDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTests)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn InspectorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
    }
}