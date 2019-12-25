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
    public partial class Form9 : Form
    {
        public string name;

        public Form9()
        {
            InitializeComponent();
        }

        private DataSet ds = new DataSet();
        private MySqlConnection conn = null;
        private MySqlDataAdapter da = null;
        private String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
        private String select = ConfigurationManager.AppSettings["select05"];

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.name = name;
            this.Close();
            f4.ShowDialog();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(str1);
            da = new MySqlDataAdapter(select, conn);
            da.Fill(ds, "table");
            this.dataGridView1.DataSource = ds.Tables["table"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
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
            Form10 f10 = new Form10();
            String id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            f10.hpid = id;
            f10.name = name;
            this.Close();
            f10.Show();
        }
    }
}
