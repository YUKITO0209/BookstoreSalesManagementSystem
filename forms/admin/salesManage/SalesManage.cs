using BookstoreSalesManagementSystem.forms.admin.salesManage;
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
    public partial class SalesManage : Form
    {
        public SalesManage()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SalesManage_Load(object sender, EventArgs e)
        {
            Table();
        }

        // 从数据库读取数据显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            Dao dao = new Dao();
            string sql = $"SELECT * FROM Table_BookInfo ORDER BY 销量 DESC";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[6], dc[7]);
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
                sql = $"SELECT * FROM Table_BookInfo ORDER BY 销量 DESC";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[6], dc[7]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE ISBN号 LIKE '%" + textBox1.Text + "%' ORDER BY 销量 DESC";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[6], dc[7]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text == "" && textBox2.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE 书名 LIKE '%" + textBox2.Text + "%' ORDER BY 销量 DESC";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[6], dc[7]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE ISBN号 LIKE '%" + textBox1.Text + "%' AND 书名 LIKE '%" + textBox2.Text + "%' ORDER BY 销量 DESC";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[6], dc[7]);
                }
                dc.Close();
                dao.DaoClose();
            }
        }

        // 编辑销量按钮
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string sales = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                SalesEdit se = new SalesEdit(isbn, sales);
                se.ShowDialog();
                Table();
            }
            catch
            {
                MessageBox.Show("请先选中要修改的书籍记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 订单查询按钮
        private void button3_Click(object sender, EventArgs e)
        {
            RecordCheck rc = new RecordCheck();
            rc.ShowDialog();
        }

        // 返回按钮
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
