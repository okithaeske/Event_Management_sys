using Evennt_management.Classes.Controller_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Evennt_management.Forms
{
    public partial class UpdateUser : Form
    {
        private Form _previousForm;
        public UpdateUser(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // to see whether all the textboxes are filled before submition
            if (string.IsNullOrWhiteSpace(textBox1.Text) &&
              string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Atleast one field required. Please fill in the fieldo.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without further processing
            }

            // assigning variables
            string name = textBox1.Text;
            string age = textBox2.Text;

            // calling function from person class
            Person.ChangeDetails(name, age,this);
            
            // limitations
            if (name.Length < 3)
            {
                MessageBox.Show("Name must be at least 3 characters long.");
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _previousForm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
