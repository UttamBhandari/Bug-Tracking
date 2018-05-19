using Bug_Tracker.DAO;
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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminRegister().Show();
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cann't be null");
            } else
            {
                ProjectAdminDAO adminDAO = new ProjectAdminDAO();
                int id = adminDAO.IsLogin(username, password);

                if (id>0)
                {
                    Program.adminId = id;
                    new ManageMain().Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("Either username or password is wrong");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserLogin().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AdminRegister().Show();
        }
    }
}
