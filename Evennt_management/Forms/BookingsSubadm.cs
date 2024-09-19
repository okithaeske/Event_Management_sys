using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evennt_management.Forms
{
    public partial class BookingsSubadm : Form
    {
        public BookingsSubadm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin_interface admin_Interface = new Admin_interface();
            admin_Interface.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tName = textBox1.Text;
            // Remove whitespaces
            string tableName = tName.Replace(" ", "");
            Organizer.TableName = tableName;

            ViewBookingsadm_interface viewBookingsadm_Interface = new ViewBookingsadm_interface();
            viewBookingsadm_Interface.Show();
            this.Hide();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BookingsSubadm_Load(object sender, EventArgs e)
        {
            Database.VeiwData(dataGridView1);
        }
    }
}
