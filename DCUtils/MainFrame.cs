using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp.Parser.Html;
using DCUtils.Properties;

namespace DCUtils
{
    public partial class MainFrame : Form
    {
        public List<KeyValuePair<string, string>> GalleryListOrg = new List<KeyValuePair<string, string>>();
        public BindingList<KeyValuePair<string, string>> GalleryList;
        public BindingList<KeyValuePair<string, string>> SelectedList = new BindingList<KeyValuePair<string, string>>();
        public BindingList<Article> ArticleList = new BindingList<Article>();
        public BindingList<Comment> CommentList = new BindingList<Comment>();
        public BindingList<Picture> PictureList = new BindingList<Picture>();
        public List<KeyValuePair<string, string>> Queries;

        public HashSet<string> SavedImageHash = new HashSet<string>();
        public HashSet<int> UpdateArticle = new HashSet<int>();

        public static int SavedArticle;
        public static int SavedImage;
        public static bool IsLogged;

        public static string SaveFolder = "";
        private bool _stopLoop;

        public MainFrame()
        {
            InitializeComponent();
            SetDataGrid();
            CrawlingGalleryList();
        }

        private void SetDataGrid()
        {
            data_article.DataSource = ArticleList;
            data_article.DoubleBuffered(true);
            data_article.VirtualMode = true;
            data_article.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            data_article.Columns[0].HeaderText = @"갤러리";
            data_article.Columns[1].HeaderText = @"글번호";
            data_article.Columns[2].HeaderText = @"종류";
            data_article.Columns[3].HeaderText = @"제목";
            data_article.Columns[4].HeaderText = @"댓글";
            data_article.Columns[5].HeaderText = @"고정닉";
            data_article.Columns[6].HeaderText = @"글쓴이";
            data_article.Columns[7].HeaderText = @"날짜";
            data_article.Columns[8].HeaderText = @"조회";
            data_article.Columns[9].HeaderText = @"추천";
            data_article.Columns[0].Width = 110;
            data_article.Columns[1].Width = 70;
            data_article.Columns[2].Width = 60;
            data_article.Columns[3].Width = 356;
            data_article.Columns[4].Width = 60;
            data_article.Columns[5].Width = 100;
            data_article.Columns[6].Width = 110;
            data_article.Columns[7].Width = 130;
            data_article.Columns[8].Width = 60;
            data_article.Columns[9].Width = 60;
            
            data_picture.DataSource = PictureList;
            data_picture.DoubleBuffered(true);
            data_picture.VirtualMode = true;
            data_picture.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            data_picture.Columns[0].HeaderText = @"갤러리";
            data_picture.Columns[1].HeaderText = @"글번호";
            data_picture.Columns[2].HeaderText = @"짤";
            data_picture.Columns[3].HeaderText = @"파일명";
            data_picture.Columns[4].HeaderText = @"SHA256";
            data_picture.Columns[0].Width = 110;
            data_picture.Columns[1].Width = 70;
            data_picture.Columns[2].Width = 30;
            data_picture.Columns[3].Width = 300;
            data_picture.Columns[4].Width = 411;
            data_picture.Columns[4].DefaultCellStyle.Font = new Font("Consolas", 8F, FontStyle.Regular);
        }

        public async void CrawlingGalleryList()
        {
            var parser = new HtmlParser();
            var mainConn = new Connection("http://m.dcinside.com/category_gall_total.html", "http://m.dcinside.com/", true);
            var mainResp = await mainConn.Get();
            var mainHtml = parser.Parse(mainResp.Contents);
            var list = mainHtml.GetElementsByClassName("gc_list_left");

            foreach (var link in list)
            {
                var url = link.QuerySelector("a").GetAttribute("href").Replace("http://m.dcinside.com/list.php?id=", "");
                var gallname = link.TextContent.Trim();
                GalleryListOrg.Add(new KeyValuePair<string, string>(gallname, url));
            }

            GalleryListOrg.Sort((x, y) => string.Compare(x.Key, y.Key, StringComparison.Ordinal));
            GalleryList = new BindingList<KeyValuePair<string, string>>(GalleryListOrg);
            
            list_galleryList.DisplayMember = "Key";
            list_galleryList.ValueMember = "Value";
            list_galleryList.DataSource = GalleryList;

            list_selected.DisplayMember = "Key";
            list_selected.ValueMember = "Value";
            list_selected.DataSource = SelectedList;

            if (SelectedList.Count == 0) btn_refresh.Enabled = false;
            await Task.Delay(1000);
        }

