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
            string tableName = Organizer.TableName;
            Database.VeiwBookingsData(tableName, dataGridView1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Organizer_interface organizer_Interface = new Organizer_interface();
            organizer_Interface.Show();
            this.Hide();
        }
    }
}
