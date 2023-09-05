using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySecondProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName =txtFirstName.Text;
            string secondName = txtSecondName.Text;
             lbWelCome.Text = firstName + " " + secondName;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            lbWelCome.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbWelCome.Text = "";
        }
    }
}
