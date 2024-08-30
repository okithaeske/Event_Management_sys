namespace Evennt_management
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 196);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 0;
            label1.Text = "Username";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 251);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Password";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(162, 193);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(202, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(162, 248);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(202, 27);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(288, 318);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(110, 20);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Create Account";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(185, 91);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 5;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(162, 100);
            label4.Name = "label4";
            label4.Size = new Size(91, 35);
            label4.TabIndex = 6;
            label4.Text = "Sign In";
            // 
            // button1
            // 
            button1.Location = new Point(54, 314);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "Sign In";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Location = new Point(12, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(411, 428);
            panel1.TabIndex = 8;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(435, 594);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(linkLabel1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Login";
            Text = "Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private LinkLabel linkLabel1;
        private Label label3;
        private Label label4;
        private Button button1;
        private Panel panel1;
    }
}
