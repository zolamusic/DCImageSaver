using AngleSharp.Dom.Html;
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

namespace DCUtils
{
    public partial class MainFrame : Form
    {
        public List<KeyValuePair<string, string>> galleryList_org = new List<KeyValuePair<string, string>>();
        public BindingList<KeyValuePair<string, string>> galleryList;
        public BindingList<KeyValuePair<string, string>> selectedList = new BindingList<KeyValuePair<string, string>>();
        public BindingList<Article> articleList = new BindingList<Article>();
        public BindingList<Comment> commentList = new BindingList<Comment>();
        public BindingList<Picture> pictureList = new BindingList<Picture>();

        public HashSet<string> savedImageHash = new HashSet<string>();
        public HashSet<int> updateArticle = new HashSet<int>();

        public static int savedArticle = 0;
        public static int savedImage = 0;

        public static string saveFolder = "";
        private bool _stopLoop = false;

        public MainFrame()
        {
            InitializeComponent();
            SetDataGrid();
            CrawlingGalleryList();
        }

        private void SetDataGrid()
        {
            data_article.DataSource = articleList;
            data_article.DoubleBuffered(true);
            data_article.VirtualMode = true;
            data_article.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            data_article.Columns[0].HeaderText = "갤러리";
            data_article.Columns[1].HeaderText = "글번호";
            data_article.Columns[2].HeaderText = "종류";
            data_article.Columns[3].HeaderText = "제목";
            data_article.Columns[4].HeaderText = "댓글";
            data_article.Columns[5].HeaderText = "고정닉";
            data_article.Columns[6].HeaderText = "글쓴이";
            data_article.Columns[7].HeaderText = "날짜";
            data_article.Columns[8].HeaderText = "조회";
            data_article.Columns[9].HeaderText = "추천";
            data_article.Columns[0].Width = 120;
            data_article.Columns[1].Width = 70;
            data_article.Columns[2].Width = 0;
            data_article.Columns[3].Width = 356;
            data_article.Columns[4].Width = 0;
            data_article.Columns[5].Width = 100;
            data_article.Columns[6].Width = 110;
            data_article.Columns[7].Width = 130;
            data_article.Columns[8].Width = 0;
            data_article.Columns[9].Width = 0;
            
            data_picture.DataSource = pictureList;
            data_picture.DoubleBuffered(true);
            data_picture.VirtualMode = true;
            data_picture.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            data_picture.Columns[0].HeaderText = "갤러리";
            data_picture.Columns[1].HeaderText = "글번호";
            data_picture.Columns[2].HeaderText = "Index";
            data_picture.Columns[3].HeaderText = "파일명";
            data_picture.Columns[4].HeaderText = "SHA256";
            data_picture.Columns[0].Width = 120;
            data_picture.Columns[1].Width = 70;
            data_picture.Columns[2].Width = 0;
            data_picture.Columns[3].Width = 300;
            data_picture.Columns[4].Width = 411;
            data_picture.Columns[4].DefaultCellStyle.Font = new Font("Consolas", 8F, FontStyle.Regular);
        }

        public async void CrawlingGalleryList()
        {
            Connection main = new Connection("http://m.dcinside.com/category_gall_total.html", "http://m.dcinside.com/", true);

            IHtmlDocument a = await main.ConnectHtml();

            var list = a.GetElementsByClassName("gc_list_left");
            foreach (var link in list)
            {
                var url = link.QuerySelector("a").GetAttribute("href").Replace("http://m.dcinside.com/list.php?id=", "");
                var gallname = link.TextContent.Trim();
                galleryList_org.Add(new KeyValuePair<string, string>(gallname, url));
            }
            galleryList_org.Sort((x, y) => x.Key.CompareTo(y.Key));

            galleryList = new BindingList<KeyValuePair<string, string>>(galleryList_org);
            
            list_galleryList.DisplayMember = "Key";
            list_galleryList.ValueMember = "Value";
            list_galleryList.DataSource = galleryList;

            list_selected.DisplayMember = "Key";
            list_selected.ValueMember = "Value";
            list_selected.DataSource = selectedList;

            if (selectedList.Count == 0) btn_refresh.Enabled = false;
            await Task.Delay(1000);
        }

