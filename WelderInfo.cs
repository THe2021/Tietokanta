using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataBaseA
{
    public partial class WelderInfo : Form
    {
        private int WelderId;

        // Default constructor (needed for the Add New Welder screen)
        public WelderInfo()
        {
            InitializeComponent();
            this.Load += WelderInfo_Load;
        }

        // Constructor used when opening a specific welder from the list
        public WelderInfo(int welderId)
        {
            InitializeComponent();
            WelderId = welderId;

            this.Load += WelderInfo_Load;
        }

        private void WelderInfo_Load(object sender, EventArgs e)
        {
            LoadWelderDetails();
            LoadCertificates(); // ← NEW
        }

        private void LoadWelderDetails()
        {
            // If WelderInfo was opened with the default constructor,
            // WelderId will be 0 and we should NOT try to load anything
            if (WelderId <= 0)
                return;

            string connString = ConfigurationManager
                .ConnectionStrings["DataBaseA.Properties.Settings.DatabaseAConnectionString"]
                .ConnectionString;

            string query = "SELECT * FROM Hitsari WHERE WelderID = @id";

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", WelderId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Fill your form fields with data
                    textBox1.Text = reader["Name"]?.ToString();
                    textBox2.Text = reader["ID"]?.ToString().Trim();   // NCHAR trimmed
                    textBox3.Text = reader["POB"]?.ToString().Trim();

                    if (!reader.IsDBNull(reader.GetOrdinal("DOB")))
                        textBox4.Text = Convert.ToDateTime(reader["DOB"]).ToString("yyyy-MM-dd");

                    textBox5.Text = reader["Employer"]?.ToString();
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 🧩 1. Validate input first
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please fill in all fields before submitting.");
                return; // Stop here — do NOT continue to database insert
            }

            // Parse DOB safely
            if (!DateTime.TryParse(textBox4.Text, out DateTime dob))
            {
                MessageBox.Show("Invalid date format for DOB. Use yyyy-MM-dd.");
                return;
            }


            // Get connection string by name
            string connString = ConfigurationManager
                .ConnectionStrings["DataBaseA.Properties.Settings.DatabaseAConnectionString"]
                ?.ConnectionString;

            if (string.IsNullOrEmpty(connString))
            {
                MessageBox.Show("Connection string not found in App.config!");
                return;
            }


            int newWelderId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string sql = @"
                INSERT INTO dbo.Hitsari (Name, ID, POB, DOB, Employer)
                OUTPUT INSERTED.WelderID
                VALUES (@Name, @ID, @POB, @DOB, @Employer)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@ID", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@POB", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@DOB", dob);
                        cmd.Parameters.AddWithValue("@Employer", textBox5.Text.Trim());

                        // Returns the newly created WelderID
                        newWelderId = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting welder: " + ex.Message);
                return;
            }

            // ---------------------------
            // 4. Open the same form using the correct WelderID
            // ---------------------------
            MessageBox.Show("Welder saved successfully!");

            WelderInfo updatedForm = new WelderInfo(newWelderId);
            updatedForm.Show();

            this.Close(); // close the temp "new welder" form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WelderId <= 0)
            {
                MessageBox.Show("Please save the welder information before adding certificates.");
                return;
            }

            CertificateForm certForm = new CertificateForm(WelderId);

            // Refresh certificate list after closing the certificate window
            certForm.FormClosed += (s, args) => LoadCertificates();

            certForm.ShowDialog(); // modal, so user must finish adding before returning
        }

        private void LoadCertificates()
        {
            if (WelderId <= 0)
                return; // No certificates for a new unsaved welder

            string connString = ConfigurationManager
                .ConnectionStrings["DataBaseA.Properties.Settings.DatabaseAConnectionString"]
                .ConnectionString;

            string query = @"SELECT 
                        Id AS CertificateID,
                        CertificateName,
                        IssuingAuthority,
                        IssueDate,
                        ExpiryDate
                     FROM Certificates 
                     WHERE WelderID = @WelderID";

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@WelderID", WelderId);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewCertificates.DataSource = dt;
                }
            }
        }

        private void dataGridViewCertificates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}