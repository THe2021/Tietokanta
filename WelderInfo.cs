using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace DataBaseA
{
    public partial class WelderInfo : Form
    {
        private int WelderId;

        // Default constructor (needed for the Add New Welder screen)
        public WelderInfo()
        {
            InitializeComponent();
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


            // Get connection string by name
            string connString = ConfigurationManager
                .ConnectionStrings["DataBaseA.Properties.Settings.DatabaseAConnectionString"]
                ?.ConnectionString;

            if (string.IsNullOrEmpty(connString))
            {
                MessageBox.Show("Connection string not found in App.config!");
                return;
            }
            try { 
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Hitsari (Name, ID, POB, DOB, Employer) VALUES (@Name, @ID, @POB, @DOB, @Employer)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@ID", textBox2.Text);
                        cmd.Parameters.AddWithValue("@POB", textBox3.Text);
                        cmd.Parameters.AddWithValue("@DOB", DateTime.Parse(textBox4.Text));
                        cmd.Parameters.AddWithValue("@Employer", textBox5.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            

                this.Hide();

                WelderListForm welderlistform = new WelderListForm();
                welderlistform.FormClosed += (s, args) => this.Close();
                welderlistform.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}