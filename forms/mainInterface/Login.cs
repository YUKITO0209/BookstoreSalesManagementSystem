using BookstoreSalesManagementSystem.forms;
using BookstoreSalesManagementSystem.forms.user;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreSalesManagementSystem
{
    public partial class Login : Form
    {
        public static string username;
        public Login()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            checkBox1.BackColor = Color.Transparent;
            radioButton1.BackColor = Color.Transparent;
            radioButton2.BackColor = Color.Transparent;
            this.StartPosition = FormStartPosition.CenterScreen; // 窗体居中启动
            // 在程序启动时清空购物车内的残留数据
            Dao dao = new Dao();
            string sql = $"TRUNCATE TABLE Table_ShoppingCart";
            if (dao.Execute(sql) > 0)
            {
                dao.DaoClose();
            }
        }

        // 登录按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && (radioButton1.Checked == true || radioButton2.Checked == true))
            {
                string sql;
                Dao dao = new Dao();
                if (radioButton1.Checked == true)
                {
                    sql = $"SELECT * FROM Table_Login WHERE 手机号 = '" + textBox1.Text + "' AND 密码 = '" + textBox2.Text + "' AND 权限 = '管理员'";
                    IDataReader dc = dao.read(sql);
                    if (dc.Read())
                    {
                        Functions func = new Functions();
                        this.Hide();
                        func.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("用户名、密码或权限错误，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    dao.DaoClose();
                }
                else
                {
                    sql = $"SELECT * FROM Table_Login WHERE 手机号 = '" + textBox1.Text + "' AND 密码 = '" + textBox2.Text + "' AND 权限 = '用户'";
                    IDataReader dc = dao.read(sql);
                    if (dc.Read())
                    {
                        UserFunc ufunc = new UserFunc();
                        username = textBox1.Text;
                        this.Hide();
                        ufunc.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("用户名、密码或权限错误，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    dao.DaoClose();
                }
            }
            else
            {
                MessageBox.Show("用户名、密码和权限不能为空，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 注册按钮
        private void button2_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            this.Hide();
            reg.ShowDialog();
            this.Show();
        }

        // 显示密码选框
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox2.PasswordChar = '•';
            }
            else
            {
                textBox2.PasswordChar = '\0';
            }
        }

        // 退出按钮
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit(); // 退出程序
        }
    }
}