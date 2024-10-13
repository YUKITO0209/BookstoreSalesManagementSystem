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
    public partial class BookInfoCheck : Form
    {
        public BookInfoCheck()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // 表头居中
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BookInfoCheck_Load(object sender, EventArgs e)
        {
            Table();
        }

        // 从数据库读取数据显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            Dao dao = new Dao();
            string sql = $"SELECT * FROM Table_BookInfo";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
            }
            dc.Close();
            dao.DaoClose();
        }

        // 查询按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Check();
        }

        // 查询方法
        public void Check()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql;

            // 16种不同的查询方式
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
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
            else if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
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
            else if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text == "" && textBox4.Text == "")
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
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "" && textBox4.Text == "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE 作者 LIKE '%" + textBox3.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE 出版社 LIKE '%" + textBox4.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text == "" && textBox4.Text == "")
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
            else if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text != "" && textBox4.Text == "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE ISBN号 LIKE '%" + textBox1.Text + "%' AND 作者 LIKE '%" + textBox3.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE ISBN号 LIKE '%" + textBox1.Text + "%' AND 出版社 LIKE '%" + textBox4.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text == "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE 书名 LIKE '%" + textBox2.Text + "%' AND 作者 LIKE '%" + textBox3.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text == "" && textBox4.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE 书名 LIKE '%" + textBox2.Text + "%' AND 出版社 LIKE '%" + textBox4.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "" && textBox4.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE 作者 LIKE '%" + textBox3.Text + "%' AND 出版社 LIKE '%" + textBox4.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text == "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE ISBN号 LIKE '%" + textBox1.Text + "%' AND 书名 LIKE '%" + textBox2.Text + "%' AND 作者 LIKE '%" + textBox3.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text == "" && textBox4.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE ISBN号 LIKE '%" + textBox1.Text + "%' AND 书名 LIKE '%" + textBox2.Text + "%' AND 出版社 LIKE '%" + textBox4.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text != "" && textBox4.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE ISBN号 LIKE '%" + textBox1.Text + "%' AND 作者 LIKE '%" + textBox3.Text + "%' AND 出版社 LIKE '%" + textBox4.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE 书名 LIKE '%" + textBox2.Text + "%' AND 作者 LIKE '%" + textBox3.Text + "%' AND 出版社 LIKE '%" + textBox4.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4], dc[5]);
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                sql = $"SELECT * FROM Table_BookInfo WHERE ISBN号 LIKE '%" + textBox1.Text + "%' AND 书名 LIKE '%" + textBox2.Text + "%' AND 作者 LIKE '%" + textBox3.Text + "%' AND 出版社 LIKE '%" + textBox4.Text + "%'";
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
            textBox3.Text = "";
            textBox4.Text = "";
        }

        // 返回按钮
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}