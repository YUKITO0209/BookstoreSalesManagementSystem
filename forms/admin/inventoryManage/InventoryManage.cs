using BookstoreSalesManagementSystem.forms.admin.inventoryManage;
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
    public partial class InventoryManage : Form
    {
        public InventoryManage()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InventoryManage_Load(object sender, EventArgs e)
        {
            Table();
        }

        // 从数据库读取数据显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            Dao dao = new Dao();
            string sql = "SELECT * FROM Table_BookInfo";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
            }
            dc.Close();
            dao.DaoClose();
        }

        // 查找书籍按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Check();
        }

        public void Check()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql;

            if (textBox1.Text == "" && textBox2.Text == "")
            {
                sql = $"SELECT * FROM Table_BookInfo";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE ISBN号 LIKE '%" + textBox1.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text == "" && textBox2.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE 书名 LIKE '%" + textBox2.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE ISBN号 LIKE '%" + textBox1.Text + "%' AND 书名 LIKE '%" + textBox2.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
        }

        // 清除按钮
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        // 添加书籍按钮
        private void button3_Click(object sender, EventArgs e)
        {
            IM_Add ima = new IM_Add();
            ima.ShowDialog();
            Table();
        }

        // 修改书籍按钮
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string publisher = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string price = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string inventory = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                IM_Edit ime = new IM_Edit(isbn, name, author, publisher, price, inventory);
                ime.ShowDialog();
                Table();
            }
            catch
            {
                MessageBox.Show("请先选中要修改的书籍记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 删除书籍按钮
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); // 表中选中行对应的ISBN号转换为字符串格式
                DialogResult dr = MessageBox.Show("是否删除此条书籍记录?", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    Dao dao = new Dao();
                    string sql = $"DELETE FROM Table_BookInfo WHERE ISBN号 = '" + isbn + "'";
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    dao.DaoClose();
                }
            }
            catch
            {
                MessageBox.Show("请先选中要删除的书籍记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 返回按钮
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}