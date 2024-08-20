namespace Evennt_management
{
    partial class Register
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            panel1 = new Panel();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Location = new Point(18, 82);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 118);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 1;
            label2.Text = "Age";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Location = new Point(18, 159);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 2;
            label3.Text = "Role";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 192);
            label4.Name = "label4";
            label4.Size = new Size(24, 20);
            label4.TabIndex = 3;
            label4.Text = "ID";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 224);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 4;
            label5.Text = "Username";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 260);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 5;
            label6.Text = "Password";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16F);
            label7.Location = new Point(115, 22);
            label7.Name = "label7";
            label7.Size = new Size(112, 37);
            label7.TabIndex = 6;
            label7.Text = "Register";
            label7.Click += label7_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(128, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(216, 27);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(128, 118);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(216, 27);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(128, 152);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(216, 27);
            textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(128, 185);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(216, 27);
            textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(128, 221);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(216, 27);
            textBox5.TabIndex = 11;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(128, 257);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(216, 27);
            textBox6.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox2);
            panel1.Location = new Point(40, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(362, 398);
            panel1.TabIndex = 13;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.Location = new Point(115, 325);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 13;
            button1.Text = "Sign up";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(445, 564);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form2";
            Text = "Form2";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Panel panel1;
        private Button button1;
    }
}