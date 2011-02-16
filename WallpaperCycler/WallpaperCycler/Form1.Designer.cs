namespace WallpaperCycler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Notifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotiMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangeWallpaperMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSettingsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SubfolderChk = new System.Windows.Forms.CheckBox();
            this.FolderPathBtn = new System.Windows.Forms.Button();
            this.FolderPathTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCycleTime = new System.Windows.Forms.CheckBox();
            this.ChangeWallpaperBtn = new System.Windows.Forms.Button();
            this.txtCycleTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SpecialImageSizeTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SpecialImageCbox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SmallImageCbox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LargeImageCbox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AutoStartupChk = new System.Windows.Forms.CheckBox();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.NotiMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Notifier
            // 
            this.Notifier.ContextMenuStrip = this.NotiMenu;
            this.Notifier.Icon = ((System.Drawing.Icon)(resources.GetObject("Notifier.Icon")));
            this.Notifier.Text = "Wallpaper Cycler";
            this.Notifier.Visible = true;
            this.Notifier.DoubleClick += new System.EventHandler(this.EditSettingsBtn_Click);
            // 
            // NotiMenu
            // 
            this.NotiMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeWallpaperMenuBtn,
            this.EditSettingsBtn,
            this.toolStripSeparator1,
            this.ExitBtn});
            this.NotiMenu.Name = "NotiMenu";
            this.NotiMenu.Size = new System.Drawing.Size(195, 76);
            // 
            // ChangeWallpaperMenuBtn
            // 
            this.ChangeWallpaperMenuBtn.Name = "ChangeWallpaperMenuBtn";
            this.ChangeWallpaperMenuBtn.Size = new System.Drawing.Size(194, 22);
            this.ChangeWallpaperMenuBtn.Text = "&Next Random Wallpaper!";
            this.ChangeWallpaperMenuBtn.Click += new System.EventHandler(this.ChangeWallpaperBtn_Click);
            // 
            // EditSettingsBtn
            // 
            this.EditSettingsBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSettingsBtn.Name = "EditSettingsBtn";
            this.EditSettingsBtn.Size = new System.Drawing.Size(194, 22);
            this.EditSettingsBtn.Text = "Edit &Settings";
            this.EditSettingsBtn.Click += new System.EventHandler(this.EditSettingsBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(194, 22);
            this.ExitBtn.Text = "E&xit";
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.SubfolderChk);
            this.groupBox1.Controls.Add(this.FolderPathBtn);
            this.groupBox1.Controls.Add(this.FolderPathTxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wallpaper Directory";
            // 
            // SubfolderChk
            // 
            this.SubfolderChk.AutoSize = true;
            this.SubfolderChk.Location = new System.Drawing.Point(6, 47);
            this.SubfolderChk.Name = "SubfolderChk";
            this.SubfolderChk.Size = new System.Drawing.Size(114, 17);
            this.SubfolderChk.TabIndex = 2;
            this.SubfolderChk.Text = "Look in Subfolders";
            this.SubfolderChk.UseVisualStyleBackColor = true;
            // 
            // FolderPathBtn
            // 
            this.FolderPathBtn.Location = new System.Drawing.Point(276, 19);
            this.FolderPathBtn.Name = "FolderPathBtn";
            this.FolderPathBtn.Size = new System.Drawing.Size(30, 23);
            this.FolderPathBtn.TabIndex = 1;
            this.FolderPathBtn.Text = "...";
            this.FolderPathBtn.UseVisualStyleBackColor = true;
            this.FolderPathBtn.Click += new System.EventHandler(this.FolderPathBtn_Click);
            // 
            // FolderPathTxt
            // 
            this.FolderPathTxt.Location = new System.Drawing.Point(6, 21);
            this.FolderPathTxt.Name = "FolderPathTxt";
            this.FolderPathTxt.ReadOnly = true;
            this.FolderPathTxt.Size = new System.Drawing.Size(264, 20);
            this.FolderPathTxt.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkCycleTime);
            this.groupBox2.Controls.Add(this.ChangeWallpaperBtn);
            this.groupBox2.Controls.Add(this.txtCycleTime);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.SpecialImageSizeTxt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.SpecialImageCbox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.SmallImageCbox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.LargeImageCbox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.AutoStartupChk);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 188);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // chkCycleTime
            // 
            this.chkCycleTime.AutoSize = true;
            this.chkCycleTime.Location = new System.Drawing.Point(11, 125);
            this.chkCycleTime.Name = "chkCycleTime";
            this.chkCycleTime.Size = new System.Drawing.Size(182, 17);
            this.chkCycleTime.TabIndex = 3;
            this.chkCycleTime.Text = "Change to next Wallpaper Every ";
            this.chkCycleTime.UseVisualStyleBackColor = true;
            // 
            // ChangeWallpaperBtn
            // 
            this.ChangeWallpaperBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeWallpaperBtn.Location = new System.Drawing.Point(6, 152);
            this.ChangeWallpaperBtn.Name = "ChangeWallpaperBtn";
            this.ChangeWallpaperBtn.Size = new System.Drawing.Size(300, 30);
            this.ChangeWallpaperBtn.TabIndex = 3;
            this.ChangeWallpaperBtn.Text = "Next Random Wallpaper!";
            this.ChangeWallpaperBtn.UseVisualStyleBackColor = true;
            this.ChangeWallpaperBtn.Click += new System.EventHandler(this.ChangeWallpaperBtn_Click);
            // 
            // txtCycleTime
            // 
            this.txtCycleTime.Location = new System.Drawing.Point(194, 123);
            this.txtCycleTime.MaxLength = 4;
            this.txtCycleTime.Name = "txtCycleTime";
            this.txtCycleTime.Size = new System.Drawing.Size(42, 20);
            this.txtCycleTime.TabIndex = 15;
            this.txtCycleTime.Text = "128";
            this.txtCycleTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "min.";
            // 
            // SpecialImageSizeTxt
            // 
            this.SpecialImageSizeTxt.Location = new System.Drawing.Point(97, 96);
            this.SpecialImageSizeTxt.MaxLength = 5;
            this.SpecialImageSizeTxt.Name = "SpecialImageSizeTxt";
            this.SpecialImageSizeTxt.Size = new System.Drawing.Size(42, 20);
            this.SpecialImageSizeTxt.TabIndex = 15;
            this.SpecialImageSizeTxt.Text = "128";
            this.SpecialImageSizeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "px :";
            // 
            // SpecialImageCbox
            // 
            this.SpecialImageCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpecialImageCbox.FormattingEnabled = true;
            this.SpecialImageCbox.Location = new System.Drawing.Point(175, 96);
            this.SpecialImageCbox.Name = "SpecialImageCbox";
            this.SpecialImageCbox.Size = new System.Drawing.Size(121, 21);
            this.SpecialImageCbox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "For images <= to";
            // 
            // SmallImageCbox
            // 
            this.SmallImageCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SmallImageCbox.FormattingEnabled = true;
            this.SmallImageCbox.Location = new System.Drawing.Point(175, 69);
            this.SmallImageCbox.Name = "SmallImageCbox";
            this.SmallImageCbox.Size = new System.Drawing.Size(121, 21);
            this.SmallImageCbox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "For Images Smaller than Screen :";
            // 
            // LargeImageCbox
            // 
            this.LargeImageCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LargeImageCbox.FormattingEnabled = true;
            this.LargeImageCbox.Location = new System.Drawing.Point(175, 42);
            this.LargeImageCbox.Name = "LargeImageCbox";
            this.LargeImageCbox.Size = new System.Drawing.Size(121, 21);
            this.LargeImageCbox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "For Images Larger than Screen :";
            // 
            // AutoStartupChk
            // 
            this.AutoStartupChk.AutoSize = true;
            this.AutoStartupChk.Location = new System.Drawing.Point(9, 19);
            this.AutoStartupChk.Name = "AutoStartupChk";
            this.AutoStartupChk.Size = new System.Drawing.Size(137, 17);
            this.AutoStartupChk.TabIndex = 0;
            this.AutoStartupChk.Text = "Autostart with Windows";
            this.AutoStartupChk.UseVisualStyleBackColor = true;
            this.AutoStartupChk.CheckedChanged += new System.EventHandler(this.AutoStartupChk_CheckedChanged);
            // 
            // folderBrowser
            // 
            this.folderBrowser.Description = "Wallpaper Directory";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 288);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Wallpaper Cycler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.NotiMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon Notifier;
        private System.Windows.Forms.ContextMenuStrip NotiMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox SubfolderChk;
        private System.Windows.Forms.Button FolderPathBtn;
        private System.Windows.Forms.TextBox FolderPathTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem ChangeWallpaperMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem EditSettingsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitBtn;
        private System.Windows.Forms.TextBox SpecialImageSizeTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SpecialImageCbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SmallImageCbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LargeImageCbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox AutoStartupChk;
        private System.Windows.Forms.Button ChangeWallpaperBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.TextBox txtCycleTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.CheckBox chkCycleTime;
    }
}

