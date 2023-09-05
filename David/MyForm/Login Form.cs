using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           string id = txtUserid.Text;
            string pass = txtPassword.Text;

            if (id == "i1234" && pass == "123456")
            {
                Form2 frm = new Form2();
                frm.Show();
            }
            else MessageBox.Show("password or id is incorrect");
        }

        private void txtUserid_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
