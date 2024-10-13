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
    public partial class RecordCheck : Form
    {
        public RecordCheck()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void RecordCheck_Load(object sender, EventArgs e)
        {
            Table();
        }

        // 从数据库读取数据显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            Dao dao = new Dao();
            string sql = $"SELECT * FROM Table_Record";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2], dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        // 查询按钮
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
                sql = $"SELECT * FROM Table_Record";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2], dc[3].ToString());
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                sql = $"SELECT * FROM Table_Record WHERE 订单号 LIKE '%" + textBox1.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2], dc[3].ToString());
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text == "" && textBox2.Text != "")
            {
                sql = $"SELECT * FROM Table_Record WHERE 交易人 LIKE '%" + textBox2.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2], dc[3].ToString());
                }
                dc.Close();
                dao.DaoClose();
            }
            else if (textBox1.Text != "" && textBox2.Text != "")
            {
                sql = $"SELECT * FROM Table_Record WHERE 订单号 LIKE '%" + textBox1.Text + "%' AND 交易人 LIKE '%" + textBox2.Text + "%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2], dc[3].ToString());
                }
                dc.Close();
                dao.DaoClose();
            }
        }

        // 返回按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
