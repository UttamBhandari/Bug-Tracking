﻿using Bug_Tracker.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker.Views
{
    public partial class AdminRegister : Form
    {
        public AdminRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string companyName = txtCompanyName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Bug_Tracker.Model.ProjectAdmin admin = new Bug_Tracker.Model.ProjectAdmin
            {
                Organization = companyName,
                Username = username,
                Password = password
            };

            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Fill up the form properly");
            } else
            {
                try
                {
                    ProjectAdminDAO adminDAO = new ProjectAdminDAO();
                    adminDAO.Insert(admin);

                    MessageBox.Show("Account created");
                    this.Hide();
                    new AdminLogin().Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void AdminRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