        private string GetChecksum(string file)
        {

            using (FileStream stream = File.OpenRead(file))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }

        private async Task<bool> PreChekingDupeFiles(string gallery)
        {
            try
            {
                if (!Directory.Exists(String.Format("{0}/{1}", saveFolder, gallery)))
                {
                    Directory.CreateDirectory(String.Format("{0}/{1}", saveFolder, gallery));
                }

                string[] files = Directory.GetFiles(String.Format("{0}/{1}", saveFolder, gallery), "*.*");
                foreach (var file in files)
                {
                    var task = Task.Run(() => GetChecksum(file));
                    var fileHash = await task;
                    if (savedImageHash.Add(fileHash))
                    {
                        Picture picture = new Picture("PreSaved", 0, 0, file.Replace(String.Format("{0}\\", String.Format("{0}/{1}", saveFolder, gallery)), ""), fileHash);
                        pictureList.Insert(0, picture);
                    }
                }
            }
            catch (Exception ex)
            {
                text_logger.AppendText(String.Format("{0}\r\n", ex.ToString()));
            }

            return true;
        }

        private async Task<bool> parsingImages(string gallery, int no)
        {
            Connection singleArticle;

            singleArticle = new Connection(
                    String.Format("http://gall.dcinside.com/board/view/?id={0}&no={1}", gallery, no),
                    String.Format("http://gall.dcinside.com/board/lists/?id={0}", gallery),
                    false
                );

            try
            {
                var htmlContents = await singleArticle.ConnectHtml();

                var imageListContainer = htmlContents.GetElementsByClassName("appending_file");
                var infos = imageListContainer.First().QuerySelectorAll("li");

                int nth = 1;
                foreach (var item in infos)
                {
                    if (!_stopLoop) break;
                    var p_link = item.QuerySelectorAll("a").First().GetAttribute("href");
                    var p_name = item.TextContent;

                    string name = WebUtility.HtmlDecode(p_name);
                    string link = WebUtility.HtmlDecode(p_link.Replace("image.dcinside.com/download", "dcimg2.dcinside.com/viewimage"));

                    string fileName = String.Format("{0}_{1}_{2}", gallery, no, name);
                    string filePath = String.Format("{0}/{1}/{2}", saveFolder, gallery, fileName);

                    WebClient webClient = new WebClient();
                    await webClient.DownloadFileTaskAsync(new Uri(link), filePath);

                    string fileHash = GetChecksum(filePath);
                    if (savedImageHash.Add(fileHash))
                    {
                        Picture picture = new Picture(gallery, no, nth, fileName, fileHash);
                        pictureList.Insert(0, picture);
                        savedImage++;
                        label_savedImage.Text = savedImage.ToString();
                    }
                    else
                    {
                        File.Delete(filePath);
                    }
                    nth++;
                }
            }
            catch (Exception ex)
            {
                text_logger.AppendText(String.Format("{0}\r\n", ex.ToString()));
            }
            return true;
        }

