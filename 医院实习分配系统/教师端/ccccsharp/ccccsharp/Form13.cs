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

namespace ccccsharp
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        public string hpid;

        private void Form13_Load(object sender, EventArgs e)
        {
            ShowImage();
        }

        private void ShowImage()
        {
            String str1 = ConfigurationManager.AppSettings["MysqlUrl"];
            string sql = ConfigurationManager.AppSettings["select07"];
            MySqlConnection con = new MySqlConnection(str1);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@hpid", hpid);
            con.Open();
            byte[] b = (byte[])cmd.ExecuteScalar();
            if (b.Length > 0)
            {
                MemoryStream stream = new MemoryStream(b, true);
                stream.Write(b, 0, b.Length);
                pictureBox1.BackgroundImage = new Bitmap(stream);
                stream.Close();
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

    }
}
