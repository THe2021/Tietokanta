using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DataBaseA
{
    public partial class WelderListForm : Form
    {
        public WelderListForm()
        {
            InitializeComponent();
            this.Load += WelderListForm_Load;
        }

        private void WelderListForm_Load(object sender, EventArgs e)
        {
            LoadWelderData();
        }

        private void LoadWelderData()
        {
            string connString = ConfigurationManager
                .ConnectionStrings["DataBaseA.Properties.Settings.DatabaseAConnectionString"]
                .ConnectionString;

            string query = "SELECT * FROM Hitsari"; // <-- Change table name if needed

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WelderListForm listForm = new WelderListForm();
            listForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            WelderInfo welderinfo = new WelderInfo();
            welderinfo.FormClosed += (s, args) => this.Close(); // Close RegisterForm only after loginForm closes
            welderinfo.Show();
        }
    }
}