        private async Task<bool> parsingFirstPage(string gallery)
        {
            bool isFinished = false;
            Connection galleryPage;

            galleryPage = new Connection(
                    String.Format("http://gall.dcinside.com/board/lists/?id={0}&page={1}", gallery, 1),
                    "http://gall.dcinside.com",
                    false
                );

            try
            {
                var htmlContents = await galleryPage.ConnectHtml();

                var tables = htmlContents.GetElementsByClassName("list_thead");
                var infos = tables.First().QuerySelectorAll("tr.tb");

                foreach (var items in infos)
                {
                    var t_notice = items.GetElementsByClassName("t_notice")[0].InnerHtml;
                    int t_node = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a").Count();
                    var t_subject = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a")[0].TextContent;
                    var t_info = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a")[0].GetAttribute("class");
                    var t_comment = "0";
                    if (t_node > 1)
                        t_comment = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a")[1].TextContent.Replace("[", "").Replace("]", "");
                    var t_userid = items.GetElementsByClassName("t_writer")[0].GetAttribute("user_id");
                    var t_username = items.GetElementsByClassName("t_writer")[0].GetAttribute("user_name");
                    var t_date = items.GetElementsByClassName("t_date")[0].GetAttribute("title");
                    var t_hits = items.GetElementsByClassName("t_hits")[0].TextContent;
                    var t_recomm = items.GetElementsByClassName("t_hits")[1].TextContent;

                    if (t_notice.Equals("공지")) continue;

                    int notice = Convert.ToInt32(t_notice);
                    string info = t_info;
                    string subject = WebUtility.HtmlDecode(t_subject);
                    int comment = Convert.ToInt32(t_comment.Split('/')[0]);
                    string userid = WebUtility.HtmlDecode(t_userid);
                    string username = WebUtility.HtmlDecode(t_username);
                    DateTime date = Convert.ToDateTime(t_date);
                    int hits = Convert.ToInt32(t_hits);
                    int recomm = Convert.ToInt32(t_recomm);
                    string ip = "";
                    /*
                    if (!check_subject.Checked &&
                        !check_userid.Checked &&
                        !check_username.Checked)
                    {

                    }
                    else
                    {
                        if (check_and.Checked)
                        {
                            if (check_subject.Checked && !subject.Contains(search_subject.Text)) continue;
                            if (check_userid.Checked && !userid.Contains(search_userid.Text)) continue;
                            if (check_username.Checked && !username.Contains(search_username.Text)) continue;
                        }
                        else
                        {
                            int searchValue = 0;
                            if (check_subject.Checked && subject.Contains(search_subject.Text)) searchValue++;
                            if (check_userid.Checked && userid.Contains(search_userid.Text)) searchValue++;
                            if (check_username.Checked && username.Contains(search_username.Text)) searchValue++;
                            if (searchValue == 0) continue;
                        }
                    }
                    */
                    if (!_stopLoop && info.Contains("pic") && updateArticle.Add(notice))
                    {
                        Article article = new Article(gallery, notice, info, subject, comment, userid, username, date, hits, recomm);
                        articleList.Insert(0, article);
                        savedArticle++;
                        label_savedArticle.Text = savedArticle.ToString();
                        await parsingImages(gallery, notice);
                    }
                }
            }
            catch (Exception ex)
            {
                text_logger.AppendText(String.Format("{0}\r\n", ex.ToString()));
            }

            isFinished = true;
            return isFinished;
        }

        /*
        private async Task<string> parsingArticle(int no)
        {
            Connection articlePage;
            string ip = "";
            articlePage = new Connection(
                    String.Format("http://gall.dcinside.com/board/view/?id={0}&no={1}", gallname, no),
                    "http://gall.dcinside.com",
                    false
                );
            try
            {
                var htmlContents = await articlePage.ConnectHtml();
                ip = htmlContents.GetElementsByClassName("li_ip")[0].TextContent;
            }
            catch
            {

            }
            return ip;
        }
        */

        /*
        private async Task<bool> parsingComment(int no, int commpage)
        {
            bool isFinished = false;
            Connection commentPage;

            commentPage = new Connection(
                String.Format("http://m.dcinside.com/comment_more_new.php?id={0}&no={1}", gallname, no),
                String.Format("http://m.dcinside.com/list.php?id={0}", gallname),
                false
            );

            try
            {
                var htmlContents = await commentPage.ConnectHtml();

                var infos = htmlContents.GetElementsByClassName("inner_best");

                foreach (var items in infos)
                {
                    var c_userid = "";
                    var c_iNo = "0";
                    int c_node = items.GetElementsByClassName("nick_comm").Count();
                    if (c_node == 1)
                        c_userid = items.GetElementsByClassName("id")[0].GetAttribute("href").Replace("http://m.dcinside.com/gallog/home.php?g_id=", "");
                    var c_username = items.GetElementsByClassName("id")[0].TextContent.Replace("[", "").Replace("]", "");
                    var c_memo = items.GetElementsByClassName("txt")[0].TextContent;
                    var c_date = items.GetElementsByClassName("date")[0].TextContent;
                    var c_ip = items.GetElementsByClassName("ip")[0].TextContent;
                    int c_node_del = items.GetElementsByClassName("btn_delete").Count();
                    if (c_node_del > 0)
                        c_iNo = items.GetElementsByClassName("btn_delete")[0].GetAttribute("href").Split('\'')[1].Split('\'')[0];

                    int iNo = Convert.ToInt32(c_iNo);
                    string memo = WebUtility.HtmlDecode(c_memo);
                    string userid = WebUtility.HtmlDecode(c_userid);
                    string username = WebUtility.HtmlDecode(c_username);
                    DateTime date = Convert.ToDateTime(c_date);
                    string ip = c_ip;

                    if (check_and.Checked)
                    {
                        //if (!memo.Contains(search_memo.Text)) continue;
                        if (check_userid.Checked && !userid.Contains(search_userid.Text)) continue;
                        if (check_username.Checked && !username.Contains(search_username.Text)) continue;
                    }
                    else
                    {
                        int searchValue = 0;
                        //if (memo.Contains(search_subject.Text)) searchValue++;
                        if (check_userid.Checked && userid.Contains(search_userid.Text)) searchValue++;
                        if (check_username.Checked && username.Contains(search_username.Text)) searchValue++;
                        if (searchValue == 0) continue;
                    }

                    Comment comment = new Comment(no, iNo, memo, userid, username, date, ip);
                    commentList.Add(comment);
                }
            }
            catch
            {

            }
            
            isFinished = true;
            return isFinished;
        }
        */

