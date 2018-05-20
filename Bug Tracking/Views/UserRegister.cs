using Bug_Tracker.DAO;
using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker.Views
{
    public partial class UserRegister : Form
    {
        public UserRegister()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            radioButton1.Checked = true;
            txtPassword.PasswordChar = '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtFullName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (name == "" || username == "" || password == "")
            {
                MessageBox.Show("Please fill up the form properly");
            }
            else
            {
                if (radioButton1.Checked)
                {
                    Programmer p = new Programmer { ProgrammerId = 0, FullName = name, Username = username, Password = password };
                    try
                    {
                        new ProgrammerDAO().Insert(p);
                        MessageBox.Show("Account created");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Tester p = new Tester { TesterId = 0, Full_name = name, Username = username, Password = password };
                    try
                    {
                        new TesterDAO().Insert(p);
                        MessageBox.Show("Account created");
                    }
                    catch (SqlException ex)
                    {

                        if (ex.Number == 2627)
                        {
                            MessageBox.Show("Username already exists");
                        }

                        MessageBox.Show(ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
