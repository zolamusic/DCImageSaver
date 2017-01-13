using System;

namespace DCUtils
{
    public class Comment
    {
        public string Gallery { get; set; }
        public int No { get; set; }
        public string Memo { get; set; }
        public string Userid { get; set; }
        public string Username { get; set; }
        public DateTime Time { get; set; }
        public string Ip { get; set; }

        public Comment(string gallery, int no, string memo, string userid, string username, DateTime time, string ip)
        {
            Gallery = gallery;
            No = no;
            Memo = memo;
            Userid = userid;
            Username = username;
            Time = time;
            Ip = ip;
        }
    }
}
