using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseA
{
    public partial class FrontPage : Form
    {
        public FrontPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();  // close FrontPage *after* LoginForm is closed

            login.Show();                       // show LoginForm
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.FormClosed += (s, args) => this.Close();

            register.Show();
        }
    }
}
