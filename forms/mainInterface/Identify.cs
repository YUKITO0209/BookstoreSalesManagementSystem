using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreSalesManagementSystem.forms.mainInterface
{
    public partial class Identify : Form
    {
        public static bool flag = false;
        public Identify()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // 确定按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text == "123")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入管理员验证码！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 返回按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