        /*
        private async Task<bool> parsingList(int page)
        {
            bool isFinished = false;
            Connection galleryPage;

            galleryPage = new Connection(
                    String.Format("http://gall.dcinside.com/board/lists/?id={0}&page={1}", gallname, page),
                    "http://gall.dcinside.com",
                    false
                );

            try
            {
                var htmlContents = await galleryPage.ConnectHtml();

                var tables = htmlContents.GetElementsByClassName("list_thead");
                var infos = tables.First().QuerySelectorAll("tr.tb");

                foreach (var items in infos)
                {
                    var t_notice = items.GetElementsByClassName("t_notice")[0].InnerHtml;
                    int t_node = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a").Count();
                    var t_subject = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a")[0].TextContent;
                    var t_info = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a")[0].GetAttribute("class");
                    var t_comment = "0";
                    if (t_node > 1)
                        t_comment = items.GetElementsByClassName("t_subject")[0].QuerySelectorAll("a")[1].TextContent.Replace("[", "").Replace("]", "");
                    var t_userid = items.GetElementsByClassName("t_writer")[0].GetAttribute("user_id");
                    var t_username = items.GetElementsByClassName("t_writer")[0].GetAttribute("user_name");
                    var t_date = items.GetElementsByClassName("t_date")[0].GetAttribute("title");
                    var t_hits = items.GetElementsByClassName("t_hits")[0].TextContent;
                    var t_recomm = items.GetElementsByClassName("t_hits")[1].TextContent;

                    if (t_notice.Equals("공지")) continue;

                    int notice = Convert.ToInt32(t_notice);
                    string info = t_info;
                    string subject = WebUtility.HtmlDecode(t_subject);
                    int comment = Convert.ToInt32(t_comment.Split('/')[0]);
                    string userid = WebUtility.HtmlDecode(t_userid);
                    string username = WebUtility.HtmlDecode(t_username);
                    DateTime date = Convert.ToDateTime(t_date);
                    int hits = Convert.ToInt32(t_hits);
                    int recomm = Convert.ToInt32(t_recomm);
                    string ip = "";

                    if (!check_subject.Checked &&
                        !check_userid.Checked &&
                        !check_username.Checked)
                    {

                    }
                    else
                    {
                        if (check_and.Checked)
                        {
                            if (check_subject.Checked && !subject.Contains(search_subject.Text)) continue;
                            if (check_userid.Checked && !userid.Contains(search_userid.Text)) continue;
                            if (check_username.Checked && !username.Contains(search_username.Text)) continue;
                        }
                        else
                        {
                            int searchValue = 0;
                            if (check_subject.Checked && subject.Contains(search_subject.Text)) searchValue++;
                            if (check_userid.Checked && userid.Contains(search_userid.Text)) searchValue++;
                            if (check_username.Checked && username.Contains(search_username.Text)) searchValue++;
                            if (searchValue == 0) continue;
                        }
                    }

                    if (updateArticle.Add(notice))
                    {
                        Article article = new Article(notice, info, subject, comment, userid, username, date, hits, recomm, ip);
                        articleList.Add(article);

                        if (check_saveImage.Checked && info.Contains("pic")) await parsingImages(notice);
                    }
                }
            }
            catch
            {

            }
            
            isFinished = true;
            return isFinished;
        }
        */

