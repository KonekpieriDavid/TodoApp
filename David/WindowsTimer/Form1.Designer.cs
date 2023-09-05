namespace WindowsTimer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnopenForm2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnopenForm2
            // 
            this.btnopenForm2.AutoSize = true;
            this.btnopenForm2.Location = new System.Drawing.Point(402, 271);
            this.btnopenForm2.Name = "btnopenForm2";
            this.btnopenForm2.Size = new System.Drawing.Size(75, 26);
            this.btnopenForm2.TabIndex = 0;
            this.btnopenForm2.Text = "button1";
            this.btnopenForm2.UseVisualStyleBackColor = true;
            this.btnopenForm2.Click += new System.EventHandler(this.btnopenForm2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnopenForm2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnopenForm2;
    }
}

