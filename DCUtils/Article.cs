using System;

namespace DCUtils
{
    public class Article
    {
        public string Gallname { get; set; }
        public int No { get; set; }
        public string Info { get; set; }
        public string Subject { get; set; }
        public int Comments { get; set; }
        public string Userid { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public int Hits { get; set; }
        public int Recomm { get; set; }

        public Article(string gallname, int no, string info, string subject, int comments, string userid, string username, DateTime date, int hits, int recomm)
        {
            Gallname = gallname;
            No = no;
            Info = info;
            Subject = subject;
            Comments = comments;
            Userid = userid;
            Username = username;
            Date = date;
            Hits = hits;
            Recomm = recomm;
        }
    }
}
