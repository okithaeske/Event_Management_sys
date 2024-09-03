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
    public partial class Admin_interface : Form
    {
        public Admin_interface()
        {
            InitializeComponent();
        }

        private void Admin_interface_Load(object sender, EventArgs e)
        {
            Database.VeiwData(dataGridView1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout", "logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Hide();

            }
            else
            {
                this.Show();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveEventadm removeEventadm = new RemoveEventadm();
            removeEventadm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
