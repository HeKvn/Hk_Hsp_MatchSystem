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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private DataSet ds = new DataSet();
        private MySqlConnection conn = null;
        private MySqlDataAdapter da = null;
        private String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
        private String select = ConfigurationManager.AppSettings["select03"];

        private void Form9_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(str1);
            da = new MySqlDataAdapter(select, conn);
            da.Fill(ds, "table");
            this.dataGridView1.DataSource = ds.Tables["table"].DefaultView;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private bool BtnUpdate()
        {
            MySqlParameter sp = new MySqlParameter();
            
            da.UpdateCommand = conn.CreateCommand();
            string strcmd = ConfigurationManager.AppSettings["update"];
            da.UpdateCommand.CommandText = strcmd;
            da.UpdateCommand.Parameters.Add("@name",MySqlDbType.VarChar,255,"name");
            da.UpdateCommand.Parameters.Add("@grade1", MySqlDbType.VarChar, 255, "grade1");
            da.UpdateCommand.Parameters.Add("@grade2", MySqlDbType.VarChar, 255, "grade2");
            da.UpdateCommand.Parameters.Add("@grade3", MySqlDbType.VarChar, 255, "grade3");
            sp = da.UpdateCommand.Parameters.Add("@stuid", MySqlDbType.VarChar, 255, "stuid");
            sp.SourceVersion = DataRowVersion.Original;
            int count = da.Update(ds);
            bool result = count > 0 ? true : false;
            return result;
        }

        private void button4_Click(object sender, EventArgs e)
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
    }
}
