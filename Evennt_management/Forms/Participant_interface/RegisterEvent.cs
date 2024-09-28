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

namespace Evennt_management
{
    public partial class RegisterEvent : Form
    {
        public RegisterEvent()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Participant_interface participant_Interface = new Participant_interface();
            participant_Interface.Show();
            this.Hide();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Input validations
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox3.Text) ||
               string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without further processing
            }

            // initialising variables
            string eName = textBox2.Text;
            // Remove whitespaces
            string eventName = eName.Replace(" ", "");
            string pname = textBox1.Text;
            int age = Convert.ToInt32(textBox3.Text);
            int price = Convert.ToInt32(textBox4.Text);

            // calling the fucntion by creating a aprticipant object and sending parameters through the participant object
            Participant p1 = new Participant();
            p1.JoinEvent(eventName, pname, age, price);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterEvent_Load(object sender, EventArgs e)
        {
            Person.VeiwEvents(dataGridView1);
        }
    }
}
