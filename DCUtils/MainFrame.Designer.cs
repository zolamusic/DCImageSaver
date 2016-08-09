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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ComboBox_galleryList = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.data_article = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.data_comment = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.data_picture = new System.Windows.Forms.DataGridView();
            this.pageStart = new System.Windows.Forms.NumericUpDown();
            this.pageEnd = new System.Windows.Forms.NumericUpDown();
            this.btn_collect = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.search_subject = new System.Windows.Forms.TextBox();
            this.search_userid = new System.Windows.Forms.TextBox();
            this.search_username = new System.Windows.Forms.TextBox();
            this.search_memo = new System.Windows.Forms.TextBox();
            this.check_subject = new System.Windows.Forms.CheckBox();
            this.check_userid = new System.Windows.Forms.CheckBox();
            this.check_username = new System.Windows.Forms.CheckBox();
            this.check_memo = new System.Windows.Forms.CheckBox();
            this.check_ip = new System.Windows.Forms.CheckBox();
            this.search_ip = new System.Windows.Forms.TextBox();
            this.check_and = new System.Windows.Forms.CheckBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.check_saveImage = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_article)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_comment)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBox_galleryList
            // 
            this.ComboBox_galleryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_galleryList.FormattingEnabled = true;
            this.ComboBox_galleryList.Location = new System.Drawing.Point(12, 12);
            this.ComboBox_galleryList.Name = "ComboBox_galleryList";
            this.ComboBox_galleryList.Size = new System.Drawing.Size(160, 20);
            this.ComboBox_galleryList.TabIndex = 0;
            this.ComboBox_galleryList.SelectedIndexChanged += new System.EventHandler(this.ComboBox_galleryList_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 67);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1125, 742);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.data_article);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1117, 716);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Article";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // data_article
            // 
            this.data_article.AllowUserToAddRows = false;
            this.data_article.AllowUserToDeleteRows = false;
            this.data_article.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LightYellow;
            this.data_article.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.data_article.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_article.BackgroundColor = System.Drawing.SystemColors.Control;
            this.data_article.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_article.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.data_article.Location = new System.Drawing.Point(3, 3);
            this.data_article.Name = "data_article";
            this.data_article.ReadOnly = true;
            this.data_article.RowTemplate.Height = 23;
            this.data_article.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_article.Size = new System.Drawing.Size(1111, 710);
            this.data_article.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.data_comment);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1117, 716);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Comment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // data_comment
            // 
            this.data_comment.AllowUserToAddRows = false;
            this.data_comment.AllowUserToDeleteRows = false;
            this.data_comment.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Linen;
            this.data_comment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            this.data_comment.BackgroundColor = System.Drawing.SystemColors.Control;
            this.data_comment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_comment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.data_comment.Location = new System.Drawing.Point(3, 3);
            this.data_comment.Name = "data_comment";
            this.data_comment.ReadOnly = true;
            this.data_comment.RowTemplate.Height = 23;
            this.data_comment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_comment.Size = new System.Drawing.Size(1111, 710);
            this.data_comment.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.data_picture);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1117, 716);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Picture";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // data_picture
            // 
            this.data_picture.AllowUserToAddRows = false;
            this.data_picture.AllowUserToDeleteRows = false;
            this.data_picture.AllowUserToResizeRows = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.Honeydew;
            this.data_picture.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.data_picture.BackgroundColor = System.Drawing.SystemColors.Control;
            this.data_picture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_picture.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.data_picture.Location = new System.Drawing.Point(3, 3);
            this.data_picture.MultiSelect = false;
            this.data_picture.Name = "data_picture";
            this.data_picture.ReadOnly = true;
            this.data_picture.RowTemplate.Height = 23;
            this.data_picture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_picture.Size = new System.Drawing.Size(1111, 710);
            this.data_picture.TabIndex = 0;
            this.data_picture.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_picture_CellDoubleClick_1);
            // 
            // pageStart
            // 
            this.pageStart.Location = new System.Drawing.Point(12, 39);
            this.pageStart.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.pageStart.Name = "pageStart";
            this.pageStart.Size = new System.Drawing.Size(75, 21);
            this.pageStart.TabIndex = 1;
            this.pageStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pageEnd
            // 
            this.pageEnd.Location = new System.Drawing.Point(97, 39);
            this.pageEnd.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.pageEnd.Name = "pageEnd";
            this.pageEnd.Size = new System.Drawing.Size(75, 21);
            this.pageEnd.TabIndex = 2;
            this.pageEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_collect
            // 
            this.btn_collect.Location = new System.Drawing.Point(827, 12);
            this.btn_collect.Name = "btn_collect";
            this.btn_collect.Size = new System.Drawing.Size(75, 50);
            this.btn_collect.TabIndex = 3;
            this.btn_collect.Text = "이전내역\r\n검색";
            this.btn_collect.UseVisualStyleBackColor = true;
            this.btn_collect.Click += new System.EventHandler(this.btn_collect_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(989, 12);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(67, 50);
            this.btn_stop.TabIndex = 5;
            this.btn_stop.Text = "정지";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // search_subject
            // 
            this.search_subject.Enabled = false;
            this.search_subject.Location = new System.Drawing.Point(270, 13);
            this.search_subject.Name = "search_subject";
            this.search_subject.Size = new System.Drawing.Size(220, 21);
            this.search_subject.TabIndex = 11;
            // 
            // search_userid
            // 
            this.search_userid.Enabled = false;
            this.search_userid.Location = new System.Drawing.Point(565, 13);
            this.search_userid.Name = "search_userid";
            this.search_userid.Size = new System.Drawing.Size(100, 21);
            this.search_userid.TabIndex = 13;
            // 
            // search_username
            // 
            this.search_username.Enabled = false;
            this.search_username.Location = new System.Drawing.Point(565, 39);
            this.search_username.Name = "search_username";
            this.search_username.Size = new System.Drawing.Size(100, 21);
            this.search_username.TabIndex = 15;
            // 
            // search_memo
            // 
            this.search_memo.Enabled = false;
            this.search_memo.Location = new System.Drawing.Point(270, 39);
            this.search_memo.Name = "search_memo";
            this.search_memo.Size = new System.Drawing.Size(220, 21);
            this.search_memo.TabIndex = 9;
            this.search_memo.Visible = false;
            // 
            // check_subject
            // 
            this.check_subject.AutoSize = true;
            this.check_subject.Location = new System.Drawing.Point(187, 15);
            this.check_subject.Name = "check_subject";
            this.check_subject.Size = new System.Drawing.Size(66, 16);
            this.check_subject.TabIndex = 10;
            this.check_subject.Text = "Subject";
            this.check_subject.UseVisualStyleBackColor = true;
            this.check_subject.CheckedChanged += new System.EventHandler(this.check_subject_CheckedChanged);
            // 
            // check_userid
            // 
            this.check_userid.AutoSize = true;
            this.check_userid.Location = new System.Drawing.Point(501, 15);
            this.check_userid.Name = "check_userid";
            this.check_userid.Size = new System.Drawing.Size(35, 16);
            this.check_userid.TabIndex = 12;
            this.check_userid.Text = "ID";
            this.check_userid.UseVisualStyleBackColor = true;
            this.check_userid.CheckedChanged += new System.EventHandler(this.check_userid_CheckedChanged);
            // 
            // check_username
            // 
            this.check_username.AutoSize = true;
            this.check_username.Location = new System.Drawing.Point(501, 41);
            this.check_username.Name = "check_username";
            this.check_username.Size = new System.Drawing.Size(58, 16);
            this.check_username.TabIndex = 14;
            this.check_username.Text = "Name";
            this.check_username.UseVisualStyleBackColor = true;
            this.check_username.CheckedChanged += new System.EventHandler(this.check_username_CheckedChanged);
            // 
            // check_memo
            // 
            this.check_memo.AutoSize = true;
            this.check_memo.Location = new System.Drawing.Point(675, 41);
            this.check_memo.Name = "check_memo";
            this.check_memo.Size = new System.Drawing.Size(79, 16);
            this.check_memo.TabIndex = 18;
            this.check_memo.Text = "Comment";
            this.check_memo.UseVisualStyleBackColor = true;
            this.check_memo.CheckedChanged += new System.EventHandler(this.check_memo_CheckedChanged);
            // 
            // check_ip
            // 
            this.check_ip.AutoSize = true;
            this.check_ip.Location = new System.Drawing.Point(675, 15);
            this.check_ip.Name = "check_ip";
            this.check_ip.Size = new System.Drawing.Size(35, 16);
            this.check_ip.TabIndex = 16;
            this.check_ip.Text = "IP";
            this.check_ip.UseVisualStyleBackColor = true;
            this.check_ip.CheckedChanged += new System.EventHandler(this.check_ip_CheckedChanged);
            // 
            // search_ip
            // 
            this.search_ip.Enabled = false;
            this.search_ip.Location = new System.Drawing.Point(716, 13);
            this.search_ip.Name = "search_ip";
            this.search_ip.Size = new System.Drawing.Size(100, 21);
            this.search_ip.TabIndex = 17;
            // 
            // check_and
            // 
            this.check_and.AutoSize = true;
            this.check_and.Checked = true;
            this.check_and.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_and.Location = new System.Drawing.Point(761, 41);
            this.check_and.Name = "check_and";
            this.check_and.Size = new System.Drawing.Size(55, 16);
            this.check_and.TabIndex = 16;
            this.check_and.Text = "AND?";
            this.check_and.UseVisualStyleBackColor = true;
            this.check_and.Visible = false;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(908, 12);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 50);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.Text = "첫페이지\r\n무한반복";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // check_saveImage
            // 
            this.check_saveImage.AutoSize = true;
            this.check_saveImage.Checked = true;
            this.check_saveImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_saveImage.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.check_saveImage.ForeColor = System.Drawing.Color.Red;
            this.check_saveImage.Location = new System.Drawing.Point(1066, 24);
            this.check_saveImage.Name = "check_saveImage";
            this.check_saveImage.Size = new System.Drawing.Size(64, 28);
            this.check_saveImage.TabIndex = 6;
            this.check_saveImage.Text = "Save\r\nImage";
            this.check_saveImage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "← 페이지는 마음대로 변경해서 사용해도 됩니다.";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1149, 821);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.check_saveImage);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.check_and);
            this.Controls.Add(this.search_ip);
            this.Controls.Add(this.check_ip);
            this.Controls.Add(this.check_memo);
            this.Controls.Add(this.check_username);
            this.Controls.Add(this.check_userid);
            this.Controls.Add(this.check_subject);
            this.Controls.Add(this.search_memo);
            this.Controls.Add(this.search_username);
            this.Controls.Add(this.search_userid);
            this.Controls.Add(this.search_subject);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_collect);
            this.Controls.Add(this.pageEnd);
            this.Controls.Add(this.pageStart);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ComboBox_galleryList);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainFrame";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_article)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_comment)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBox_galleryList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView data_article;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView data_comment;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.NumericUpDown pageStart;
        private System.Windows.Forms.NumericUpDown pageEnd;
        private System.Windows.Forms.Button btn_collect;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.TextBox search_subject;
        private System.Windows.Forms.TextBox search_userid;
        private System.Windows.Forms.TextBox search_username;
        private System.Windows.Forms.TextBox search_memo;
        private System.Windows.Forms.CheckBox check_subject;
        private System.Windows.Forms.CheckBox check_userid;
        private System.Windows.Forms.CheckBox check_username;
        private System.Windows.Forms.CheckBox check_memo;
        private System.Windows.Forms.CheckBox check_ip;
        private System.Windows.Forms.TextBox search_ip;
        private System.Windows.Forms.CheckBox check_and;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.DataGridView data_picture;
        private System.Windows.Forms.CheckBox check_saveImage;
        private System.Windows.Forms.Label label1;
    }
}

