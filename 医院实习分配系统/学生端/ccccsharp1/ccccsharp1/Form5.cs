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
using System.IO;

namespace ccccsharp1
{
    public partial class Form5 : Form
    {

        public Form5()
        {
            InitializeComponent();
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            MySqlConnection con = new MySqlConnection(str1);
            string sql = ConfigurationManager.AppSettings["select01"];
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["stuID"].ToString();
                textBox3.Text = dr["majory"].ToString();
                textBox4.Text = dr["tel"].ToString();
            }
            con.Close();
            ShowImage();
        }

        private void ShowImage()
        {
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            string sql = ConfigurationManager.AppSettings["select01"];
            MySqlConnection con = new MySqlConnection(str1);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "stu_imformation");
            int c = ds.Tables["stu_imformation"].Rows.Count;
            if (c > 0)
            {
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])(ds.Tables["stu_imformation"].Rows[c - 1]["image"]);
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                pictureBox1.BackgroundImage = Image.FromStream(stmBLOBData);
            }
            //byte[] b = (byte[])cmd.ExecuteScalar();
            //if (b.Length > 0)
            //{
                //MemoryStream stream = new MemoryStream(b, true);
                //stream.Write(b, 0, b.Length);
                //pictureBox1.BackgroundImage = new Bitmap(stream);
                //stream.Close();
            //}
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.name = textBox1.Text;
            this.Close();
            f4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            string name = textBox1.Text;
            if (name != "")
            {
                String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
                MySqlConnection con = new MySqlConnection(str1);
                try
                {
                    con.Open();
                    string strcmd = ConfigurationManager.AppSettings["select02"];
                    MySqlCommand cmd = new MySqlCommand(strcmd, con);
                    cmd.Parameters.AddWithValue("@name", name);
                    MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);
                    f6.dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            f6.name = textBox1.Text;
            this.Close();
            f6.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.name = textBox1.Text;
            this.Close();
            f7.ShowDialog();
        }
    }
}
