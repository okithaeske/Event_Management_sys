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
            string tableName = textBox1.Text;
            Organizer.TableName = tableName;

            ViewBookingsadm_interface viewBookingsadm_Interface = new ViewBookingsadm_interface();
            viewBookingsadm_Interface.Show();
            this.Hide();

          
        }
    }
}
