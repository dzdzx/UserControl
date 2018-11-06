using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using dataDao;
using MySql.Data.MySqlClient;
using System.Threading;

namespace WinDataTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user=null;
        
        public MainWindow()
        {
            InitializeComponent();
           
            user = selectByName("lisi");
            userInformation.DataContext = user;
            DateTimeRefresh dateTimeRefresh = new DateTimeRefresh();
            Thread t = new Thread(dateTimeRefresh.run);
            t.Start();
            dateTimeRefresh.OnSecondChange += new DateTimeRefresh.TimeChange(TimeHasChange);

        }


        public void TimeHasChange(object o, TimeChangeEventArgs ages) {
            
            User uu = selectByName("lisi");
            if (uu!=null) { 
                user.Phone = uu.Phone;
                user.Age = uu.Age;
                user.UserName = uu.UserName;
                user.UserPWD = uu.UserPWD;
                user.Value = uu.Value;
            }
        }

        public User selectByName(String uName) {
            DataBaseDao.getConnect();
            User user=null;
            String sqlQuare = "select * from tb_user where userName=@para1";
            MySqlCommand sqlCommand = new MySqlCommand(sqlQuare,DataBaseDao.conn);
            MySqlDataReader reader = null;
            try
            {
                sqlCommand.Parameters.AddWithValue("para1", "lisi");
                reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    user= new User(reader.GetString("userName"), reader.GetString("userPWD"), reader.GetInt32("age"), reader.GetString("phone"),reader.GetInt32("value"));
                }
                
            }
            catch (MySqlException ex)
            {
                if (reader != null) {
                    reader.Close();
                }
                //记录日志
            }
            finally {
                if (reader != null)
                {
                    reader.Close();
                }
                DataBaseDao.closeCon();
            }
            return user;
        }

    }
}
