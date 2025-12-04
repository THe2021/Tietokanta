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

            // Add double-click event
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void LoadWelderData()
        {
            try
            {
                string connString = ConfigurationManager
                    .ConnectionStrings["DataBaseA.Properties.Settings.DatabaseAConnectionString"]
                    .ConnectionString;

                string query = "SELECT * FROM Hitsari"; // Table name

                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load welder data:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can leave this empty
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ignore header

            int welderId = Convert.ToInt32(
                dataGridView1.Rows[e.RowIndex].Cells["WelderID"].Value);

            WelderInfo infoForm = new WelderInfo(welderId);
            infoForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ⚠ If this button is supposed to refresh the table, do THIS:
            LoadWelderData();

            // If it was supposed to open a NEW form (risky), let me know.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            WelderInfo welderinfo = new WelderInfo();
            welderinfo.FormClosed += (s, args) => this.Close();
            welderinfo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a welder to delete.");
                return;
            }

            // Get selected WelderID
            int welderId = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["WelderID"].Value);

            // Confirm delete
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this welder?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            // Execute delete
            string connString = ConfigurationManager
                .ConnectionStrings["DataBaseA.Properties.Settings.DatabaseAConnectionString"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Hitsari WHERE WelderID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", welderId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Refresh the list
            LoadWelderData();

            MessageBox.Show("Welder deleted successfully.");
        }
    }
}