        private static string GetChecksum(string file)
        {
            using (var stream = File.OpenRead(file))
            {
                var sha = new SHA256Managed();
                var checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", string.Empty);
            }
        }

        private async Task<bool> Login()
        {
            var loginConn = new Connection(
                "http://m.dcinside.com/login.php",
                "http://gall.dcinside.com",
                true
            );
            var tokenConn = new Connection(
                "http://m.dcinside.com/_access_token.php",
                "http://m.dcinside.com/login.php",
                true
            );
            var assignConn = new Connection(
                "https://dcid.dcinside.com/join/mobile_login_ok.php",
                "http://m.dcinside.com/login.php?r_url=%2Findex.php",
                true
            );
            
            var cookieNum = 0;
            while (cookieNum != 4)
            {
                var loginResp = await loginConn.Get();
                var loginHtml = loginResp.Contents;

                var conKey = loginHtml.Split(new[] { "con_key\" value=\"" }, StringSplitOptions.None)[1].Split(new[] { "\" />" }, StringSplitOptions.None)[0];

                Queries = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("token_verify", "login"),
                    new KeyValuePair<string, string>("con_key", conKey)
                };
                var tokenResp = await tokenConn.Post(Queries);
                var tokenHtml = tokenResp.Contents;
                conKey = tokenHtml.Split(new[] { "data\":\"" }, StringSplitOptions.None)[1].Split(new[] { "\"}" }, StringSplitOptions.None)[0];

                Queries = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("user_id", text_userid.Text),
                    new KeyValuePair<string, string>("user_pw", text_passwd.Text),
                    new KeyValuePair<string, string>("id_chk", "on"),
                    new KeyValuePair<string, string>("mode", ""),
                    new KeyValuePair<string, string>("con_key", conKey)
                };
                var loginCookies = await assignConn.SetCookie(Queries);
                cookieNum = loginCookies.Count;
            }

            text_logger.AppendText(@"로그인 성공.");
            btn_login.Enabled = false;
            text_userid.Enabled = false;
            text_passwd.Enabled = false;
            IsLogged = true;

