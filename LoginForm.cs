using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBaseA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim(); // User input

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Hash the entered password
            string hashedPassword = HashPassword(password);

            // Get connection string from App.config
            string connString = ConfigurationManager
                .ConnectionStrings["DataBaseA.Properties.Settings.DatabaseAConnectionString"]
                ?.ConnectionString;

            // SQL query — get the stored hashed password
            string query = "SELECT password FROM Rekisteri WHERE email = @Email";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string storedHash = reader["password"].ToString();

                            if (storedHash == hashedPassword)
                            {
                         


                                this.Hide();

                                WelderListForm welderlistform = new WelderListForm();
                                welderlistform.FormClosed += (s, args) => this.Close(); // Close RegisterForm only after loginForm closes
                                welderlistform.Show();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect password.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
