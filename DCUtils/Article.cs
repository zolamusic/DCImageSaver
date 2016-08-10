using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCUtils
{
    public class Article
    {
        private string _gallname;
        private int _no;
        private string _info;
        private string _subject;
        private int _comments;
        private string _userid;
        private string _username;
        private DateTime _date;
        private int _hits;
        private int _recomm;

        public string Gallname
        {
            get
            {
                return _gallname;
            }

            set
            {
                _gallname = value;
            }
        }

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

        public string Info
        {
            get
            {
                return _info;
            }

            set
            {
                _info = value;
            }
        }

        public string Subject
        {
            get
            {
                return _subject;
            }

            set
            {
                _subject = value;
            }
        }

        public int Comments
        {
            get
            {
                return _comments;
            }

            set
            {
                _comments = value;
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

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public int Hits
        {
            get
            {
                return _hits;
            }

            set
            {
                _hits = value;
            }
        }

        public int Recomm
        {
            get
            {
                return _recomm;
            }

            set
            {
                _recomm = value;
            }
        }
        
        public Article(string _gallname, int _no, string _info, string _subject, int _comments, string _userid, string _username, DateTime _date, int _hits, int _recomm)
        {
            this.Gallname = _gallname;
            this.No = _no;
            this.Info = _info;
            this.Subject = _subject;
            this.Comments = _comments;
            this.Userid = _userid;
            this.Username = _username;
            this.Date = _date;
            this.Hits = _hits;
            this.Recomm = _recomm;
        }
    }
}
