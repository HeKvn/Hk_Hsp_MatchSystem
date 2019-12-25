using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ccccsharp1
{
    public partial class Form6 : Form
    {
        public string name;

        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.textBox1.Text = name;
            this.Close();
            f5.Show();
        }
    }
}
