using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Bug_Tracking
{
    public partial class formmain : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=Bug_tracking;User Id=root;password='';SslMode = none");
        MySqlCommand command;
        public formmain()
        {
            InitializeComponent();
            populate();
        }
       

        

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adduser adu = new adduser();
            adu.Show();
        }

       private void Formmain(Object sender,EventArgs e)
        {
            populate();

        }
        public void populate()
        {
            //populate the datagrid
            string selectQuery = "select * from user";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con);
            adapter.Fill(table);
            dataGridView_user.DataSource = table;
        }

        private void dataGridView_user_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = dataGridView_user.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView_user.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView_user.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView_user.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView_user.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView_user.CurrentRow.Cells[5].Value.ToString();
        }

        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void executeMyQuery(string query)
        {
            try
            {
                openConnection();
                command = new MySqlCommand(query, con);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query Executed");
                }
                else
                {
                    MessageBox.Show("Query not Executed");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                closeConnection();
            }
        }
        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void createuser_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO user(full_name, address, contact_number, username, password, user_type) VALUES('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'," + radioButton1.Checked+ ")";
            executeMyQuery(insertQuery);
            populate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE user full_name='"+textBox1.Text+ "',address='"+textBox2.Text+ "',contact_number='" + textBox3.Text + "',username='" + textBox4.Text + "',password='" + textBox5.Text +" WHERE user_id="+int.Parse(textBoxID.Text);
            executeMyQuery(updateQuery);
            populate();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM user WHERE user_id="+int.Parse(textBoxID.Text);
            executeMyQuery(deleteQuery);
            populate();
        }
    }
    }

