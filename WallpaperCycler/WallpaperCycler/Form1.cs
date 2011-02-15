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
            SetTimerInterval();

            User.SaveUserData();
        }

        private void SetTimerInterval()
        {
            if (Timer != null)
            {
                Int64 iTime = 0;
                Int64.TryParse(User.ChangingTime, out iTime);
                iTime *= 1000 * 60; // To convert to Milliseconds
                if (iTime == 0 || iTime >= Int32.MaxValue || iTime <= Int32.MinValue)
                {
                    Timer.Enabled = false;
                    txtCycleTime.Text = "0";
                }
                else
                {
                    Timer.Interval = (Int32)iTime;
                    Timer.Enabled = true;
                }
            }
        }

        private void InitUI()
        {
            FolderPathTxt.DataBindings.Add(new Binding("Text", User, "WallpaperDirectory"));
            SubfolderChk.DataBindings.Add(new Binding("Checked", User, "WallpaperSubDirectory"));
            AutoStartupChk.Checked = Helper.IsAutoStartEnabled();
            LargeImageCbox.DataBindings.Add(new Binding("SelectedIndex", User, "LargeWallpaperStyle"));
            SmallImageCbox.DataBindings.Add(new Binding("SelectedIndex", User, "SmallWallpaperStyle"));
            SpecialImageCbox.DataBindings.Add(new Binding("SelectedIndex", User, "SpecialWallpaperStyle"));
            SpecialImageSizeTxt.DataBindings.Add(new Binding("Text", User, "SpecialWallpaperSize"));
            txtCycleTime.DataBindings.Add(new Binding("Text", User, "ChangingTime"));

            if (User.WallpaperDirectory == String.Empty || AutoStartupChk.Checked == false)
            {
                Show();
            }
            SetTimerInterval();
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
            Application.Exit();
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

        private Boolean ChangingText = false;
        private void SpecialImageSizeTxt_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                Int32 dontuse = 0;
                if (ChangingText == false && Int32.TryParse(textbox.Text, out dontuse) == false)
                {
                    ChangingText = true;
                    String newText = "";
                    foreach (Char ch in textbox.Text.ToCharArray())
                    {
                        if (ch == '1'
                            || ch == '2'
                            || ch == '3'
                            || ch == '4'
                            || ch == '5'
                            || ch == '6'
                            || ch == '7'
                            || ch == '8'
                            || ch == '9'
                            || ch == '0'
                            )
                        {
                            newText += Char.ToString(ch);
                        }
                    }
                    textbox.Text = newText;
                    ChangingText = false;
                }
            }
        }

        private void UserDataTxt_TextChanged(object sender, EventArgs e)
        {
            Save();
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

        
    }
}
