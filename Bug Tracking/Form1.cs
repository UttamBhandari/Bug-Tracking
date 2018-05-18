using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Bug_Tracking
{
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=Bug_tracking;User Id=root;password='';SslMode = none");
        int i;
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBConnection();
        }
        private void DBConnection()
        {
            string ConnectString = "datasource = localhost; username = root; password=; database = Bug_Tracking; SslMode = none";
            MySqlConnection DBConnect = new MySqlConnection(ConnectString);
            try
            {
                DBConnect.Open();
                MessageBox.Show("OK You are connected");
            }catch(Exception e){
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from user where username='"+nametxtbox.Text+"' and password='"+pwdtxtbox.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                label4.Text = "Invalid username or password..";
            }
            else
            {
                this.Hide();
                addbug fm = new addbug();
                fm.Show();
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminlogin adfm = new adminlogin();
            adfm.Show();
        }
    }
}
