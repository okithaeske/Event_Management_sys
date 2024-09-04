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
    public partial class KickUser : Form
    {
        public KickUser()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewBookingsadm_interface viewBookingsadm_Interface = new ViewBookingsadm_interface();
            viewBookingsadm_Interface.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tableName = Organizer.TableName;
            string Name = textBox1.Text;

            Database.kickUser(Name,tableName,this); 

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
