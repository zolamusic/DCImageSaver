using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCUtils
{
    public class Comment
    {
        private int _no;
        private int _iNo;
        private string _memo;
        private string _userid;
        private string _username;
        private DateTime _time;
        private string _ip;

        public int No
        {
            get
            {
                return _no;
            }

            set
            {
                _no = value;
            }
        }

        public int INo
        {
            get
            {
                return _iNo;
            }

            set
            {
                _iNo = value;
            }
        }

        public string Memo
        {
            get
            {
                return _memo;
            }

            set
            {
                _memo = value;
            }
        }

        public string Userid
        {
            get
            {
                return _userid;
            }

            set
            {
                _userid = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return _time;
            }

            set
            {
                _time = value;
            }
        }

        public string Ip
        {
            get
            {
                return _ip;
            }

            set
            {
                _ip = value;
            }
        }

        public Comment(int _no, int _iNo, string _memo, string _userid, string _username, DateTime _time, string _ip)
        {
            this.No = _no;
            this.INo = _iNo;
            this.Memo = _memo;
            this.Userid = _userid;
            this.Username = _username;
            this.Time = _time;
            this.Ip = _ip;
        }
    }
}
