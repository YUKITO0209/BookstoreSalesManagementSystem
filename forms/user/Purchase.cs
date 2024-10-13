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
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            Dao dao = new Dao();
            string sql = $"SELECT * FROM Table_BookInfo";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Check();
        }

        // 查找书籍按钮
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
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
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
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
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
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
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
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
                }
                dc.Close();
                dao.DaoClose();
            }
        }

        // 加入购物车按钮
        private void button2_Click(object sender, EventArgs e)
        {
            string isbn = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int inventory = int.Parse(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            if (textBox3.Text != "" && textBox3.Text != "0")
            {
                try
                {
                    if (inventory < int.Parse(textBox3.Text))
                    {
                        MessageBox.Show("本书库存不足，暂无法购买，若确有需要请联系工作人员补货。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Dao dao = new Dao();
                        string sql = $"USE BSMS " +
                            $"INSERT INTO Table_ShoppingCart(ISBN号, 数量) VALUES('{isbn}', '{textBox3.Text}') " +
                            $"UPDATE Table_BookInfo SET 库存 = 库存 - {int.Parse(textBox3.Text)} WHERE ISBN号 = '{isbn}' " +
                            $"UPDATE Table_BookInfo SET 销量 = 销量 + {int.Parse(textBox3.Text)} WHERE ISBN号 = '{isbn}'";
                        if (dao.Execute(sql) > 2)
                        {
                            MessageBox.Show("已成功加入购物车！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Table();
                        }
                        else
                        {
                            MessageBox.Show("加入购物车失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch // 将同一本书分多次添加到购物车
                {
                    Dao dao = new Dao();
                    string sql = $"UPDATE Table_ShoppingCart SET 数量 = 数量 + {int.Parse(textBox3.Text)} WHERE ISBN号 = '{isbn}'";
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("已成功加入购物车！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("加入购物车失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("请正确输入购买数量！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 返回按钮
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
