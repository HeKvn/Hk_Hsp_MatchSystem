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
    public partial class Form7 : Form
    {

        public string name;
        private DataSet ds = new DataSet();
        private MySqlConnection conn = null;
        private MySqlDataAdapter da = null;
        private String str1 = ConfigurationManager.AppSettings["MysqlUrl"];

        public Form7()
        {
            InitializeComponent();
        }

        private bool BtnUpdate()
        {
            string strcmd = ConfigurationManager.AppSettings["update"];
            MySqlParameter sp = new MySqlParameter();
            string pwd = textBox1.Text;
            da.UpdateCommand = conn.CreateCommand();
            da.UpdateCommand.CommandText = strcmd;
            //da.UpdateCommand.Parameters.Add("@pwd", MySqlDbType.VarChar, 255, "pwd");
            da.UpdateCommand.Parameters.AddWithValue("@pwd",pwd);
            //sp = da.UpdateCommand.Parameters.Add("@name", MySqlDbType.VarChar, 255, "name");
            sp = da.UpdateCommand.Parameters.AddWithValue("@name",name);
            sp.SourceVersion = DataRowVersion.Original;
            int count = da.Update(ds);
            bool result = count > 0 ? true : false;
            return result;
        }    //密码修改

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.BtnUpdate())
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.textBox1.Text = name;
            this.Close();
            f5.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string select = ConfigurationManager.AppSettings["select03"];
            conn = new MySqlConnection(str1);
            da = new MySqlDataAdapter(select, conn);
            da.Fill(ds, "table");
        }
    }
}
