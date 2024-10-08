﻿using Evennt_management.Forms;
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
    public partial class Participant_interface : Form
    {
        public Participant_interface()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // If statement see whether user want to leave or not
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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Veiw = new View_Events(this);
            Veiw.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterEvent registerEvent = new RegisterEvent();
            registerEvent.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Joined_events joined_Events = new Joined_events();
            joined_Events.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var viewpersonal = new PersonalDetails(this);
            viewpersonal.Show();
            this.Hide();
        }
    }
}
