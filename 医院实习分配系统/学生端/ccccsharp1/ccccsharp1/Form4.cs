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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public string name;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.textBox1.Text = name;
            this.Close();
            f5.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.name = name;
            this.Close();
            f8.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.name = name;
            this.Close();
            f9.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.name = name;
            this.Close();
            f11.Show();
        }
    }
}
