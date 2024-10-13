using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreSalesManagementSystem.forms.user
{
    public partial class UserFunc : Form
    {
        public UserFunc()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // 书籍信息查询按钮
        private void button1_Click(object sender, EventArgs e)
        {
            BookInfoCheck bic = new BookInfoCheck();
            this.Hide();
            bic.ShowDialog();
            this.Show();
        }

        // 书籍购买按钮
        private void button2_Click(object sender, EventArgs e)
        {
            Purchase pur = new Purchase();
            this.Hide();
            pur.ShowDialog();
            this.Show();
        }

        // 购物车按钮
        private void button3_Click(object sender, EventArgs e)
        {
            ShoppingCart sc = new ShoppingCart();
            this.Hide();
            sc.ShowDialog();
            this.Show();
        }

        // 退出按钮
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否返回登录界面？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
