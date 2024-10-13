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
    public partial class ShoppingCart : Form
    {
        public static string sp;
        public static string salesNumber;
        public ShoppingCart()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ShoppingCart_Load(object sender, EventArgs e)
        {
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            Dao dao = new Dao();
            string sql = $"SELECT Table_BookInfo.ISBN号, Table_BookInfo.书名, Table_BookInfo.作者, Table_BookInfo.出版社, Table_BookInfo.价格, Table_ShoppingCart.数量 " +
                $"FROM Table_BookInfo, Table_ShoppingCart " +
                $"WHERE Table_BookInfo.ISBN号 = Table_ShoppingCart.ISBN号";
            string sumPrice = $"SELECT SUM(价格 * 数量) FROM Table_BookInfo, Table_ShoppingCart WHERE Table_BookInfo.ISBN号 = Table_ShoppingCart.ISBN号";
            IDataReader dc1 = dao.read(sql);
            IDataReader dc2 = dao.read(sumPrice);
            while (dc1.Read())
            {
                dataGridView1.Rows.Add(dc1[0].ToString(), dc1[1].ToString(), dc1[2].ToString(), dc1[3].ToString(), dc1[4].ToString(), dc1[5].ToString());
            }
            while (dc2.Read())
            {
                label2.Text = dc2[0].ToString();
                sp = dc2[0].ToString();
            }
            dc1.Close();
            dc2.Close();
            dao.DaoClose();
        }

        // 结算按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (label2.Text == "")
            {
                MessageBox.Show("购物车为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                salesNumber = DateTime.Now.ToString("yyMMddHHmmss");
                Settlement set = new Settlement();
                set.ShowDialog();
                if (Settlement.flag == true)
                {
                    Dao dao = new Dao();
                    string sql = $"TRUNCATE TABLE Table_ShoppingCart";
                    if (dao.Execute(sql) > 0)
                    {
                        dao.DaoClose();
                    }
                }
            }
        }

        // 移出购物车按钮
        private void button2_Click(object sender, EventArgs e)
        {
            string isbn = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            Dao dao = new Dao();
            string sql = $"USE BSMS " +
                $"DELETE FROM Table_ShoppingCart WHERE ISBN号 = '{isbn}' " +
                $"UPDATE Table_BookInfo SET 库存 = 库存 + {number} WHERE ISBN号 = '{isbn}'" +
                $"UPDATE Table_BookInfo SET 销量 = 销量 - {number} WHERE ISBN号 = '{isbn}'";
            if (dao.Execute(sql) > 2)
            {
                MessageBox.Show("已成功移出购物车！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Table();
            }
        }

        // 返回按钮
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}