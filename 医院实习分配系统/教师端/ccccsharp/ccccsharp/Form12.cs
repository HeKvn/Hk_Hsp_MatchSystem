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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        string[] grade1 = new string[5];
        string[] grade2 = new string[5];
        string[] grade3 = new string[5];
        string[] name = new string[5];
        
        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            String str1 = ConfigurationManager.AppSettings["MysqlUrl2"];
            MySqlConnection con = new MySqlConnection(str1);
            try
            {
                con.Open();
                string strcmd = ConfigurationManager.AppSettings["select08"];
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

        string[] stu = new string[4] { "黄小微","邓超","迪丽热巴","杨幂"};

        private bool match()
        {
            
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            MySqlConnection con = new MySqlConnection(str1);
            for (int x =1; x < grade1.Length;x++)
            {
                string sql = ConfigurationManager.AppSettings["select09"];
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@x", x);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    grade1[x] = dr["grade1"].ToString();
                }
                con.Close();
            }

            for (int y = 1; y < grade1.Length; y++)
            {
                string sql = ConfigurationManager.AppSettings["select10"];
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@y", y);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    grade2[y] = dr["grade2"].ToString();
                }
                con.Close();
            }

            for (int z = 1; z < grade1.Length; z++)
            {
                string sql = ConfigurationManager.AppSettings["select11"];
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@z", z);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    grade3[z] = dr["grade3"].ToString();
                }
                con.Close();
            }

            for (int i = 1; i < name.Length; i++)
            {
                string sql = ConfigurationManager.AppSettings["select12"];
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    name[i] = dr["name"].ToString();
                }
                con.Close();
            }

            string[] total = new string[4] { 
                Convert.ToString(Convert.ToInt16(grade1[1]) + Convert.ToInt16(grade2[1]) + Convert.ToInt16(grade3[1])),
                Convert.ToString(Convert.ToInt16(grade1[2]) + Convert.ToInt16(grade2[2]) + Convert.ToInt16(grade3[2])),
                Convert.ToString(Convert.ToInt16(grade1[3]) + Convert.ToInt16(grade2[3]) + Convert.ToInt16(grade3[3])),
                Convert.ToString(Convert.ToInt16(grade1[4]) + Convert.ToInt16(grade2[4]) + Convert.ToInt16(grade3[4]))};

            for (int a = 0; a < stu.Length; a++)
            {
                string sql = ConfigurationManager.AppSettings["insert4"];
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", stu[a]);
                cmd.Parameters.AddWithValue("@total", total[a]);
                cmd.ExecuteNonQuery();
                con.Close();
            }


            MessageBox.Show("已按成绩筛选成功");
            return true;
        }  //匹配算法

        private void button1_Click(object sender, EventArgs e)
        {
            match();
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            MySqlConnection con = new MySqlConnection(str1);
            try
            {
                con.Open();
                string strcmd = ConfigurationManager.AppSettings["select13"];
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
    }
}
