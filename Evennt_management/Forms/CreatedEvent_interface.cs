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
    public partial class CreatedEvent_interface : Form
    {
        public CreatedEvent_interface()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CreatedEvent_interface_Load(object sender, EventArgs e)
        {
            Database.DisplayEventsByOrganizer(dataGridView1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Organizer_interface organizer_Interface = new Organizer_interface();
            organizer_Interface.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateEvent updateEvent = new UpdateEvent();
            updateEvent.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteEvent_interface deleteEvent = new DeleteEvent_interface();
            deleteEvent.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookingsSub_interface bookingsSub_Interface = new BookingsSub_interface();
            bookingsSub_Interface.Show();
            this.Hide();
        }
    }
}
