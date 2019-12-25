using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ccccsharp
{
    public partial class Form2 : Form
    {
 
        public Form2()
        {
            InitializeComponent();
        }

        //构造方法获取id
        public string getText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        //登录操作
        private void button1_Click(object sender, EventArgs e)
        {
            Model.Users m_user = new Model.Users();
            m_user.name = textBox1.Text;
            m_user.pwd = textBox2.Text;
            BLL.Class1 b_user = new BLL.Class1();
            bool result = b_user.select(m_user);
            if (result)
            {
                Form4 f4 = new Form4();
                f4.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("账号密码错误");
            }
            getText gt = new getText();
            gt.get(textBox1.Text);
        }

        //手机登录
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }


        //返回一级窗体
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}
