﻿using System;
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
    public partial class LeaveEvent_interface : Form
    {
        public LeaveEvent_interface()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Joined_events joined_Events = new Joined_events();
            joined_Events.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tableName =textBox1.Text;
            Database.LeaveEvent(tableName, this);
        }
    }
}
