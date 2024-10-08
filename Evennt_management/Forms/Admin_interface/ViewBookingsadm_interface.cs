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
            // shows the events created
            Person.VeiwEvents(dataGridView2);


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string tableName = Organizer.TableName;
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(tableName)) 
            {
                MessageBox.Show("Enter a valid Event name");
            }
            else
            {   
                RemoveUser removeUser = new RemoveUser();
                removeUser.Show();
                this.Hide();
            }
            

        

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without further processing
            }
            string tName = textBox1.Text;
            // Remove whitespaces
            string tableName = tName.Replace(" ", "");
            Organizer.TableName = tableName;

            if (!string.IsNullOrEmpty(tableName))
            {
                // calling function through interface
                Admin o1 = new Admin();
                Validations OrgAdmInterface = new Admin();
                OrgAdmInterface.VeiwBookingsData(tableName, dataGridView1);
            }
            else
            {
                MessageBox.Show("Please enter a valid event name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
