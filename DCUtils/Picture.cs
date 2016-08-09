using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCUtils
{
    public class Picture
    {
        private string _gallName;
        private int _articleNo;
        private int _nth;
        private string _fileName;
        private string _SHA256;

        public string GallName
        {
            get
            {
                return _gallName;
            }

            set
            {
                _gallName = value;
            }
        }

        public int ArticleNo
        {
            get
            {
                return _articleNo;
            }

            set
            {
                _articleNo = value;
            }
        }

        public int Nth
        {
            get
            {
                return _nth;
            }

            set
            {
                _nth = value;
            }
        }

        public string FileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                _fileName = value;
            }
        }

        public string SHA256
        {
            get
            {
                return _SHA256;
            }

            set
            {
                _SHA256 = value;
            }
        }

        public Picture(string _gallName, int _articleNo, int _nth, string _fileName, string _SHA256)
        {
            this.GallName = _gallName;
            this.ArticleNo = _articleNo;
            this.Nth = _nth;
            this.FileName = _fileName;
            this.SHA256 = _SHA256;
        }
    }
}
