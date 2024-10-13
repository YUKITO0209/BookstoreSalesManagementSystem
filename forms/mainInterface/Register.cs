using BookstoreSalesManagementSystem.forms.mainInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreSalesManagementSystem.forms
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            radioButton1.BackColor = Color.Transparent;
            radioButton2.BackColor = Color.Transparent;
            radioButton3.BackColor = Color.Transparent;
            radioButton4.BackColor = Color.Transparent;
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            checkBox1.BackColor = Color.Transparent;
            checkBox2.BackColor = Color.Transparent;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // 注册按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && (radioButton1.Checked == true || radioButton2.Checked == true) && (radioButton3.Checked == true || radioButton4.Checked == true))
            {
                if (textBox3.Text == textBox4.Text)
                {
                    try
                    {
                        if (radioButton1.Checked == true) // 判断性别
                        {
                            if (radioButton3.Checked == true) // 判断权限
                            {
                                Identify identify = new Identify();
                                identify.ShowDialog();
                                if (Identify.flag == true)
                                {
                                    Dao dao = new Dao();
                                    string sql = $"INSERT INTO Table_Login VALUES('" + textBox1.Text + "', '男', '" + textBox2.Text + "', '" + textBox3.Text + "', '管理员')";
                                    int flag = dao.Execute(sql);
                                    if (flag > 0)
                                    {
                                        MessageBox.Show("注册成功，即将返回登录界面！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("注册失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("验证码错误！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                Dao dao = new Dao();
                                string sql = $"INSERT INTO Table_Login VALUES('" + textBox1.Text + "', '男', '" + textBox2.Text + "', '" + textBox3.Text + "', '用户')";
                                int flag = dao.Execute(sql);
                                if (flag > 0)
                                {
                                    MessageBox.Show("注册成功，即将返回登录界面！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("注册失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            if (radioButton3.Checked == true)
                            {
                                Identify identify = new Identify();
                                identify.ShowDialog();
                                if (Identify.flag == true)
                                {
                                    Dao dao = new Dao();
                                    string sql = $"INSERT INTO Table_Login VALUES('" + textBox1.Text + "', '女', '" + textBox2.Text + "', '" + textBox3.Text + "', '管理员')";
                                    int flag = dao.Execute(sql);
                                    if (flag > 0)
                                    {
                                        MessageBox.Show("注册成功，即将返回登录界面！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("注册失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("验证码错误！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                Dao dao = new Dao();
                                string sql = $"INSERT INTO Table_Login VALUES('" + textBox1.Text + "', '女', '" + textBox2.Text + "', '" + textBox3.Text + "', '用户')";
                                int flag = dao.Execute(sql);
                                if (flag > 0)
                                {
                                    MessageBox.Show("注册成功，即将返回登录界面！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("注册失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("当前手机号已被注册，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("两次密码输入不一致，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
            else
            {
                MessageBox.Show("请输入完整注册信息！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 返回按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox3.PasswordChar = '•';
            }
            else
            {
                textBox3.PasswordChar = '\0';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                textBox4.PasswordChar = '•';
            }
            else
            {
                textBox4.PasswordChar = '\0';
            }
        }
    }
}
