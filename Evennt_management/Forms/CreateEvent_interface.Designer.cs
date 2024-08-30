namespace Evennt_management
{
    partial class CreateEvent_interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateEvent_interface));
            panel1 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            linkLabel1 = new LinkLabel();
            button1 = new Button();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.BackgroundImageLayout = ImageLayout.Center;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(36, 25);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(941, 519);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(185, 237);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(251, 30);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged_1;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(74, 449);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(48, 23);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Back";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button1
            // 
            button1.Location = new Point(429, 449);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 14;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(619, 332);
            textBox6.Margin = new Padding(4, 3, 4, 3);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(226, 30);
            textBox6.TabIndex = 12;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(618, 236);
            textBox5.Margin = new Padding(4, 3, 4, 3);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(226, 30);
            textBox5.TabIndex = 11;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(618, 140);
            textBox4.Margin = new Padding(4, 3, 4, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(226, 30);
            textBox4.TabIndex = 10;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(187, 333);
            textBox3.Margin = new Padding(4, 3, 4, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(249, 30);
            textBox3.TabIndex = 9;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(186, 138);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(249, 30);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.WindowText;
            label1.Location = new Point(377, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(190, 48);
            label1.TabIndex = 0;
            label1.Text = "Plan Event";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(72, 141);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(106, 23);
            label2.TabIndex = 1;
            label2.Text = "Event Name";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 236);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(48, 23);
            label3.TabIndex = 2;
            label3.Text = "Date";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 339);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(49, 23);
            label4.TabIndex = 3;
            label4.Text = "Price";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(472, 144);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(138, 23);
            label5.TabIndex = 4;
            label5.Text = "Organizer name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(472, 237);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(51, 23);
            label6.TabIndex = 5;
            label6.Text = "Place";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(473, 339);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(80, 23);
            label7.TabIndex = 6;
            label7.Text = "Quantity";
            // 
            // CreateEvent_interface
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1024, 578);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CreateEvent_interface";
            Text = "CreateEvent_interface";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label1;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox1;
        private Button button1;
        private LinkLabel linkLabel1;
        private DateTimePicker dateTimePicker1;
    }
}