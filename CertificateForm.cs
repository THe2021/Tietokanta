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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Validate welder ID
            if (welderId <= 0)
            {
                MessageBox.Show("Invalid welder reference. Cannot save certificate.");
                return;
            }

            // 2. Validate inputs
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

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Certificates
                      (WelderID, CertificateName, IssuingAuthority, IssueDate, ExpiryDate)
                      VALUES (@WelderID, @Name, @Auth, @Issue, @Exp)", conn))
                {
                    cmd.Parameters.Add("@WelderID", SqlDbType.Int).Value = welderId;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 200).Value = textBoxCertName.Text.Trim();
                    cmd.Parameters.Add("@Auth", SqlDbType.NVarChar, 100).Value = textBoxAuthority.Text.Trim();
                    cmd.Parameters.Add("@Issue", SqlDbType.Date).Value = dateTimePickerIssue.Value.Date;
                    cmd.Parameters.Add("@Exp", SqlDbType.Date).Value = dateTimePickerExpiry.Value.Date;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Certificate added successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert certificate:\n" + ex.Message);
            }
        }
    }
}