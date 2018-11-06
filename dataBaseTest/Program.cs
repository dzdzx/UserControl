using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace dataBaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //常规的数据库操作
            DataBaseDao.getConnect();
            String sqlString = "select * from tb_user";
            MySqlCommand sqlCommand = new MySqlCommand(sqlString,DataBaseDao.conn);
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            List<User> UserList = new List<User>();
            while (reader.Read()) {
                User u = new User();
                u.UserName = reader.GetString("userName");
                u.UserPWD = reader.GetString("userPWD");
                u.Age = reader.GetInt32("age");
                u.Phone = reader.GetString("phone");
                UserList.Add(u);
            }
            DataBaseDao.closeCon();
            foreach (User uu in UserList) {
                System.Console.WriteLine("username:"+uu.UserName+"\t"+"userAge:"+uu.Age);
            }

            //ADO.net方式的数据库操作
            MySqlDataAdapter da = new MySqlDataAdapter(sqlString,DataBaseDao.conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "tb_user");
            foreach (DataRow row in ds.Tables["tb_user"].Rows) {
                foreach (DataColumn dc in ds.Tables["tb_user"].Columns) {
                    System.Console.WriteLine("{0} Current = {1}",dc.ColumnName,row[dc,DataRowVersion.Current]);
                    System.Console.WriteLine("Default = {0}", row[dc, DataRowVersion.Default]);
                    System.Console.WriteLine("Original = {0}", row[dc, DataRowVersion.Original]);
                }
            }

            System.Console.ReadLine();
        }
    }
}
