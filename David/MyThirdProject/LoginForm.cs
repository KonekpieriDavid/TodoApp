using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyThirdProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            string id = txtUserId.Text;
            string password = txtPassword.Text;

            if (id == "!2345" && password == "1234567")

            {
                Form1 f = new Form1();
                f.Show();

                
            }
            else
            {
                MessageBox.Show("UserId or password incorrect!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtPassword.Text = "";

           
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome Back!";
        }
    }
}
