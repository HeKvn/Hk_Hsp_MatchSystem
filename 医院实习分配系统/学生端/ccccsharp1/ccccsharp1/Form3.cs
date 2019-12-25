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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Model.Users m_user = new Model.Users();
            m_user.name = textBox1.Text;
            m_user.tel = textBox2.Text;
            BLL.Class1 b_user1 = new BLL.Class1();
            bool result1 = b_user1.select1(m_user);
            if (result1)
            {
                if (textBox3.Text == "123")
                {
                    Form4 f4 = new Form4();
                    f4.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("验证码错误");
                }

            }
            else
            {
                MessageBox.Show("账号密码错误");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == String.Empty || textBox2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("请输入正确的账号或手机号");
            }
            else
            {
                MessageBox.Show("验证码发送成功");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }
    }
}
