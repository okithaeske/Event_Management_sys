using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Evennt_management
{
    public partial class CreateEvent_interface : Form
    {
        public CreateEvent_interface()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
             string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||
             string.IsNullOrWhiteSpace(textBox5.Text) ||
             string.IsNullOrWhiteSpace(maskedTextBox2.Text) ||
             string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without further processing
            }

            DateTime dateTime = dateTimePicker1.Value;
            string name = textBox1.Text;
            string place = textBox5.Text;
            int price = Convert.ToInt32(maskedTextBox1.Text);
            int quantity = Convert.ToInt32(maskedTextBox2.Text);

            string date = (dateTime.Date).ToString("yyy/MM/dd");
            string time = (dateTime.TimeOfDay).ToString(@"hh\:mm\:ss");

            Event e1 = new Event(date, time, place, price, quantity, name);
            Organizer org = new Organizer();
            org.CreateEvent(e1, this);






        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

  

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Organizer_interface organizer_Interface = new Organizer_interface();
            organizer_Interface.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            maskedTextBox2.Text = string.Empty;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            maskedTextBox1.Text = string.Empty;
        }
    }
}
