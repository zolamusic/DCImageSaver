namespace DCUtils
{
    public class Picture
    {
        public string GallName { get; set; }
        public int ArticleNo { get; set; }
        public int Nth { get; set; }
        public string FileName { get; set; }
        public string Sha256 { get; set; }

        public Picture(string gallName, int articleNo, int nth, string fileName, string sha256)
        {
            GallName = gallName;
            ArticleNo = articleNo;
            Nth = nth;
            FileName = fileName;
            Sha256 = sha256;
        }
    }
}
