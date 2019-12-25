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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
        

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            string name;
            MySqlConnection con = new MySqlConnection(str1);
            if (comboBox1.Text == "一级管理员权限")
            {
                try
                {
                    name = textBox1.Text;
                    con.Open();
                    string sqlstr = ConfigurationManager.AppSettings["insert1"] ;
                    MySqlCommand cmd = new MySqlCommand(sqlstr, con);
                    cmd.Parameters.AddWithValue("@name", name);
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
                MessageBox.Show("授权成功");
            }

            if (comboBox1.Text == "二级分配及时间设置权限")
            {
                try
                {
                    name = textBox1.Text;
                    con.Open();
                    string sqlstr = ConfigurationManager.AppSettings["insert2"];
                    MySqlCommand cmd = new MySqlCommand(sqlstr, con);
                    cmd.Parameters.AddWithValue("@name", name);
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
                MessageBox.Show("授权成功");
            }

            if (comboBox1.Text == "三级导出表权限")
            {
                try
                {
                    name = textBox1.Text;
                    con.Open();
                    string sqlstr = ConfigurationManager.AppSettings["insert3"];
                    MySqlCommand cmd = new MySqlCommand(sqlstr, con);
                    cmd.Parameters.AddWithValue("@name", name);
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
                MessageBox.Show("授权成功");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }
    }
}
