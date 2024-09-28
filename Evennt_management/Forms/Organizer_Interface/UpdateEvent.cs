using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Evennt_management
{
    public partial class UpdateEvent : Form
    {
        public UpdateEvent()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreatedEvent_interface createdEvent_Interface = new CreatedEvent_interface();
            createdEvent_Interface.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // validations

            if
             (string.IsNullOrWhiteSpace(textBox6.Text) ||
             string.IsNullOrWhiteSpace(textBox5.Text) ||
             string.IsNullOrWhiteSpace(textBox2.Text) ||
             string.IsNullOrWhiteSpace(maskedTextBox1.Text) ||
             string.IsNullOrWhiteSpace(maskedTextBox2.Text))
            {
                MessageBox.Show("All fields are required. Please enter in all the feilds", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without further processing
            }

            // initialising the variables
            DateTime dateTime = dateTimePicker1.Value;
            string nName = textBox6.Text;
            // Remove whitespaces
            string newName = nName.Replace(" ", "");
            string cname = textBox5.Text;
            // Remove whitespaces
            string currentname = cname.Replace(" ", "");
            string newplace = textBox2.Text;
            int newprice = int.Parse(maskedTextBox1.Text);
            int newquantity = Convert.ToInt32(maskedTextBox2.Text);

            string date = (dateTime.Date).ToString("yyy/MM/dd");
            string time = (dateTime.TimeOfDay).ToString(@"hh\:mm\:ss");

            // limitations
            if (newName.Length < 4)
            {
                MessageBox.Show(" New Event Name must be at least 4 characters long.");
            }
            if (newplace.Length < 4)
            {
                MessageBox.Show("Place must be at least 4 characters long.");
            }
            if (newprice < 0)
            {
                MessageBox.Show("Price cannot be a negative value.");
            }


            //calling the function 
            Event e1 = new Event(currentname, date, time, newplace, newprice, newquantity, newName);
            Organizer org1 = new Organizer();
            org1.UpdateEvent(e1, this);




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            maskedTextBox1.Text = string.Empty;
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            maskedTextBox2.Text = string.Empty;
        }
    }
}
