using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreSalesManagementSystem.forms.admin.inventoryManage
{
    public partial class IM_Edit : Form
    {
        string ISBN = "";
        public IM_Edit()
        {
            InitializeComponent();
        }

        public IM_Edit(string isbn, string name, string author, string publisher, string price, string inventory)
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            this.StartPosition = FormStartPosition.CenterScreen;
            ISBN = textBox1.Text = isbn;
            textBox2.Text = name;
            textBox3.Text = author;
            textBox4.Text = publisher;
            textBox5.Text = price;
            textBox6.Text = inventory;
        }

        // 修改按钮
        private void button1_Click_1(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql = $"UPDATE Table_BookInfo SET ISBN号 = '" + textBox1.Text + "', 书名 = '" + textBox2.Text + "', 作者 = '" + textBox3.Text + 
                "', 出版社 = '" + textBox4.Text + "', 价格 = '" + decimal.Parse(textBox5.Text) + "', 库存 = '" + int.Parse(textBox6.Text) + "' WHERE ISBN号 = '" + ISBN + "'";
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
