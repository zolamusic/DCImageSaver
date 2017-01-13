namespace DCUtils
{
    partial class MainFrame
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.data_article = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.data_picture = new System.Windows.Forms.DataGridView();
            this.btn_stop = new System.Windows.Forms.Button();
            this.search_username = new System.Windows.Forms.TextBox();
            this.check_username = new System.Windows.Forms.CheckBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.list_galleryList = new System.Windows.Forms.ListBox();
            this.list_selected = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.text_logger = new System.Windows.Forms.TextBox();
            this.text_userid = new System.Windows.Forms.TextBox();
            this.text_passwd = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_savedImage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_savedArticle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_article)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_picture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(138, 110);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(999, 699);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.data_article);
            this.tabPage1.Location = new System.Drawing.Point(22, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(973, 691);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Article";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // data_article
            // 
            this.data_article.AllowUserToAddRows = false;
            this.data_article.AllowUserToDeleteRows = false;
            this.data_article.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow;
            this.data_article.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.data_article.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_article.BackgroundColor = System.Drawing.SystemColors.Control;
            this.data_article.ColumnHeadersHeight = 20;
            this.data_article.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.data_article.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.data_article.Location = new System.Drawing.Point(3, 3);
            this.data_article.Name = "data_article";
            this.data_article.ReadOnly = true;
            this.data_article.RowHeadersVisible = false;
            this.data_article.RowTemplate.Height = 23;
            this.data_article.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_article.Size = new System.Drawing.Size(967, 685);
            this.data_article.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.data_picture);
            this.tabPage3.Location = new System.Drawing.Point(22, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(973, 691);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Picture";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // data_picture
            // 
            this.data_picture.AllowUserToAddRows = false;
            this.data_picture.AllowUserToDeleteRows = false;
            this.data_picture.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Honeydew;
            this.data_picture.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.data_picture.BackgroundColor = System.Drawing.SystemColors.Control;
            this.data_picture.ColumnHeadersHeight = 20;
            this.data_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_picture.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.data_picture.Location = new System.Drawing.Point(3, 3);
            this.data_picture.MultiSelect = false;
            this.data_picture.Name = "data_picture";
            this.data_picture.ReadOnly = true;
            this.data_picture.RowHeadersVisible = false;
            this.data_picture.RowTemplate.Height = 23;
            this.data_picture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_picture.Size = new System.Drawing.Size(967, 685);
            this.data_picture.TabIndex = 0;
            this.data_picture.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_picture_CellDoubleClick_1);
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(306, 59);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(83, 42);
            this.btn_stop.TabIndex = 5;
            this.btn_stop.Text = "정지";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // search_username
            // 
            this.search_username.Enabled = false;
            this.search_username.Location = new System.Drawing.Point(693, 71);
            this.search_username.Name = "search_username";
            this.search_username.Size = new System.Drawing.Size(100, 21);
            this.search_username.TabIndex = 15;
            this.search_username.Visible = false;
            // 
            // check_username
            // 
            this.check_username.AutoSize = true;
            this.check_username.Enabled = false;
            this.check_username.Location = new System.Drawing.Point(629, 73);
            this.check_username.Name = "check_username";
            this.check_username.Size = new System.Drawing.Size(58, 16);
            this.check_username.TabIndex = 14;
            this.check_username.Text = "Name";
            this.check_username.UseVisualStyleBackColor = true;
            this.check_username.Visible = false;
            this.check_username.CheckedChanged += new System.EventHandler(this.check_username_CheckedChanged);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(306, 11);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(83, 42);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.Text = "짤방 저장 ";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // list_galleryList
            // 
            this.list_galleryList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.list_galleryList.FormattingEnabled = true;
            this.list_galleryList.ItemHeight = 12;
            this.list_galleryList.Location = new System.Drawing.Point(12, 12);
            this.list_galleryList.Name = "list_galleryList";
            this.list_galleryList.Size = new System.Drawing.Size(120, 796);
            this.list_galleryList.TabIndex = 16;
            // 
            // list_selected
            // 
            this.list_selected.FormattingEnabled = true;
            this.list_selected.ItemHeight = 12;
            this.list_selected.Location = new System.Drawing.Point(175, 12);
            this.list_selected.Name = "list_selected";
            this.list_selected.Size = new System.Drawing.Size(120, 88);
            this.list_selected.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(138, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 42);
            this.button1.TabIndex = 18;
            this.button1.Text = "→";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(138, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 42);
            this.button2.TabIndex = 19;
            this.button2.Text = "←";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // text_logger
            // 
            this.text_logger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_logger.Location = new System.Drawing.Point(600, 12);
            this.text_logger.Multiline = true;
            this.text_logger.Name = "text_logger";
            this.text_logger.ReadOnly = true;
            this.text_logger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_logger.Size = new System.Drawing.Size(537, 88);
            this.text_logger.TabIndex = 20;
            // 
            // text_userid
            // 
            this.text_userid.Location = new System.Drawing.Point(6, 20);
            this.text_userid.Name = "text_userid";
            this.text_userid.Size = new System.Drawing.Size(100, 21);
            this.text_userid.TabIndex = 25;
            // 
            // text_passwd
            // 
            this.text_passwd.Location = new System.Drawing.Point(6, 47);
            this.text_passwd.Name = "text_passwd";
            this.text_passwd.PasswordChar = '*';
            this.text_passwd.Size = new System.Drawing.Size(100, 21);
            this.text_passwd.TabIndex = 26;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(112, 20);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(77, 50);
            this.btn_login.TabIndex = 27;
            this.btn_login.Text = "로그인";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_login);
            this.groupBox1.Controls.Add(this.text_userid);
            this.groupBox1.Controls.Add(this.text_passwd);
            this.groupBox1.Location = new System.Drawing.Point(399, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 77);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "로그인 정보";
            // 
            // label_savedImage
            // 
            this.label_savedImage.AutoSize = true;
            this.label_savedImage.Location = new System.Drawing.Point(1122, 95);
            this.label_savedImage.Name = "label_savedImage";
            this.label_savedImage.Size = new System.Drawing.Size(11, 12);
            this.label_savedImage.TabIndex = 24;
            this.label_savedImage.Text = "0";
            this.label_savedImage.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1062, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "짤방:";
            this.label2.Visible = false;
            // 
            // label_savedArticle
            // 
            this.label_savedArticle.AutoSize = true;
            this.label_savedArticle.Location = new System.Drawing.Point(1026, 95);
            this.label_savedArticle.Name = "label_savedArticle";
            this.label_savedArticle.Size = new System.Drawing.Size(11, 12);
            this.label_savedArticle.TabIndex = 23;
            this.label_savedArticle.Text = "0";
            this.label_savedArticle.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(981, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "글:";
            this.label1.Visible = false;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1149, 821);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_savedImage);
            this.Controls.Add(this.label_savedArticle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_logger);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.list_selected);
            this.Controls.Add(this.list_galleryList);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.check_username);
            this.Controls.Add(this.search_username);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainFrame";
            this.Text = "디씨 짤긁기";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_article)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_picture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView data_article;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.TextBox search_username;
        private System.Windows.Forms.CheckBox check_username;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.DataGridView data_picture;
        private System.Windows.Forms.ListBox list_galleryList;
        private System.Windows.Forms.ListBox list_selected;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox text_logger;
        private System.Windows.Forms.TextBox text_userid;
        private System.Windows.Forms.TextBox text_passwd;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_savedImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_savedArticle;
        private System.Windows.Forms.Label label1;
    }
}

