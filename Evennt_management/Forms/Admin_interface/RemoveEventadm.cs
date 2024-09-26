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
         
            Admin a1 = new Admin();
            a1.RemoveEvent(EventName,this, "admin");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RemoveEventadm_Load(object sender, EventArgs e)
        {
            Person.VeiwEvents(dataGridView1);
        }
    }
}
