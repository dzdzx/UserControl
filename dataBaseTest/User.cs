using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataBaseTest
{
    class User
    {
        private String userName=null;
        private String userPWD=null;
        private int age=0;
        private String phone=null;

        public String UserName
        {
            get { return this.userName; }
            set
            { this.userName=value; }
        }

        public String UserPWD
        {
            get { return this.userPWD; }
            set { this.userPWD = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public String Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

    }
}
