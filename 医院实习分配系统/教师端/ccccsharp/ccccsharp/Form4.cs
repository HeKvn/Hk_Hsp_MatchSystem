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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        //返回上级操作
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        //权限管理页面打开
        private void button6_Click(object sender, EventArgs e)
        {
            getText gt = new getText();
            string a = "hk";
            Model.Users1 m_user1 = new Model.Users1();
            m_user1.name = a;
            Console.WriteLine(a);
            BLL.Class1 b_user2 = new BLL.Class1();
            bool result2 = b_user2.select2(m_user1);
            if (result2)
            {
                Form5 f5 = new Form5();
                f5.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("你没有权限");
            }
            
        }

        //学生信息
        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();
        }

        //结果查询
        private void button2_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
            this.Close();
        }

        //医院查询
        private void button3_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            this.Close();
        }

        //分配及时间设置
        private void button4_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
            this.Close();
        }
    }
}
