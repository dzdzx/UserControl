using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace WinDataTest
{
    public class User:INotifyPropertyChanged
    {
        private String userName=null;
        private String userPWD=null;
        private int age=0;
        private String phone=null;
        private int value = 0;

        public User() { }

        public User(String uName,String uPWD,int age,String phone,int uValue) {
            this.userName = uName;
            this.userPWD = uPWD;
            this.age = age;
            this.phone = phone;
            this.value = uValue;
        }

        public String UserName
        {
            get { return this.userName; }
            set
            { this.userName=value;
                OnPropertyChange(new PropertyChangedEventArgs("UserName"));
            }
        }

        public String UserPWD
        {
            get { return this.userPWD; }
            set { this.userPWD = value;
                OnPropertyChange(new PropertyChangedEventArgs("UserPWD"));
            }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value;
                OnPropertyChange(new PropertyChangedEventArgs("Age"));
            }
        }

        public String Phone
        {
            get { return this.phone; }
            set { this.phone = value;
                OnPropertyChange(new PropertyChangedEventArgs("Phone"));
            }
        }
        public int Value {
            get { return this.value; }
            set
            {
                this.value = value;
                OnPropertyChange(new PropertyChangedEventArgs("Value"));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropertyChange(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this,e);
            }
        }

    }
}
