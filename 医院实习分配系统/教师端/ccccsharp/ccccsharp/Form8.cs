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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
