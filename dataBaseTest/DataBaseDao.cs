using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace dataBaseTest
{
    
    class DataBaseDao
    {
        public static MySqlConnection conn=null;
        const string connetStr = "server=127.0.0.1;port=3306;user=root;password=dzd123321;database=db_firsttest;";
        public static void getConnect() {
            conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();
                System.Console.WriteLine("链接成功");
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine("链接出错"+ex.Message);
                closeCon();
            }
        }
        public static void closeCon() {
            if (conn != null) {
                conn.Close();
            }
        }
    }
}
