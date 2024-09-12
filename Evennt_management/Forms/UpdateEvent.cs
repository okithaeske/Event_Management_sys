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

            if
             (string.IsNullOrWhiteSpace(textBox6.Text) ||
             string.IsNullOrWhiteSpace(textBox5.Text) ||
             string.IsNullOrWhiteSpace(textBox2.Text) ||
             string.IsNullOrWhiteSpace(textBox3.Text) ||
             string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without further processing
            }

            DateTime dateTime = dateTimePicker1.Value;
            string nName = textBox6.Text;
            // Remove whitespaces
            string newName = nName.Replace(" ", "");
            string cname = textBox5.Text;
            // Remove whitespaces
            string currentname = cname.Replace(" ", "");
            string newplace = textBox2.Text;
            int newprice = int.Parse(textBox3.Text);
            int newquantity = Convert.ToInt32(textBox4.Text);

            string date = (dateTime.Date).ToString("yyy/MM/dd");
            string time = (dateTime.TimeOfDay).ToString(@"hh\:mm\:ss");

            //Database.UpdateEvent(newName, currentname, date, time, newplace, newprice, newquantity, this);
            Event e1 = new Event(currentname,date, time, newplace, newprice, newquantity, newName);
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
    }
}
