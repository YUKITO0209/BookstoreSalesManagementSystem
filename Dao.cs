using System.Data.SqlClient;

namespace BookstoreSalesManagementSystem
{
    internal class Dao
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string str = @"Data Source=DESKTOP-NTF0E3T;Initial Catalog=BSMS;Integrated Security=True"; // 数据库链接
            sc = new SqlConnection(str); // 创建数据库链接对象
            sc.Open(); // 打开数据库
            return sc;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql) // 更新操作，返回被更新的数据所在行数
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql) // 读取
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sc.Close();
        }
    }
}
