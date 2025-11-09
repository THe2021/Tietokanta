using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace DataBaseA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                        cmd.Parameters.AddWithValue("@DOB", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Employer", textBox5.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show(textBox1.Text);
                    conn.Close();
                    conn.Dispose();
                }
            
            MessageBox.Show("Done!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}