using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseA
{
    public partial class CertificateForm : Form
    {
        private readonly int welderId;

        public CertificateForm(int welderId)
        {
            InitializeComponent();
            this.welderId = welderId;

            this.Load += CertificateForm_Load;
        }

        private void CertificateForm_Load(object sender, EventArgs e)
        {
            // -----------------------------
            // ComboBoxes (single selection)
            // -----------------------------

            // Welding current / polarity
            comboBoxPolarity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPolarity.Items.Clear();
            comboBoxPolarity.Items.AddRange(new string[]
            {
        "AC", "DC+", "DC-"
            });

            // Welding positions (EN ISO standards commonly used)
            comboBoxWeldingPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWeldingPosition.Items.Clear();
            comboBoxWeldingPosition.Items.AddRange(new string[]
            {
        "PA", "PB", "PC", "PD", "PE", "PF", "PG"
            });

            // -----------------------------
            // CheckedListBoxes (multi-select)
            // -----------------------------

            // Joint types
            checkedListBoxJointTypes.Items.Clear();
            checkedListBoxJointTypes.Items.AddRange(new string[]
            {
        "BW", "FW"
            });

            // Parent materials (ISO/TR 15608 – steels only)
            checkedListBoxParentMaterials.Items.Clear();
            checkedListBoxParentMaterials.Items.AddRange(new string[]
            {
        "1","2","3","4","5","6","7","8","9","10","11"
            });

            // Filler material groups (EN ISO 9606-1)
            checkedListBoxFillerGroups.Items.Clear();
            checkedListBoxFillerGroups.Items.AddRange(new string[]
            {
        "FM1", "FM2", "FM3", "FM4", "FM5", "FM6"
            });

            // -----------------------------
            // DataGridView for tests
            // -----------------------------

            dataGridViewTests.AllowUserToAddRows = true;
            dataGridViewTests.AutoGenerateColumns = false;
            dataGridViewTests.Columns.Clear();

            // Test type dropdown
            var testTypeColumn = new DataGridViewComboBoxColumn
            {
                Name = "TestType",
                HeaderText = "Test Type",
                DataSource = new string[] { "VT", "RT", "UT", "MT", "PT", "BT", "FT" }
            };
            dataGridViewTests.Columns.Add(testTypeColumn);

            // Result dropdown
            var resultColumn = new DataGridViewComboBoxColumn
            {
                Name = "Result",
                HeaderText = "Result",
                DataSource = new string[] { "Pass", "Fail" }
            };
            dataGridViewTests.Columns.Add(resultColumn);

            // Other columns
            dataGridViewTests.Columns.Add(new DataGridViewTextBoxColumn { Name = "InspectorName", HeaderText = "Inspector Name" });
            dataGridViewTests.Columns.Add(new DataGridViewTextBoxColumn { Name = "TestDate", HeaderText = "Test Date" });
            dataGridViewTests.Columns.Add(new DataGridViewTextBoxColumn { Name = "Notes", HeaderText = "Notes" });

            dataGridViewTests.Columns["TestDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

            // -----------------------------
            // DataGridView for processes
            // -----------------------------

            dataGridViewProcesses.AllowUserToAddRows = true;
            dataGridViewProcesses.AutoGenerateColumns = false;
            dataGridViewProcesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProcesses.Columns.Clear();

            // Process code
            var processCodeColumn = new DataGridViewComboBoxColumn
            {
                Name = "ProcessCode",
                HeaderText = "Process",
                DataSource = new string[] { "111", "131", "135", "136", "141", "121" }
            };
            dataGridViewProcesses.Columns.Add(processCodeColumn);

            // Pass type
            var passTypeColumn = new DataGridViewComboBoxColumn
            {
                Name = "PassType",
                HeaderText = "Pass Type",
                DataSource = new string[] { "Root", "Fill", "Cap" }
            };
            dataGridViewProcesses.Columns.Add(passTypeColumn);

            // Filler material designation
            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FillerMaterialDesignation",
                HeaderText = "Filler Designation"
            });

            // Filler trade name
            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FillerMaterialTradeName",
                HeaderText = "Filler Trade Name"
            });

            // Filler type
            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FillerMaterialType",
                HeaderText = "Filler Type"
            });

            // Polarity
            var polarityColumn = new DataGridViewComboBoxColumn
            {
                Name = "Polarity",
                HeaderText = "Polarity",
                DataSource = new string[] { "AC", "DC+", "DC-" }
            };
            dataGridViewProcesses.Columns.Add(polarityColumn);

            // Auxiliaries
            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Auxiliaries",
                HeaderText = "Auxiliaries"
            });

            // Shielding gas
            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ShieldingGas",
                HeaderText = "Shielding Gas"
            });

            // Deposited thickness
            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DepositedThickness",
                HeaderText = "Deposited Thickness"
            });

            // Weld details
            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "WeldDetails",
                HeaderText = "Weld Details"
            });

            // Is multilayer
            var multilayerColumn = new DataGridViewCheckBoxColumn
            {
                Name = "IsMultilayer",
                HeaderText = "Multilayer?"
            };
            dataGridViewProcesses.Columns.Add(multilayerColumn);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // 1. Validate welder ID
            if (welderId <= 0)
            {
                MessageBox.Show("Invalid welder reference. Cannot save certificate.");
                return;
            }

            // 2. Validate mandatory certificate fields
            if (string.IsNullOrWhiteSpace(textBoxCertName.Text))
            {
                MessageBox.Show("Certificate name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxAuthority.Text))
            {
                MessageBox.Show("Issuing authority is required.");
                return;
            }

            if (dateTimePickerExpiry.Value < dateTimePickerIssue.Value)
            {
                MessageBox.Show("Expiry date cannot be earlier than issue date.");
                return;
            }



            bool hasProcess = dataGridViewProcesses.Rows
                .Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow &&
                  !string.IsNullOrWhiteSpace(r.Cells["ProcessCode"].Value?.ToString()));

            if (!hasProcess)
            {
                MessageBox.Show("At least one welding process must be defined.");
                return;
            }
            string connString = ConfigurationManager
            .ConnectionStrings["DataBaseA.Properties.Settings.DatabaseAConnectionString"]
            .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 3. Insert main certificate
                    SqlCommand cmdCert = new SqlCommand(
                        @"INSERT INTO Certificates
                        (WelderID, CertificateName, IssuingAuthority, IssueDate, ExpiryDate,
                         ProductType, FillerMaterialDesignation, FillerMaterialTradeName,
                         FillerMaterialType, TypeOfCurrentPolarity, Auxiliaries, ShieldingGas,
                         MaterialThickness, DepositedThickness, OutsidePipeDiameter, WeldingPosition,
                         WeldDetails, IsMultilayer, TestSupervisorName, ExaminationBody,
                         ExaminationSignature, Remarks)
                         VALUES
                        (@WelderID, @Name, @Auth, @Issue, @Exp, @ProductType, @FillerDesignation,
                         @FillerTradeName, @FillerType, @Polarity, @Aux, @Gas,
                         @MaterialThickness, @DepositedThickness, @PipeDiameter, @WeldPosition,
                         @WeldDetails, @IsMultilayer, @Supervisor, @ExaminationBody,
                         @ExaminationSignature, @Remarks);
                         SELECT SCOPE_IDENTITY();",
                        conn, transaction);

                    cmdCert.Parameters.AddWithValue("@WelderID", welderId);
                    cmdCert.Parameters.AddWithValue("@Name", textBoxCertName.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Auth", textBoxAuthority.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Issue", dateTimePickerIssue.Value.Date);
                    cmdCert.Parameters.AddWithValue("@Exp", dateTimePickerExpiry.Value.Date);
                    cmdCert.Parameters.AddWithValue("@ProductType", textBoxProductType.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@FillerDesignation", textBoxFillerDesignation.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@FillerTradeName", textBoxFillerTradeName.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@FillerType", textBoxFillerType.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Polarity", comboBoxPolarity.SelectedItem?.ToString() ?? "");
                    cmdCert.Parameters.AddWithValue("@Aux", textBoxAuxiliaries.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Gas", textBoxShieldingGas.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@MaterialThickness", numericMaterialThickness.Value);
                    cmdCert.Parameters.AddWithValue("@DepositedThickness", numericDepositedThickness.Value);
                    cmdCert.Parameters.AddWithValue("@PipeDiameter", numericPipeDiameter.Value);
                    cmdCert.Parameters.AddWithValue("@WeldPosition", comboBoxWeldingPosition.SelectedItem?.ToString() ?? "");
                    cmdCert.Parameters.AddWithValue("@WeldDetails", textBoxWeldDetails.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@IsMultilayer", checkBoxIsMultilayer.Checked);
                    cmdCert.Parameters.AddWithValue("@Supervisor", textBoxSupervisorName.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@ExaminationBody", textBoxExaminationBody.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@ExaminationSignature", textBoxExaminationSignature.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Remarks", textBoxRemarks.Text.Trim());

                    int certificateId = Convert.ToInt32(cmdCert.ExecuteScalar());

                    // 6️⃣ Insert each process from dataGridViewProcesses into CertificateProcessDetails
                    foreach (DataGridViewRow row in dataGridViewProcesses.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var processCode = row.Cells["ProcessCode"].Value?.ToString();
                        if (string.IsNullOrWhiteSpace(processCode)) continue; // skip incomplete row

                        var passType = row.Cells["PassType"].Value?.ToString() ?? "";
                        var fillerDesignation = row.Cells["FillerMaterialDesignation"].Value?.ToString() ?? "";
                        var fillerTradeName = row.Cells["FillerMaterialTradeName"].Value?.ToString() ?? "";
                        var fillerType = row.Cells["FillerMaterialType"].Value?.ToString() ?? "";
                        var polarity = row.Cells["Polarity"].Value?.ToString() ?? "";
                        var auxiliaries = row.Cells["Auxiliaries"].Value?.ToString() ?? "";
                        var shieldingGas = row.Cells["ShieldingGas"].Value?.ToString() ?? "";
                        var depositedThickness = row.Cells["DepositedThickness"].Value != null
                            ? Convert.ToDecimal(row.Cells["DepositedThickness"].Value)
                            : 0m;
                        var weldDetails = row.Cells["WeldDetails"].Value?.ToString() ?? "";
                        var isMultilayer = row.Cells["IsMultilayer"].Value != null && (bool)row.Cells["IsMultilayer"].Value;

                        SqlCommand cmdProcess = new SqlCommand(
                            @"INSERT INTO CertificateProcessDetails
                      (CertificateId, ProcessCode, PassType,
                       FillerMaterialDesignation, FillerMaterialTradeName, FillerMaterialType,
                       TypeOfCurrentPolarity, Auxiliaries, ShieldingGas,
                       DepositedThickness, WeldDetails, IsMultilayer)
                      VALUES
                      (@CertId, @ProcessCode, @PassType,
                       @FillerDesignation, @FillerTradeName, @FillerType,
                       @Polarity, @Auxiliaries, @Gas,
                       @DepositedThickness, @WeldDetails, @IsMultilayer)",
                            conn, transaction);

                        cmdProcess.Parameters.AddWithValue("@CertId", certificateId);
                        cmdProcess.Parameters.AddWithValue("@ProcessCode", processCode);
                        cmdProcess.Parameters.AddWithValue("@PassType", passType);
                        cmdProcess.Parameters.AddWithValue("@FillerDesignation", fillerDesignation);
                        cmdProcess.Parameters.AddWithValue("@FillerTradeName", fillerTradeName);
                        cmdProcess.Parameters.AddWithValue("@FillerType", fillerType);
                        cmdProcess.Parameters.AddWithValue("@Polarity", polarity);
                        cmdProcess.Parameters.AddWithValue("@Auxiliaries", auxiliaries);
                        cmdProcess.Parameters.AddWithValue("@Gas", shieldingGas);
                        cmdProcess.Parameters.AddWithValue("@DepositedThickness", depositedThickness);
                        cmdProcess.Parameters.AddWithValue("@WeldDetails", weldDetails);
                        cmdProcess.Parameters.AddWithValue("@IsMultilayer", isMultilayer);

                        cmdProcess.ExecuteNonQuery();
                    }

                    // 7️⃣ Insert certificate tests (existing logic)
                    foreach (DataGridViewRow row in dataGridViewTests.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var testType = row.Cells["TestType"].Value?.ToString();
                        var result = row.Cells["Result"].Value?.ToString();
                        var inspector = row.Cells["InspectorName"].Value?.ToString() ?? "";
                        var notes = row.Cells["Notes"].Value?.ToString() ?? "";
                        var testDate = row.Cells["TestDate"].Value;

                        if (string.IsNullOrWhiteSpace(testType) || string.IsNullOrWhiteSpace(result))
                            continue; // Skip incomplete rows

                        SqlCommand cmdTest = new SqlCommand(
                            @"INSERT INTO CertificateTests
                      (CertificateId, TestType, Result, Notes, InspectorName, TestDate)
                      VALUES (@CertId, @TestType, @Result, @Notes, @Inspector, @TestDate)",
                            conn, transaction);

                        cmdTest.Parameters.AddWithValue("@CertId", certificateId);
                        cmdTest.Parameters.AddWithValue("@TestType", testType);
                        cmdTest.Parameters.AddWithValue("@Result", result);
                        cmdTest.Parameters.AddWithValue("@Notes", notes);
                        cmdTest.Parameters.AddWithValue("@Inspector", inspector);
                        cmdTest.Parameters.AddWithValue("@TestDate", testDate != null ? (DateTime)testDate : (object)DBNull.Value);

                        cmdTest.ExecuteNonQuery();
                    }

                    // 8️⃣ Commit transaction
                    transaction.Commit();
                    MessageBox.Show("Certificate added successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Failed to save certificate:\n" + ex.Message);
                }
            }
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}