        private async void GoGetSomePics(string gallery)
        {
            var taskChek = await PreChekingDupeFiles(gallery);

            while (!_stopLoop)
            {
                var task = await parsingFirstPage(gallery);
                await Task.Delay(5000);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            DisablingButtons();
            checkImageDownload();

            foreach (var item in selectedList)
            {
                GoGetSomePics(item.Value);
            }
        }

        private void checkImageDownload()
        {
            try
            {
                if (saveFolder.Equals(""))
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult results = fbd.ShowDialog();

                    if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        saveFolder = fbd.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                text_logger.AppendText(String.Format("{0}\r\n", ex.ToString()));
            }
        }
        
        private void data_picture_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (data_picture.SelectedCells.Count > 0)
            {
                int selectedrowindex = data_picture.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = data_picture.Rows[selectedrowindex];
                string imgPath = String.Format(@"{0}\\{1}", saveFolder, selectedRow.Cells[3].Value);
                //Process.Start(imgPath);
            }
        }

        private void DisablingButtons()
        {
            btn_stop.Enabled = true;
            _stopLoop = false;

            articleList.Clear();
            commentList.Clear();
            updateArticle.Clear();
            pictureList.Clear();
            savedImageHash.Clear();
            savedArticle = 0;
            savedImage = 0;

            list_selected.Enabled = false;
            list_galleryList.Enabled = false;

            button1.Enabled = false;
            button2.Enabled = false;
            
            btn_refresh.Enabled = false;
            
            /*
            check_userid.Enabled = false;
            check_username.Enabled = false;
            check_subject.Enabled = false;
            
            search_subject.Enabled = false;
            search_userid.Enabled = false;
            search_username.Enabled = false;
            */
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
            
            /*
            check_userid.Enabled = true;
            check_username.Enabled = true;
            check_subject.Enabled = true;
            
            if (check_subject.Checked) search_subject.Enabled = true;
            if (check_userid.Checked) search_userid.Enabled = true;
            if (check_username.Checked) search_username.Enabled = true;
            */
        }
        
        private void btn_stop_Click(object sender, EventArgs e)
        {
            EnablingButtons();
        }

        private void check_subject_CheckedChanged(object sender, EventArgs e)
        {
            if (check_subject.Checked) search_subject.Enabled = true;
            else search_subject.Enabled = false;
        }
        
        private void check_userid_CheckedChanged(object sender, EventArgs e)
        {
            if (check_userid.Checked) search_userid.Enabled = true;
            else search_userid.Enabled = false;
        }

        private void check_username_CheckedChanged(object sender, EventArgs e)
        {
            if (check_username.Checked) search_username.Enabled = true;
            else search_username.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (galleryList.Count > 0)
            {
                selectedList.Add(new KeyValuePair<string, string>(galleryList.ElementAt(list_galleryList.SelectedIndex).Key, galleryList.ElementAt(list_galleryList.SelectedIndex).Value));
                galleryList.Remove(new KeyValuePair<string, string>(galleryList.ElementAt(list_galleryList.SelectedIndex).Key, galleryList.ElementAt(list_galleryList.SelectedIndex).Value));
                btn_refresh.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ( selectedList.Count > 0)
            {
                galleryList.Insert(0, new KeyValuePair<string, string>(selectedList.ElementAt(list_selected.SelectedIndex).Key, selectedList.ElementAt(list_selected.SelectedIndex).Value));
                selectedList.Remove(new KeyValuePair<string, string>(selectedList.ElementAt(list_selected.SelectedIndex).Key, selectedList.ElementAt(list_selected.SelectedIndex).Value));
            }
            if (selectedList.Count == 0) btn_refresh.Enabled = false;
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
            pi.SetValue(dgv, setting, null);
        }
    }
}
