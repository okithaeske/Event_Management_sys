namespace Evennt_management.Forms
{
    partial class LeaveEvent_interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaveEvent_interface));
            panel1 = new Panel();
            textBox1 = new TextBox();
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(60, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(733, 409);
            panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(304, 183);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(245, 30);
            textBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(304, 294);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(27, 363);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(40, 20);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Back";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(179, 184);
            label2.Name = "label2";
            label2.Size = new Size(106, 23);
            label2.TabIndex = 1;
            label2.Text = "Event Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(272, 22);
            label1.Name = "label1";
            label1.Size = new Size(207, 46);
            label1.TabIndex = 0;
            label1.Text = "Leave Event";
            // 
            // LeaveEvent_interface
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(849, 490);
            Controls.Add(panel1);
            Name = "LeaveEvent_interface";
            Text = "LeaveEvent_interface";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private Button button1;
        private LinkLabel linkLabel1;
        private Label label2;
        private Label label1;
    }
}