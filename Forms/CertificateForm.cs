using DataBaseA.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

            dataGridViewProcesses.Columns.Clear();

            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Field",
                HeaderText = "Field",
                ReadOnly = true
            });

            dataGridViewProcesses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Value",
                HeaderText = "Value"
            });


            dataGridViewProcesses.AllowUserToAddRows = false;
            dataGridViewProcesses.RowHeadersVisible = false;
            dataGridViewProcesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewProcesses.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewProcesses.Columns[0].ReadOnly = true;
            dataGridViewProcesses.Columns[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

            dataGridViewProcesses.BorderStyle = BorderStyle.None;
            dataGridViewProcesses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridViewProcesses.Rows.Add("Process Code", "");
            dataGridViewProcesses.Rows.Add("Product Type", "");
            dataGridViewProcesses.Rows.Add("Joint Type", "");
            dataGridViewProcesses.Rows.Add("Parent Material 1", "");
            dataGridViewProcesses.Rows.Add("Parent Material 2", "");
            dataGridViewProcesses.Rows.Add("Filler Material Group", "");
            dataGridViewProcesses.Rows.Add("Filler Designation", "");
            dataGridViewProcesses.Rows.Add("Filler Trade Name", "");
            dataGridViewProcesses.Rows.Add("Filler Type", "");
            dataGridViewProcesses.Rows.Add("Polarity", "");
            dataGridViewProcesses.Rows.Add("Auxiliaries", "");
            dataGridViewProcesses.Rows.Add("Shielding Gas", "");
            dataGridViewProcesses.Rows.Add("Material Thickness", "");
            dataGridViewProcesses.Rows.Add("Deposited Thickness", "");
            dataGridViewProcesses.Rows.Add("Pipe Diameter", "");
            dataGridViewProcesses.Rows.Add("Welding Position", "");
            dataGridViewProcesses.Rows.Add("Multilayer", "");
            dataGridViewProcesses.Rows.Add("Weld Details", "");

            // Process Code
            var processCell = new DataGridViewComboBoxCell();
            processCell.Items.AddRange("111", "131", "135", "136", "141", "121");
            dataGridViewProcesses.Rows[0].Cells[1] = processCell;

            // Product Type
            dataGridViewProcesses.Rows[1].Cells[1] = new DataGridViewComboBoxCell
            {
                DataSource = new string[] { "T", "P" }
            };

            // Joint type
            dataGridViewProcesses.Rows[2].Cells[1] = new DataGridViewComboBoxCell
            {
                DataSource = new string[] { "BW", "FW", "BW + FW" }
            };

            // Parent material 1
            dataGridViewProcesses.Rows[3].Cells[1] = new DataGridViewComboBoxCell
            {
                DataSource = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" }
            };

            // Parent material 2
            dataGridViewProcesses.Rows[4].Cells[1] = new DataGridViewComboBoxCell
            {
                DataSource = new string[] { "", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" }
            };

            // Filler Material Group
            var fillerCell = new DataGridViewComboBoxCell();
            fillerCell.Items.AddRange("FM1", "FM2", "FM3", "FM4", "FM5", "FM6");
            dataGridViewProcesses.Rows[5].Cells[1] = fillerCell;

            // Filler Designation (TEXT)
            dataGridViewProcesses.Rows[6].Cells[1] = new DataGridViewTextBoxCell();

            // Filler Trade Name (TEXT)
            dataGridViewProcesses.Rows[7].Cells[1] = new DataGridViewTextBoxCell();

            // Filler Type (TEXT)
            dataGridViewProcesses.Rows[8].Cells[1] = new DataGridViewTextBoxCell();

            // Polarity
            var polarityCell = new DataGridViewComboBoxCell();
            polarityCell.Items.AddRange("AC", "DC+", "DC-");
            dataGridViewProcesses.Rows[9].Cells[1] = polarityCell;

            // Auxiliaries (TEXT)
            dataGridViewProcesses.Rows[10].Cells[1] = new DataGridViewTextBoxCell();

            // Shielding Gas (TEXT for now)
            dataGridViewProcesses.Rows[11].Cells[1] = new DataGridViewTextBoxCell();

            // Material Thickness (TEXT)
            dataGridViewProcesses.Rows[12].Cells[1] = new DataGridViewTextBoxCell();

            // Deposited Thickness (TEXT)
            dataGridViewProcesses.Rows[13].Cells[1] = new DataGridViewTextBoxCell();

            // Pipe Diameter
            dataGridViewProcesses.Rows[14].Cells[1] = new DataGridViewTextBoxCell();

            // Welding Position
            dataGridViewProcesses.Rows[15].Cells[1] = new DataGridViewComboBoxCell
            {
                DataSource = new string[] { "PA", "PB", "PC", "PD", "PE", "PF", "PG" }
            };

            // Multilayer (CHECKBOX)
            dataGridViewProcesses.Rows[16].Cells[1] = new DataGridViewCheckBoxCell();

            // Weld Details (TEXT)
            dataGridViewProcesses.Rows[17].Cells[1] = new DataGridViewTextBoxCell();

            dataGridViewProcesses.DataError += (s, e2) =>
            {
                e2.ThrowException = false;
            };

            AdjustProcessGridHeight();

            dataGridViewProcesses.CellValidating += (s, args) =>
            {
                var field = dataGridViewProcesses.Rows[args.RowIndex].Cells[0].Value?.ToString();

                if (field == "Pipe Diameter" &&
                    !decimal.TryParse(args.FormattedValue?.ToString(), out _))
                {
                    MessageBox.Show("Pipe Diameter must be a number.");
                    args.Cancel = true;
                }
            };

            dataGridViewProcesses.EditingControlShowing += (s, ev) =>
            {
                if (ev.Control is ComboBox cb)
                {
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;
                    cb.FlatStyle = FlatStyle.Flat;
                }
            };

            dataGridViewProcesses.CurrentCellDirtyStateChanged += (s, ev) =>
            {
                if (dataGridViewProcesses.IsCurrentCellDirty)
                {
                    dataGridViewProcesses.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            dataGridViewProcesses.CellValueChanged += (s, ev) =>
            {
                UpdateCertificateName();
            };

            UpdateCertificateName();

        }
         

        private void AdjustProcessGridHeight()
        {
            int rowHeight = dataGridViewProcesses.RowTemplate.Height;
            int headerHeight = dataGridViewProcesses.ColumnHeadersHeight;

            int rowCount = dataGridViewProcesses.Rows.Count;

            dataGridViewProcesses.Height =
                headerHeight + (rowHeight * rowCount) + 2;
        }


        private string GetProcessValue(string field)
        {
            foreach (DataGridViewRow row in dataGridViewProcesses.Rows)
            {
                if (row.Cells[0].Value?.ToString() == field)
                    return row.Cells[1].Value?.ToString() ?? "";
            }

            return null;
        }

        private void UpdateCertificateName()
        {
            string process = GetProcessValue("Process Code");
            string joint = GetProcessValue("Joint Type");
            string product = GetProcessValue("Product Type");
            string position = GetProcessValue("Welding Position");

            string name = $"{welderId}";

            if (!string.IsNullOrWhiteSpace(process))
                name += $" - {process}";

            if (!string.IsNullOrWhiteSpace(joint))
                name += $" - {joint}";

            if (!string.IsNullOrWhiteSpace(product))
                name += $" - {product}";

            if (!string.IsNullOrWhiteSpace(position))
                name += $" - {position}";

            textBoxCertName.Text = name;
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

            bool hasProcess = !string.IsNullOrWhiteSpace(GetProcessValue("Process Code"));
 

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
                 ProductType, JointType, MaterialThickness, OutsidePipeDiameter, WeldingPosition,
                 TestSupervisorName, ExaminationBody, ExaminationSignature, Remarks)
                 VALUES
                (@WelderID, @Name, @Auth, @Issue, @Exp,
                 @ProductType, @JointType, @MaterialThickness, @PipeDiameter, @WeldingPosition,
                 @Supervisor, @ExamBody, @Signature, @Remarks);
                 SELECT SCOPE_IDENTITY();",
                        conn, tx);

                    cmdCert.Parameters.AddWithValue("@WelderID", welderId);
                    cmdCert.Parameters.AddWithValue("@Name", textBoxCertName.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Auth", textBoxAuthority.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Issue", dateTimePickerIssue.Value.Date);
                    cmdCert.Parameters.AddWithValue("@Exp", dateTimePickerExpiry.Value.Date);
                    cmdCert.Parameters.AddWithValue("@ProductType", GetProcessValue("Product Type"));
                    cmdCert.Parameters.AddWithValue("@JointType", GetProcessValue("Joint Type"));
                    string thicknessText = GetProcessValue("Material Thickness");

                    if (decimal.TryParse(thicknessText, out decimal thickness))
                    {
                        cmdCert.Parameters.AddWithValue("@MaterialThickness", thickness);
                    }
                    else
                    {
                        cmdCert.Parameters.AddWithValue("@MaterialThickness", DBNull.Value);
                    }
                    string pipeText = GetProcessValue("Pipe Diameter");

                    if (decimal.TryParse(pipeText, out decimal pipe))
                    {
                        cmdCert.Parameters.Add("@PipeDiameter", SqlDbType.Decimal).Value = pipe;
                    }
                    else
                    {
                        cmdCert.Parameters.Add("@PipeDiameter", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    cmdCert.Parameters.AddWithValue("@WeldingPosition",
                    GetProcessValue("Welding Position") ?? (object)DBNull.Value);

                    cmdCert.Parameters.AddWithValue("@Supervisor", textBoxSupervisorName.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@ExamBody", textBoxExaminationBody.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Signature", textBoxExaminationSignature.Text.Trim());
                    cmdCert.Parameters.AddWithValue("@Remarks", textBoxRemarks.Text.Trim());

                    int certificateId = Convert.ToInt32(cmdCert.ExecuteScalar());


                    // -----------------------------
                    // Insert Parent Materials
                    // -----------------------------

                    string material1 = GetProcessValue("Parent Material 1");
                    string material2 = GetProcessValue("Parent Material 2");

                    if (string.IsNullOrWhiteSpace(material1))
                    {
                        MessageBox.Show("Parent Material 1 must be selected.");
                        return;
                    }

                    SqlCommand cmd1 = new SqlCommand(
                        "INSERT INTO CertificateParentMaterials (CertificateId, MaterialGroup) VALUES (@C, @M)",
                        conn, tx);

                    cmd1.Parameters.AddWithValue("@C", certificateId);
                    cmd1.Parameters.AddWithValue("@M", material1);

                    cmd1.ExecuteNonQuery();

                    if (!string.IsNullOrWhiteSpace(material2) && material2 != material1)
                    {
                        SqlCommand cmd2 = new SqlCommand(
                            "INSERT INTO CertificateParentMaterials (CertificateId, MaterialGroup) VALUES (@C, @M)",
                            conn, tx);

                        cmd2.Parameters.AddWithValue("@C", certificateId);
                        cmd2.Parameters.AddWithValue("@M", material2);

                        cmd2.ExecuteNonQuery();
                    }


                    // --------------------------------------------------
                    //    INSERT PROCESSDETAILS
                    // -------------------------------------------------

                    string processCode = GetProcessValue("Process Code");

                    if (!string.IsNullOrWhiteSpace(processCode))
                    {
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
                        cmdProc.Parameters.AddWithValue("@FMG", GetProcessValue("Filler Material Group"));
                        cmdProc.Parameters.AddWithValue("@FD", GetProcessValue("Filler Designation"));
                        cmdProc.Parameters.AddWithValue("@FTN", GetProcessValue("Filler Trade Name"));
                        cmdProc.Parameters.AddWithValue("@FT", GetProcessValue("Filler Type"));
                        cmdProc.Parameters.AddWithValue("@Pol", GetProcessValue("Polarity"));
                        cmdProc.Parameters.AddWithValue("@Aux", GetProcessValue("Auxiliaries"));
                        cmdProc.Parameters.AddWithValue("@Gas", GetProcessValue("Shielding Gas"));
                        string depText = GetProcessValue("Deposited Thickness");

                        if (decimal.TryParse(depText, out decimal dep))
                        {
                            cmdProc.Parameters.AddWithValue("@Dep", dep);
                        }
                        else
                        {
                            cmdProc.Parameters.AddWithValue("@Dep", DBNull.Value);
                        }
                        //               cmdProc.Parameters.AddWithValue("@Dep", GetProcessValue("Deposited Thickness") ?? (object)DBNull.Value);
                        cmdProc.Parameters.AddWithValue("@Multi", GetProcessValue("Multilayer") == "True");
                        cmdProc.Parameters.AddWithValue("@Weld", GetProcessValue("Weld Details"));

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