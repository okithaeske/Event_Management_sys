using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evennt_management
{
    public partial class ViewBookings_interface : Form
    {
        public ViewBookings_interface()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VeiwBookings_interface_Load(object sender, EventArgs e)
        {

            Organizer.View_details(dataGridView2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Organizer_interface organizer_Interface = new Organizer_interface();
            organizer_Interface.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without further processing
            }
            string tName = textBox1.Text;
            // Remove whitespaces
            string tableName = tName.Replace(" ", "");

            // calling for the display table of participants
            Organizer o1 = new Organizer();
            Validations OrgAdmInterface = new Organizer();
            OrgAdmInterface.VeiwBookingsData(tableName, dataGridView1);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
