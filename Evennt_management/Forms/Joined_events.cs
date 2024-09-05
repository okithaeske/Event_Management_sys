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
    public partial class Joined_events : Form
    {
        public Joined_events()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Participant_interface participant_Interface = new Participant_interface();
            participant_Interface.Show();
            this.Hide();
        }

        private void Joined_events_Load(object sender, EventArgs e)
        {
            Database.GetRegisteredTables(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LeaveEvent_interface leaveEvent_Interface = new LeaveEvent_interface();
            leaveEvent_Interface.Show();
            this.Hide();
        }
    }
}
