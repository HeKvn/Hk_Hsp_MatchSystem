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

namespace ccccsharp1
{
    public partial class Form8 : Form
    {
        public string name;
        private String str1 = ConfigurationManager.AppSettings["MysqlUrl"];

        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(str1);
            try
            {
                con.Open();
                string sqlstr = ConfigurationManager.AppSettings["insert1"];
                MySqlCommand cmd = new MySqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@hpt1", textBox1.Text);
                cmd.Parameters.AddWithValue("@hpt2", textBox2.Text);
                cmd.Parameters.AddWithValue("@hpt3", textBox3.Text);
                cmd.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("填报成功");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.name = name;
            this.Close();
            f4.ShowDialog();
        }
    }
}
