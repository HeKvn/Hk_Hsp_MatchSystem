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
    public partial class Form6 : Form
    {
        public static string cb;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            MySqlConnection con = new MySqlConnection(str1);
            try
            {
                con.Open();
                string strcmd = ConfigurationManager.AppSettings["select01"];
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            MySqlConnection con = new MySqlConnection(str1);
            try
            {
                string cb;
                if (comboBox1.Text == "年级")
                {
                    cb = "grade";
                    con.Open();
                    string strcmd = "select * from students group by @combobox1";
                    MySqlCommand cmd = new MySqlCommand(strcmd, con);
                    cmd.Parameters.AddWithValue("@combobox1", cb);
                    MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form7 f7 = new Form7();
            String id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (id != "")
            {
                String sql = "select stuid,majory from students where name=@id";
                String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
                MySqlConnection con = new MySqlConnection(str1);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    f7.textBox2.Text = dr["stuid"].ToString();
                    f7.textBox3.Text = dr["majory"].ToString();
                    f7.textBox1.Text = id;
                }
                con.Close();
            }
            
            f7.Show();
        }
    }
}
