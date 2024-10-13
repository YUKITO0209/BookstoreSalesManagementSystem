using BookstoreSalesManagementSystem.forms;
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
    public partial class Functions : Form
    {
        public Functions()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // 书籍查询按钮
        private void button1_Click(object sender, EventArgs e)
        {
            BookInfoCheck bic = new BookInfoCheck();
            this.Hide();
            bic.ShowDialog();
            this.Show();
        }

        // 销售管理按钮
        private void button2_Click(object sender, EventArgs e)
        {
            SalesManage sm = new SalesManage();
            this.Hide();
            sm.ShowDialog();
            this.Show();
        }

        // 库存管理按钮
        private void button3_Click(object sender, EventArgs e)
        {
            InventoryManage im = new InventoryManage();
            this.Hide();
            im.ShowDialog();
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