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
            // ComboBoxes (certificate-level)
            // -----------------------------

            comboBoxWeldingPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWeldingPosition.Items.Clear();
            comboBoxWeldingPosition.Items.AddRange(new string[]
            {
        "PA", "PB", "PC", "PD", "PE", "PF", "PG"
            });

            // -----------------------------
            // CheckedListBoxes (certificate-level)
            // -----------------------------

            checkedListBoxJointTypes.Items.Clear();
            checkedListBoxJointTypes.Items.AddRange(new string[] { "BW", "FW" });

            checkedListBoxParentMaterials.Items.Clear();
            checkedListBoxParentMaterials.Items.AddRange(new string[]
            {
        "1","2","3","4","5","6","7","8","9","10","11"
            });

            // -----------------------------
            // Processes DataGridView
            // -----------------------------

            dataGridViewProcesses.AllowUserToAddRows = true;
            dataGridViewProcesses.AutoGenerateColumns = false;
            dataGridViewProcesses.Columns.Clear();
            dataGridViewProcesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Process code (ISO 4063)
            dataGridViewProcesses.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "ProcessCode",
                HeaderText = "Process",
                DataSource = new string[] { "111", "131", "135", "136", "141", "121" }
            });

            // Filler material group (FM1–FM6)
            dataGridViewProcesses.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "FillerMaterialGroup",
                HeaderText = "Filler Group",
                DataSource = new string[] { "FM1", "FM2", "FM3", "FM4", "FM5", "FM6" }
            });

            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FillerMaterialDesignation",
                HeaderText = "Filler Designation"
            });

            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FillerMaterialTradeName",
                HeaderText = "Filler Trade Name"
            });

            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FillerMaterialType",
                HeaderText = "Filler Type"
            });

            dataGridViewProcesses.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "Polarity",
                HeaderText = "Polarity",
                DataSource = new string[] { "AC", "DC+", "DC-" }
            });

            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Auxiliaries",
                HeaderText = "Auxiliaries"
            });

            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ShieldingGas",
                HeaderText = "Shielding Gas"
            });

            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DepositedThickness",
                HeaderText = "Deposited Thickness"
            });

            dataGridViewProcesses.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsMultilayer",
                HeaderText = "Multilayer"
            });

            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "WeldDetails",
                HeaderText = "Weld Details"
            });

            // Add one empty row by default (most certificates = one process)
            dataGridViewProcesses.Rows.Add();

            // -----------------------------
            // Tests DataGridView (unchanged)
            // -----------------------------

            dataGridViewTests.AllowUserToAddRows = true;
            dataGridViewTests.AutoGenerateColumns = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // -----------------------------
            // Basic validation
            // -----------------------------

            if (welderId <= 0)
            {
                MessageBox.Show("Invalid welder reference.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCertName.Text))
            {
                MessageBox.Show("Certificate name is required.");
                return;
            }

            if (dateTimePickerExpiry.Value < dateTimePickerIssue.Value)
            {
                MessageBox.Show("Expiry date cannot be earlier than issue date.");
                return;
            }

            // At least one welding process
            bool hasProcess = dataGridViewProcesses.Rows
                .Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow &&
                          !string.IsNullOrWhiteSpace(
                              r.Cells["ProcessCode"].Value?.ToString()));

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
                SqlTransaction tx = conn.BeginTransaction();

                try
                {
                    // -----------------------------
                    // Insert Certificate
                    // -----------------------------

                    SqlCommand cmdCert = new SqlCommand(
                        @"INSERT INTO Certificates
                (WelderID, CertificateName, IssuingAuthority, IssueDate, ExpiryDate,
                 ProductType, MaterialThickness, OutsidePipeDiameter, WeldingPosition,
                 TestSupervisorName, ExaminationBody, ExaminationSignature, Remarks)
                 VALUES
                (@WelderID, @Name, @Auth, @Issue, @Exp,
                 @ProductType, @MaterialThickness, @PipeDiameter, @WeldingPosition,
                 @Supervisor, @ExamBody, @Signature, @Remarks);
                 SELECT SCOPE_IDENTITY();",
                        conn, tx);

                    cmdCert.Parameters.AddWithValue("@WelderID", welderId);
                    cmdCert.Parameters.AddWithValue("@Name", textBoxCertName.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Auth", textBoxAuthority.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Issue", dateTimePickerIssue.Value.Date);
                    cmdCert.Parameters.AddWithValue("@Exp", dateTimePickerExpiry.Value.Date);
                    cmdCert.Parameters.AddWithValue("@ProductType", textBoxProductType.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@MaterialThickness", numericMaterialThickness.Value);
                    cmdCert.Parameters.AddWithValue("@PipeDiameter", numericPipeDiameter.Value);
                    cmdCert.Parameters.AddWithValue("@WeldingPosition",
                        comboBoxWeldingPosition.SelectedItem?.ToString());
                    cmdCert.Parameters.AddWithValue("@Supervisor", textBoxSupervisorName.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@ExamBody", textBoxExaminationBody.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Signature", textBoxExaminationSignature.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Remarks", textBoxRemarks.Text.Trim());

                    int certificateId = Convert.ToInt32(cmdCert.ExecuteScalar());

                    // -----------------------------
                    // Insert Joint Types
                    // -----------------------------

                    foreach (var jt in checkedListBoxJointTypes.CheckedItems)
                    {
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO CertificateJointTypes (CertificateId, JointType) VALUES (@C, @J)",
                            conn, tx);
                        cmd.Parameters.AddWithValue("@C", certificateId);
                        cmd.Parameters.AddWithValue("@J", jt.ToString());
                        cmd.ExecuteNonQuery();
                    }

                    // -----------------------------
                    // Insert Parent Materials
                    // -----------------------------

                    foreach (var pm in checkedListBoxParentMaterials.CheckedItems)
                    {
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO CertificateParentMaterials (CertificateId, MaterialGroup) VALUES (@C, @M)",
                            conn, tx);
                        cmd.Parameters.AddWithValue("@C", certificateId);
                        cmd.Parameters.AddWithValue("@M", pm.ToString());
                        cmd.ExecuteNonQuery();
                    }

                    // -----------------------------
                    // Insert Welding Processes
                    // -----------------------------

                    foreach (DataGridViewRow row in dataGridViewProcesses.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string processCode = row.Cells["ProcessCode"].Value?.ToString();
                        if (string.IsNullOrWhiteSpace(processCode)) continue;

                        SqlCommand cmdProc = new SqlCommand(
                            @"INSERT INTO CertificateProcessDetails
                      (CertificateId, ProcessCode, FillerMaterialGroup,
                       FillerMaterialDesignation, FillerMaterialTradeName, FillerMaterialType,
                       TypeOfCurrentPolarity, Auxiliaries, ShieldingGas,
                       DepositedThickness, IsMultilayer, WeldDetails)
                      VALUES
                      (@C, @P, @FMG, @FD, @FTN, @FT,
                       @Pol, @Aux, @Gas, @Dep, @Multi, @Weld)",
                            conn, tx);

                        cmdProc.Parameters.AddWithValue("@C", certificateId);
                        cmdProc.Parameters.AddWithValue("@P", processCode);
                        cmdProc.Parameters.AddWithValue("@FMG",
                            row.Cells["FillerMaterialGroup"].Value?.ToString());
                        cmdProc.Parameters.AddWithValue("@FD",
                            row.Cells["FillerMaterialDesignation"].Value?.ToString());
                        cmdProc.Parameters.AddWithValue("@FTN",
                            row.Cells["FillerMaterialTradeName"].Value?.ToString());
                        cmdProc.Parameters.AddWithValue("@FT",
                            row.Cells["FillerMaterialType"].Value?.ToString());
                        cmdProc.Parameters.AddWithValue("@Pol",
                            row.Cells["Polarity"].Value?.ToString());
                        cmdProc.Parameters.AddWithValue("@Aux",
                            row.Cells["Auxiliaries"].Value?.ToString());
                        cmdProc.Parameters.AddWithValue("@Gas",
                            row.Cells["ShieldingGas"].Value?.ToString());
                        cmdProc.Parameters.AddWithValue("@Dep",
                            row.Cells["DepositedThickness"].Value ?? (object)DBNull.Value);
                        cmdProc.Parameters.AddWithValue("@Multi",
                            row.Cells["IsMultilayer"].Value ?? false);
                        cmdProc.Parameters.AddWithValue("@Weld",
                            row.Cells["WeldDetails"].Value?.ToString());

                        cmdProc.ExecuteNonQuery();
                    }

                    tx.Commit();
                    MessageBox.Show("Certificate saved successfully.");
                    Close();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Error saving certificate:\n" + ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}