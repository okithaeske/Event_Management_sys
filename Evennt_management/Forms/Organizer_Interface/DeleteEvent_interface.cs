﻿using Evennt_management.Classes.Controller_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Evennt_management
{
    public partial class DeleteEvent_interface : Form
    {
        public DeleteEvent_interface()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreatedEvent_interface createdEvent_Interface = new CreatedEvent_interface();
            createdEvent_Interface.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // validations
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without further processing
            }

            // intialisng the variables
            string name = textBox1.Text;
            // Remove whitespaces
            string eventname = name.Replace(" ", "");

            // calling the function
            Organizer o1 = new Organizer();
            o1.RemoveEvent(eventname,this, "CreatedEvent");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DeleteEvent_interface_Load(object sender, EventArgs e)
        {
            Organizer.VeiwEvents(dataGridView1);
        }
    }
}
