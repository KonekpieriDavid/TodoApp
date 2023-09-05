using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CalculatorProject
{
   
    public partial class Form1 : Form
    {
        
        Double result = 0;
        string operation = "";
        bool enter_value = false;
        string firstnumber, secondnumber;
        string memory = "";
        //string Modulo = "";
       // string timer = "";
       
        public Form1()
        {

          

            InitializeComponent();

            //timer1.Tick += new EventHandler(timer1_Tick); // when timer ticks, timer_Tick will be called
            //timer1.Interval = 1000;             // Timer will tick every 10 seconds
            //.Enabled = true;                       // Enable the timer
           // timer1.Start();
        }

        /*private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            treeView1.Visible = false;
        } */
        






        private void TxtDisplay_Click(object sender, EventArgs e)
        {
            

        }
        private void lblHistoryDisplay_Click(object sender, EventArgs e)
        {


        }
        /*
        private void numbers_only(object sender, EventArgs e)
        {
            Button b =  (Button)sender;
            if ((TxtDisplay.Text == "0" )|| (enter_value))
            TxtDisplay.Text = "";
            enter_value = false; 
            if(b.Text == ".")
            {
                if (!TxtDisplay.Text.Contains("."))
                    TxtDisplay.Text = TxtDisplay.Text + b.Text;
            }
            else
            {
                TxtDisplay.Text = TxtDisplay.Text + b.Text;
            }
        } */

        private void Operator_click(object sender, EventArgs e)
        {

        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            TxtDisplay.Text = "0";
            result = 0;
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtDisplay.Text = "0";
            
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            secondnumber = TxtDisplay.Text;
        
            lblShowOps.Text = "";
            switch(operation)
            {
                case "/":
                    TxtDisplay.Text = (result / Double.Parse (TxtDisplay.Text)).ToString();
                    break;
                case "X":
                    TxtDisplay.Text = (result * Double.Parse(TxtDisplay.Text)).ToString();
                    break;
                case "-":
                    TxtDisplay.Text = (result - Double.Parse(TxtDisplay.Text)).ToString();
                    break;
                case "+":
                    TxtDisplay.Text = (result + Double.Parse(TxtDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            // clear what is in the operator above

            result = Double.Parse (TxtDisplay.Text);
            operation = "";
            //##########################
            BtnClearHistory.Visible = true;
         RtbDisplayHistory.AppendText(firstnumber + " " + secondnumber + " = " + " \n ");
            RtbDisplayHistory.AppendText("\n\t" + TxtDisplay.Text + "\n\n");
            lblHistoryDisplay.Text = "";
        }

        private void rtbDisplayHistory_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnClearHistory_Click(object sender, EventArgs e)
        {
            RtbDisplayHistory.Clear();
            if (lblHistoryDisplay.Text == "")
            {
                lblHistoryDisplay.Text = "There's  not history yet";
            }
            BtnClearHistory.Visible=false;
            RtbDisplayHistory.ScrollBars = 0;

        }

        private void Numbers_Only(object sender, EventArgs e)
        {
            // Handling even of button click for only numbers
            Button b = (Button)sender;
            if ((TxtDisplay.Text == "0") || (enter_value))
                TxtDisplay.Text = "";
            enter_value = false;

            if (b.Text == ".")

            {
                if (!TxtDisplay.Text.Contains("."))
                    TxtDisplay.Text = TxtDisplay.Text + b.Text;
            }
            else
            {
                TxtDisplay.Text = TxtDisplay.Text + b.Text;
            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            // Handling even of button click for Arithmetic operation

            Button b = (Button)sender;
            if(result !=0)
            { 
            operation = b.Text;
            result = Double.Parse(TxtDisplay.Text);
            TxtDisplay.Text = "";
            lblShowOps.Text = System.Convert.ToString(result) + "  " + operation;
            }
            else
            {
                operation =b.Text;
                result=Double.Parse(TxtDisplay.Text);   
                enter_value=false;
                lblShowOps.Text = result + " " + operation;
            }
            firstnumber = lblShowOps.Text;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            treeView1.Visible = true;
        }

        // display the list types of calculator in treeVeiw
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "Node0")
            {
                lblTitle.Text = "Calculator";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node2")
            {
                lblTitle.Text = "standard";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node4")
            {
                lblTitle.Text = "Scientific";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node6")
            {
                lblTitle.Text = "Graphing";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node8")
            {
                lblTitle.Text = "Programmer";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node10")
            {
                lblTitle.Text = "Data Calculation";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node12")
            {
                lblTitle.Text = "Converter";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node14")
            {
                lblTitle.Text = "Volume";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node16")
            {
                lblTitle.Text = "Lengh";
                treeView1.Visible = false;

            }
            if (e.Node.Name == "Node18")
            {
                lblTitle.Text = "Weight and Mass";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node20")
            {
                lblTitle.Text = "Temperature";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node22")
            {
                lblTitle.Text = "Energy";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node24")
            {
                lblTitle.Text = "Area";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node26")
            {
                lblTitle.Text = "Speed";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node28")
            {
                lblTitle.Text = "Time";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node30")
            {
                lblTitle.Text = "Power";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node32")
            {
                lblTitle.Text = "Date";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node34")
            {
                lblTitle.Text = "Angle";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node36")
            {
                lblTitle.Text = "Settings";
                treeView1.Visible = false;
            }


        }

        private void Square_Click(object sender, EventArgs e)
        {
            // Here is where the square Root of a number is taking action
            Button b = (Button)sender;
            if (result != 0)
            {
                if (b.Text == "sqrtR")
                    TxtDisplay.Text = SquareRoot.sqrt(Double.Parse(TxtDisplay.Text)).ToString();
                result = Double.Parse(TxtDisplay.Text);
                enter_value = false;
           
                lblShowOps.Text = result + " " + operation;

            }
            else if (b.Text == "sqrtR")
            {
              TxtDisplay.Text = SquareRoot.sqrt(Double.Parse(TxtDisplay.Text)).ToString();
                result = Math.Sqrt(Double.Parse(TxtDisplay.Text));
            }
            else
            {
                operation = b.Text;
                result = Double.Parse(TxtDisplay.Text);
                enter_value = true;
                lblShowOps.Text = result + " " + operation;
            }
            firstnumber = lblShowOps.Text;
        }

        private void BtnSquareTwo_Click(object sender, EventArgs e)
        {
            // here i square  a number 
            TxtDisplay.Text = Convert.ToString((Convert.ToDecimal (TxtDisplay.Text) * Convert.ToDecimal(TxtDisplay.Text)));

        }

        private void BtnPlusMinus_Click(object sender, EventArgs e)
        {
            //Minus plus button
            Double result = Convert.ToDouble(TxtDisplay.Text);
            TxtDisplay.Text = Convert.ToString(-1 * result);

    
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "Node0")
            {
                lblTitle.Text = "There's no history yet";
                treeView1.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Memory add
            memory = TxtDisplay.Text;
            lblShowOps.Text = "M";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MC memory clear
            memory = "";
            lblShowOps.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Mr memory revel
            TxtDisplay.Text = memory;
        }

        private void BtnPercent_Click(object sender, EventArgs e)
        {
            Double firstnumber;
            firstnumber = Convert.ToDouble(TxtDisplay.Text) / Convert.ToDouble(100);
            TxtDisplay.Text = firstnumber.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Multiplicative inverse for 1/x button
            Double firstnumber;
            firstnumber = Convert.ToDouble(1.0 / Convert.ToDouble(TxtDisplay.Text));
            TxtDisplay.Text = firstnumber.ToString();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
          
            treeView1.Visible = false;
            

        }
        //int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
          
           timer1.Tick += new EventHandler(timer1_Tick); // when timer ticks, timer_Tick will be called
            timer1.Interval = 10000;             // Timer will tick every 10 seconds
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();
            if (timer1.Interval == 10000) 
               
            {
                timer1.Stop();
                MessageBox.Show("Application is  Idle");

                //when the application is uncommented when click on the popup message it closes the application.

               // Application.Exit(); 



            }

      
        }

        

        private void BtnClear_Click(object sender, EventArgs e)
        {
             if (TxtDisplay.Text .Length > 0)
            {
                TxtDisplay.Text =TxtDisplay.Text.Remove(TxtDisplay.Text.Length - 1, 1);
            }
             if (TxtDisplay.Text == "")
            {
                TxtDisplay.Text = "0";
            }
        }

        
    }
}


        
  