            return true;
        }

        private async Task<bool> PreChekingDupeFiles(string gallery)
        {
            try
            {
                if (!Directory.Exists($"{SaveFolder}/{gallery}"))
                    Directory.CreateDirectory($"{SaveFolder}/{gallery}");
                if (!Directory.Exists($"{SaveFolder}/{gallery}/temp"))
                    Directory.CreateDirectory($"{SaveFolder}/{gallery}/temp");

                var files = Directory.GetFiles($"{SaveFolder}/{gallery}", "*.*");
                foreach (var file in files)
                {
                    var task = Task.Run(() => GetChecksum(file));
                    var fileHash = await task;
                    if (!SavedImageHash.Add(fileHash)) continue;
                    var picture = new Picture("PreSaved", 0, 0, file.Replace($"{SaveFolder}/{gallery}\\", ""), fileHash);
                    PictureList.Insert(0, picture);
                }
            }
            catch (Exception ex)
            {
                text_logger.AppendText($"{ex}\r\n");
            }
            return true;
        }

        private async Task<bool> ParsingImages(string gallery, int no)
        {
            var parser = new HtmlParser();
            var artiConn = new Connection(
                $"http://gall.dcinside.com/board/view/?id={gallery}&no={no}",
                $"http://gall.dcinside.com/board/lists/?id={gallery}",
                false
            );

            try
            {
                var artiResp = await artiConn.Get();
                var artiHtml = parser.Parse(artiResp.Contents);

                var imageListContainer = artiHtml.GetElementsByClassName("appending_file");
                var infos = imageListContainer.First().QuerySelectorAll("li");

                var nth = 1;
                foreach (var item in infos)
                {
                    if (_stopLoop) break;
                    var pLink = item.QuerySelectorAll("a").First().GetAttribute("href");
                    var pName = item.TextContent;

                    var name = WebUtility.HtmlDecode(pName);
                    var link = WebUtility.HtmlDecode(pLink.Replace("image.dcinside.com/download", "dcimg2.dcinside.com/viewimage"));

                    var fileName = $"{gallery}_{no}_{name}";
                    var tempPath = $"{SaveFolder}/{gallery}/temp/{fileName}";
                    var filePath = $"{SaveFolder}/{gallery}/{fileName}";

                    var webClient = new WebClient();
                    await webClient.DownloadFileTaskAsync(new Uri(link), tempPath);

                    var fileHash = GetChecksum(tempPath);
                    if (SavedImageHash.Add(fileHash))
                    {
                        var picture = new Picture(gallery, no, nth, fileName, fileHash);
                        PictureList.Insert(0, picture);
                        File.Copy(tempPath, filePath);
                        File.Delete(tempPath);
                        SavedImage++;
                        label_savedImage.Text = SavedImage.ToString();
                    }
                    else
                    {
                        File.Delete(tempPath);
                    }
                    nth++;
                }
            }
            catch
            {
                text_logger.AppendText($"{gallery}/{no}: Image Download\r\n");
            }
            return true;
        }

        private async Task<bool> ParsingPage(string gallery)
        {
            var parser = new HtmlParser();
            var pageConn = new Connection(
                $"http://gall.dcinside.com/board/lists/?id={gallery}&page={1}",
                "http://gall.dcinside.com",
                false
            );

            try
            {
                var pageResp = await pageConn.Get();
                var pageHtml = parser.Parse(pageResp.Contents);

                var tables = pageHtml.GetElementsByClassName("list_tbody");
                var infos = tables.First().QuerySelectorAll("tr");

                foreach (var items in infos)
                {
                    var tNotice = items.GetElementsByClassName("t_notice")[0].InnerHtml;
                    var tNode = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a").Count();
                    var tSubject = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a")[0].TextContent;
                    var tInfo = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a")[0].GetAttribute("class");
                    var tComment = "0";
                    if (tNode > 1)
                        tComment = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a")[1].TextContent.Replace("[", "").Replace("]", "");
                    var tUserid = items.GetElementsByClassName("t_writer")[0].GetAttribute("user_id");
                    var tUsername = items.GetElementsByClassName("t_writer")[0].GetAttribute("user_name");
                    var tDate = items.GetElementsByClassName("t_date")[0].GetAttribute("title");
                    var tHits = items.GetElementsByClassName("t_hits")[0].TextContent;
                    var tRecomm = items.GetElementsByClassName("t_hits")[1].TextContent;

                    if (tNotice.Equals("공지")) continue;

                    var notice = Convert.ToInt32(tNotice);
                    var info = tInfo;
                    var subject = WebUtility.HtmlDecode(tSubject);
                    var comment = Convert.ToInt32(tComment.Split('/')[0]);
                    var userid = WebUtility.HtmlDecode(tUserid);
                    var username = WebUtility.HtmlDecode(tUsername);
                    var date = Convert.ToDateTime(tDate);
                    var hits = Convert.ToInt32(tHits);
                    var recomm = Convert.ToInt32(tRecomm);

                    if (_stopLoop || !info.Contains("pic") || !UpdateArticle.Add(notice)) continue;
                    
                    ArticleList.Insert(0, new Article(gallery, notice, info, subject, comment, userid, username, date, hits, recomm));
                    SavedArticle++;
                    label_savedArticle.Text = SavedArticle.ToString();
                    await ParsingImages(gallery, notice);
                }
            }
            catch (Exception ex)
            {
                text_logger.AppendText($"{ex}\r\n");
            }
            
            return true;
        }
        
        private async Task<bool> IsAdult(string gallery)
        {
            var isAdultGallery = false;
            
            var gallConn = new Connection(
                $"http://gall.dcinside.com/board/lists/?id={gallery}",
                "http://gall.dcinside.com",
                false
            );

            try
            {
                var gallResp = await gallConn.Get();
                var gallHtml = gallResp.Contents;
                
                if (gallHtml.Contains("error/adult")) { isAdultGallery = true; }
            }
            catch (Exception ex)
            {
                text_logger.AppendText($"{ex}\r\n");
            }

            return isAdultGallery;
        }

        private async void GoGetSomePics(string gallery)
        {
            await PreChekingDupeFiles(gallery);

            while (!_stopLoop)
            {
                await ParsingPage(gallery);
                await Task.Delay(5000);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            DisablingButtons();
            var isSelected = false;
            while (isSelected == false && SaveFolder.Equals(""))
            {
                isSelected = CheckImageDownload();
            }

            foreach (var item in SelectedList)
            {
                GoGetSomePics(item.Value);
            }
        }

        private bool CheckImageDownload()
        {
            var isSelected = false;
            try
            {
                var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    SaveFolder = fbd.SelectedPath;
                    isSelected = true;
                }
            }
            catch (Exception ex)
            {
                text_logger.AppendText($"{ex}\r\n");
            }

            return isSelected;
        }
        
        private void data_picture_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (data_picture.SelectedCells.Count <= 0) return;
            var selectedrowindex = data_picture.SelectedCells[0].RowIndex;
            var selectedRow = data_picture.Rows[selectedrowindex];
            string imgPath = $@"{SaveFolder}\\{selectedRow.Cells[3].Value}";
            //Process.Start(imgPath);
        }

        private void DisablingButtons()
        {
            btn_stop.Enabled = true;
            _stopLoop = false;

            ArticleList.Clear();
            CommentList.Clear();
            UpdateArticle.Clear();
            PictureList.Clear();
            SavedImageHash.Clear();
            SavedArticle = 0;
            SavedImage = 0;

            list_selected.Enabled = false;
            list_galleryList.Enabled = false;

            button1.Enabled = false;
            button2.Enabled = false;
            
            btn_refresh.Enabled = false;
        }

        private void EnablingButtons()
        {
            btn_stop.Enabled = false;
            _stopLoop = true;

            list_selected.Enabled = true;
            list_galleryList.Enabled = true;

            button1.Enabled = true;
            button2.Enabled = true;

            btn_refresh.Enabled = true;
        }
        
        private void btn_stop_Click(object sender, EventArgs e)
        {
            EnablingButtons();
        }

        private void check_username_CheckedChanged(object sender, EventArgs e)
        {
            search_username.Enabled = check_username.Checked;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (GalleryList.Count <= 0) return;
            var koName = GalleryList.ElementAt(list_galleryList.SelectedIndex).Key;
            var enName = GalleryList.ElementAt(list_galleryList.SelectedIndex).Value;
            if(await IsAdult(enName))
            {
                if (IsLogged)
                {
                    SelectedList.Add(new KeyValuePair<string, string>(koName, enName));
                    GalleryList.Remove(new KeyValuePair<string, string>(koName, enName));
                    btn_refresh.Enabled = true;
                }
                else
                {
                    MessageBox.Show(Resources.MainFrame_button1_Click_);
                }
            }
            else
            {
                SelectedList.Add(new KeyValuePair<string, string>(koName, enName));
                GalleryList.Remove(new KeyValuePair<string, string>(koName, enName));
                btn_refresh.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ( SelectedList.Count > 0)
            {
                var koName = SelectedList.ElementAt(list_selected.SelectedIndex).Key;
                var enName = SelectedList.ElementAt(list_selected.SelectedIndex).Value;

                GalleryList.Insert(0, new KeyValuePair<string, string>(koName, enName));
                SelectedList.Remove(new KeyValuePair<string, string>(koName, enName));
            }
            if (SelectedList.Count == 0) btn_refresh.Enabled = false;
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            await Login();
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            var dgvType = dgv.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
            pi.SetValue(dgv, setting, null);
        }
    }
}
