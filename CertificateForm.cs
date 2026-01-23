using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            comboBoxPolarity.Items.AddRange(new string[]
            {
        "AC",
        "DC+",
        "DC-"
            });

            // Welding positions (EN ISO standards commonly used)
            comboBoxWeldingPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWeldingPosition.Items.AddRange(new string[]
            {
        "PA",
        "PB",
        "PC",
        "PD",
        "PE",
        "PF",
        "PG"
            });

            // -----------------------------
            // CheckedListBoxes (multi-select)
            // -----------------------------

            // Joint types
            checkedListBoxJointTypes.Items.AddRange(new string[]
            {
        "BW",
        "FW"
            });

            // Welding processes (ISO 4063)
            checkedListBoxProcesses.Items.AddRange(new string[]
            {
        "111",
        "131",
        "135",
        "136",
        "141",
        "121"
            });

            // Parent materials (ISO/TR 15608 – steels only)
            checkedListBoxParentMaterials.Items.AddRange(new string[]
            {
        "1", "2", "3", "4", "5", "6",
        "7", "8", "9", "10", "11"
            });

            // Filler material groups (EN ISO 9606-1)
            checkedListBoxFillerGroups.Items.AddRange(new string[]
            {
        "FM1", "FM2", "FM3", "FM4", "FM5", "FM6"
            });

            // -----------------------------
            // DataGridView for tests
            // -----------------------------

            dataGridViewTests.AllowUserToAddRows = true;
            dataGridViewTests.AutoGenerateColumns = false;

            // Optional: make TestType and Result dropdowns
            var testTypeColumn = new DataGridViewComboBoxColumn
            {
                Name = "TestType",
                HeaderText = "Test Type",
                DataSource = new string[] { "VT", "RT", "UT", "MT", "PT", "BT", "FT" }
            };

            var resultColumn = new DataGridViewComboBoxColumn
            {
                Name = "Result",
                HeaderText = "Result",
                DataSource = new string[] { "Pass", "Fail" }
            };

            // Clear auto-added columns and re-add clean ones
            dataGridViewTests.Columns.Clear();
            dataGridViewTests.Columns.Add(testTypeColumn);
            dataGridViewTests.Columns.Add(resultColumn);
            dataGridViewTests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InspectorName",
                HeaderText = "Inspector Name"
            });

            dataGridViewTests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TestDate",
                HeaderText = "Test Date"
            });

            dataGridViewTests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Notes",
                HeaderText = "Notes"
            });

            // Optional: date formatting
            dataGridViewTests.Columns["TestDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
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

                    // 4. Insert JointTypes
                    foreach (var item in checkedListBoxJointTypes.CheckedItems)
                    {
                        SqlCommand cmdJoint = new SqlCommand(
                            "INSERT INTO CertificateJointTypes (CertificateId, JointType) VALUES (@CertId, @JointType)",
                            conn, transaction);
                        cmdJoint.Parameters.AddWithValue("@CertId", certificateId);
                        cmdJoint.Parameters.AddWithValue("@JointType", item.ToString());
                        cmdJoint.ExecuteNonQuery();
                    }

                    // 5. Insert Processes
                    foreach (var item in checkedListBoxProcesses.CheckedItems)
                    {
                        SqlCommand cmdProcess = new SqlCommand(
                            "INSERT INTO CertificateProcesses (CertificateId, ProcessName) VALUES (@CertId, @Process)",
                            conn, transaction);
                        cmdProcess.Parameters.AddWithValue("@CertId", certificateId);
                        cmdProcess.Parameters.AddWithValue("@Process", item.ToString());
                        cmdProcess.ExecuteNonQuery();
                    }

                    // 6. Insert Parent Materials
                    foreach (var item in checkedListBoxParentMaterials.CheckedItems)
                    {
                        SqlCommand cmdParent = new SqlCommand(
                            "INSERT INTO CertificateParentMaterials (CertificateId, MaterialGroup) VALUES (@CertId, @MatGroup)",
                            conn, transaction);
                        cmdParent.Parameters.AddWithValue("@CertId", certificateId);
                        cmdParent.Parameters.AddWithValue("@MatGroup", item.ToString());
                        cmdParent.ExecuteNonQuery();
                    }

                    // 7. Insert Filler Material Groups
                    foreach (var item in checkedListBoxFillerGroups.CheckedItems)
                    {
                        SqlCommand cmdFiller = new SqlCommand(
                            "INSERT INTO CertificateFillerMaterialGroups (CertificateId, FillerGroup) VALUES (@CertId, @FillerGroup)",
                            conn, transaction);
                        cmdFiller.Parameters.AddWithValue("@CertId", certificateId);
                        cmdFiller.Parameters.AddWithValue("@FillerGroup", item.ToString());
                        cmdFiller.ExecuteNonQuery();
                    }

                    // 8. Insert Tests from DataGridView
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

                    // Commit transaction
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