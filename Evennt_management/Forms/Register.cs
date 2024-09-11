﻿using System;
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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
              string.IsNullOrWhiteSpace(textBox2.Text) ||
              string.IsNullOrWhiteSpace(textBox5.Text) ||
              string.IsNullOrWhiteSpace(textBox6.Text) ||
              string.IsNullOrWhiteSpace(radioButton1.Text) ||
              string.IsNullOrWhiteSpace(radioButton3.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without further processing
            }

            string selectedValue = "";

            if (radioButton1.Checked)
            {
                selectedValue = radioButton1.Text; // or any value you want to assign
            }
            else if (radioButton3.Checked)
            {
                selectedValue = radioButton3.Text;
            }
            else
            {
                MessageBox.Show("All fields are required. Please fill in role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            string name = textBox1.Text;
            int age = Convert.ToInt32(textBox2.Text);
            string role = selectedValue.ToLower();
            string userName = textBox5.Text;
            string password = textBox6.Text;


            if (role == "organizer")
            {
                Person person = new Organizer(name, age, role, userName, password);
                person.Register(person, this);


            }
            else if (role == "participant")
            {
                Person person = new Participant(name, age, role, userName, password);
                person.Register(person, this);

            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
