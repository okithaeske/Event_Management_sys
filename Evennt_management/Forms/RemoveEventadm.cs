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
    public partial class RemoveEventadm : Form
    {
        public RemoveEventadm()
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
            string ename = textBox1.Text;
            // Remove whitespaces
            string EventName = ename.Replace(" ", "");
            Database.AdminDeleteEvent(EventName);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
