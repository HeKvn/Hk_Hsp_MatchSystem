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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private DataSet ds = new DataSet();
        private MySqlConnection conn = null;
        private MySqlDataAdapter da = null;
        private String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
        private String select = ConfigurationManager.AppSettings["select05"];

        private void Form10_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(str1);
            da = new MySqlDataAdapter(select, conn);
            da.Fill(ds, "table");
            this.dataGridView1.DataSource = ds.Tables["table"].DefaultView;
        }

        private bool BtnUpdate()
        {
            MySqlParameter sp = new MySqlParameter();

            da.UpdateCommand = conn.CreateCommand();
            string strcmd = ConfigurationManager.AppSettings["update2"];
            da.UpdateCommand.CommandText = strcmd;
            da.UpdateCommand.Parameters.Add("@name", MySqlDbType.VarChar, 255, "name");
            da.UpdateCommand.Parameters.Add("@tel", MySqlDbType.VarChar, 255, "tel");
            da.UpdateCommand.Parameters.Add("@area", MySqlDbType.VarChar, 255, "area");
            sp = da.UpdateCommand.Parameters.Add("@hid", MySqlDbType.Int16, 16, "hid");
            sp.SourceVersion = DataRowVersion.Original;
            int count = da.Update(ds);
            bool result = count > 0 ? true : false;
            return result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("您没有权限");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text;
            conn = new MySqlConnection(str1);
            if (name != "")
            {
                conn.Open();
                try
                {
                    string strcmd = ConfigurationManager.AppSettings["select06"];
                    MySqlCommand cmd = new MySqlCommand(strcmd, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form13 f13 = new Form13();
            String id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            f13.hpid = id;
            f13.Show();
            this.Close();
        }
    }
}
