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
    public partial class Settlement : Form
    {
        static string time;
        public static bool flag = false;
        public Settlement()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label2.Text = ShoppingCart.sp;
            label6.Text = ShoppingCart.salesNumber;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        // 已付款按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = $"USE BSMS " +
                        $"INSERT INTO Table_Record VALUES('{ShoppingCart.salesNumber}', '{Login.username}', {decimal.Parse(label2.Text)}, '{time}')";
            int n = dao.Execute(sql);
            if (n > 0)
            {
                MessageBox.Show("订单完成，请凭订单号联系工作人员取货！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("验证订单失败，请重试！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dao.DaoClose();
        }


        // 返回按钮
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否取消订单？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
