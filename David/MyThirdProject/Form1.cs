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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblHello.Text = "You have succesfully Login....";
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            lblHello.Text = "Hello Welcome again...";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblHello.Text = " Text has been cancel..";
           
            
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide(); 
          LoginForm login = new LoginForm(); 
            login.ShowDialog();
        }
    }
}
