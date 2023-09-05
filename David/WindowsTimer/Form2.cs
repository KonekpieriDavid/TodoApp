using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsTimer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Timer timer;
        int Counter = 10;

        private void Form2_Load(object sender,  EventArgs e)
        {

            Timer timer2 = new Timer();
            Timer.Interval = 100;
            timer_Tick += new EventHandler();
            timer2.Start();
            label1.Text = Counter.ToString();
        }
        private void timer_Tick()
        {

            Counter--;
            if(Counter == 00)
            {
                timer.Stop();
                this.Close();

            }
            label1.Text=Counter.ToString();
        }
    }
}
