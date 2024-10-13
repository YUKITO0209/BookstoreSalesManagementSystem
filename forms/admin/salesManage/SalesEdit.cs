using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreSalesManagementSystem.forms.admin.salesManage
{
    public partial class SalesEdit : Form
    {
        string ISBN = "";
        public SalesEdit()
        {
            InitializeComponent();
        }

        public SalesEdit(string isbn, string sales)
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            this.StartPosition = FormStartPosition.CenterScreen;
            ISBN = isbn;
            textBox1.Text = sales;
        }

        // 确定按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql = $"UPDATE Table_BookInfo SET 销量 = '{textBox1.Text}' WHERE ISBN号 = '{int.Parse(ISBN)}'";
            if (textBox1.Text != "")
            {
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("修改后的记录不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 返回按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
