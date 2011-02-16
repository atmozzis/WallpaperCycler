using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WallpaperCycler
{
    public partial class MainForm : Form
    {
        public UserData User;

        public MainForm()
        {
            InitializeComponent();
            InitUserData();
            InitUI();
        }

        private void InitUserData()
        {
            User = UserData.LoadUserData();
        }

        private void Save()
        {
            User.SaveUserData();
        }

        private void InitUI()
        {
            foreach (var item in Enum.GetNames(typeof(WallpaperStyle)))
            {
                LargeImageCbox.Items.Add(item);
                SmallImageCbox.Items.Add(item);
                SpecialImageCbox.Items.Add(item);
            }

            FolderPathTxt.DataBindings.Add(new Binding("Text", User, "WallpaperDirectory", false, DataSourceUpdateMode.OnPropertyChanged));
            SubfolderChk.DataBindings.Add(new Binding("Checked", User, "WallpaperSubDirectory", false, DataSourceUpdateMode.OnPropertyChanged));
            LargeImageCbox.DataBindings.Add(new Binding("SelectedIndex", User, "LargeWallpaperStyle", false, DataSourceUpdateMode.OnPropertyChanged));
            SmallImageCbox.DataBindings.Add(new Binding("SelectedIndex", User, "SmallWallpaperStyle", false, DataSourceUpdateMode.OnPropertyChanged));
            SpecialImageCbox.DataBindings.Add(new Binding("SelectedIndex", User, "SpecialWallpaperStyle", false, DataSourceUpdateMode.OnPropertyChanged));
            SpecialImageSizeTxt.DataBindings.Add(new Binding("Text", User, "SpecialWallpaperSize", false, DataSourceUpdateMode.OnPropertyChanged));
            txtCycleTime.DataBindings.Add(new Binding("Text", User, "ChangingTimeString", false, DataSourceUpdateMode.OnPropertyChanged));
            chkCycleTime.DataBindings.Add(new Binding("Checked", User, "CycleTimeEnabled", false, DataSourceUpdateMode.OnPropertyChanged));

            chkCycleTime.CheckedChanged += (Object sender, EventArgs e) => SetTimer();
            txtCycleTime.TextChanged += (Object sender, EventArgs e) => SetTimer();

            AutoStartupChk.Checked = Helper.IsAutoStartEnabled();
            SetTimer();

            if (User.WallpaperDirectory == String.Empty || AutoStartupChk.Checked == false)
            {
                Show();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                Notifier.Visible = false;
            }
        }

        private void ChangeWallpaperBtn_Click(object sender, EventArgs e)
        {
            ChangeWallpaper();
        }

        private void EditSettingsBtn_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Save();
            Notifier.Visible = false;
            Application.Exit();
        }

        private void ChangeWallpaper()
        {
            if (!backgroundWorker.IsBusy)
            {
                ChangeWallpaperBtn.Enabled = false;
                ChangeWallpaperMenuBtn.Enabled = false;
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            User.NextRandomWallpaper();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ChangeWallpaperBtn.Enabled = true;
            ChangeWallpaperMenuBtn.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ChangeWallpaper();
        }

        private void SetTimer()
        {
            if (chkCycleTime.Checked && txtCycleTime.Text != "0")
            {
                BeginInvoke(new Action(() =>
                {
                    txtCycleTime.DataBindings["Text"].WriteValue();
                    Timer.Interval = User.ChangingTimeMilliSeconds;
                    Timer.Enabled = true;
                }));
            }
            else
            {
                Timer.Enabled = false;
            }
        }

        private void AutoStartupChk_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoStartupChk.Checked)
            {
                Helper.SetAutoStart();
            }
            else
            {
                Helper.UnSetAutoStart();
            }
        }

        private void FolderPathBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FolderPathTxt.Text = folderBrowser.SelectedPath;
            }
        }
    }
}
