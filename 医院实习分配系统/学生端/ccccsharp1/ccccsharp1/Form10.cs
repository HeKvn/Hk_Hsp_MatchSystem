using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ccccsharp1
{
    public partial class Form10 : Form
    {
        public string hpid;
        public string name;

        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.name = name;
            this.Close();
            f9.Show();
        }

        private void ShowImage()
        {
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            string sql = ConfigurationManager.AppSettings["select07"];
            MySqlConnection con = new MySqlConnection(str1);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@hpid", hpid);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "hospital_image");
            int c = ds.Tables["hospital_image"].Rows.Count;
            if (c > 0)
            {
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])(ds.Tables["hospital_image"].Rows[c - 1]["image"]);
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                pictureBox1.BackgroundImage = Image.FromStream(stmBLOBData);
            }
        }


        private void Form10_Load(object sender, EventArgs e)
        {
            ShowImage();
        }

    }
}
