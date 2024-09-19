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
    public partial class ViewBookingsadm_interface : Form
    {
        public ViewBookingsadm_interface()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin_interface admin_Interface = new Admin_interface();
            admin_Interface.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewBookingsadm_interface_Load(object sender, EventArgs e)
        {
            string tableName = Organizer.TableName;
            Admin o1 = new Admin();
            Validations OrgAdmInterface = new Admin();
            OrgAdmInterface.VeiwBookingsData(tableName, dataGridView1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveUser kickUser = new RemoveUser();
            kickUser.Show();
            this.Hide();
        }
    }
}
