using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ccccsharp
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            string stuid = textBox2.Text;
            if (stuid != "")
            {
                String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
                MySqlConnection con = new MySqlConnection(str1);
                try
                {
                    con.Open();
                    string strcmd = ConfigurationManager.AppSettings["select02"];
                    MySqlCommand cmd = new MySqlCommand(strcmd, con);
                    cmd.Parameters.AddWithValue("@stuid", stuid);
                    MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);
                    f8.dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            f8.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            MySqlConnection con = new MySqlConnection(str1);
            try
            {
                con.Open();
                string strcmd = ConfigurationManager.AppSettings["select03"];
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                f9.dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            f9.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();
        }
    }
}
