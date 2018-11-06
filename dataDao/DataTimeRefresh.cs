using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dataDao
{
    public class TimeChangeEventArgs : EventArgs
    {
        public int hour;
        public int minute;
        public int second;
        public TimeChangeEventArgs(int h, int m, int s) {

            this.hour = h;
            this.minute = m;
            this.second = s;
        }
    }
    /**发布时间改变事件，并监控该事件**/
    public class DateTimeRefresh
    {
        public int hour;
        public int minuter;
        public int second;
        public delegate void TimeChange(object o, TimeChangeEventArgs ages);
        public event TimeChange OnSecondChange;

        public void run() {
            for (; ; ) {
                System.DateTime dt = System.DateTime.Now;
                if (dt.Second != this.second) {
                    TimeChangeEventArgs timeChangeEventArgs = new TimeChangeEventArgs(dt.Hour, dt.Minute, dt.Second);
                    if (OnSecondChange != null) {
                        OnSecondChange(this, timeChangeEventArgs);
                    }
                    this.hour = dt.Hour;
                    this.minuter = dt.Minute;
                    this.second = dt.Second;
                }
            }
        }

    }

    public class DateTimeSub {
        public virtual void TimeHasChange(object o, TimeChangeEventArgs ages) { }
        public void subOnSecondChange(DateTimeRefresh clock) {
            clock.OnSecondChange += new DateTimeRefresh.TimeChange(TimeHasChange);
        }

        public void TimeHasChange()
        {
            throw new NotImplementedException();
        }
    }
}
