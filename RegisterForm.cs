using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DataBaseA
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get input values
            string name = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string company = textBox3.Text.Trim();
            string password = textBox4.Text; // In real apps, hash this

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(company) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Hash the password before storing (example with SHA256)
            string hashedPassword = HashPassword(password);

            // Connection string to your SQL database
            string connString = ConfigurationManager
            .ConnectionStrings["DataBaseA.Properties.Settings.DatabaseAConnectionString"]
            ?.ConnectionString;

            string query = "INSERT INTO Rekisteri (Name, Email, Company, Password) VALUES (@Name, @Email, @Company, @Password)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Use parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Company", company);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                MessageBox.Show("Registration successful!");
                // Optionally clear textboxes

                this.Hide();

                LoginForm loginForm = new LoginForm();
                loginForm.FormClosed += (s, args) => this.Close(); // Close RegisterForm only after loginForm closes
                loginForm.Show();


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
