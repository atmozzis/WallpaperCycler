using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WallpaperCycler
{
    [XmlRootAttribute()]
    public class UserData
    {
        private const Int32 LastWallpaperPathCount = 5;

        /// <summary>
        /// Gets the UserData FilePath
        /// </summary>
        private static String UserDataPath
        {
            get
            {
                String LoadPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                String DataFileName = Environment.UserName + ".data";
                return Path.Combine(LoadPath, DataFileName);
            }
        }

        /// <summary>
        /// Gets the ErrorLog FilePath
        /// </summary>
        private static String ErrorLogPath
        {
            get
            {
                String LoadPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                String DataFileName = Environment.UserName + ".error";
                return Path.Combine(LoadPath, DataFileName);
            }
        }

        private String WallpaperDir;
        private List<String> lastWallpaperPath;
        private WallpaperStyle LargeImageStyle, SmallImageStyle, SpecialImageStyle;
        private Int32 SpecialImageSize, WallpaperCycleTime;
        private Boolean WallpaperSubDir, cycleTimeEnabled;

        public String WallpaperDirectory
        {
            get { return WallpaperDir; }
            set { WallpaperDir = value; }
        }

        public Int32 LargeWallpaperStyle
        {
            get { return (Int32)LargeImageStyle; }
            set { LargeImageStyle = (WallpaperStyle)value; }
        }

        public Int32 SmallWallpaperStyle
        {
            get { return (Int32)SmallImageStyle; }
            set { SmallImageStyle = (WallpaperStyle)value; }
        }

        public Int32 SpecialWallpaperStyle
        {
            get { return (Int32)SpecialImageStyle; }
            set { SpecialImageStyle = (WallpaperStyle)value; }
        }

        public String SpecialWallpaperSize
        {
            get { return SpecialImageSize.ToString(); }
            set { Int32.TryParse(value, out SpecialImageSize); }
        }

        public String ChangingTimeString
        {
            get 
            {
                Int32 iTime = WallpaperCycleTime / 1000 / 60; // To convert to Min
                return iTime.ToString();
            }
            set
            {
                Int64 iTime = 0;
                Int64.TryParse(value, out iTime);
                iTime *= 1000 * 60; // To convert to Milliseconds
                if (iTime >= Int32.MaxValue || iTime <= Int32.MinValue)
                {
                    WallpaperCycleTime = 0;
                }
                else
                {
                    WallpaperCycleTime = (Int32)iTime;
                }
            }
        }

        public Int32 ChangingTimeMilliSeconds
        {
            get { return WallpaperCycleTime; }
            set { WallpaperCycleTime = value; }
        }

        public Boolean WallpaperSubDirectory
        {
            get { return WallpaperSubDir; }
            set { WallpaperSubDir = value; }
        }

        public Boolean CycleTimeEnabled
        {
            get { return cycleTimeEnabled; }
            set { cycleTimeEnabled = value; }
        }

        public UserData()
        {
            lastWallpaperPath = new List<String>();
            WallpaperDir = "";
            LargeImageStyle = WallpaperStyle.Stretch;
            SmallImageStyle = WallpaperStyle.Center;
            SpecialImageStyle = WallpaperStyle.Tile;
            SpecialImageSize = 128;
            WallpaperCycleTime = 0;
            WallpaperSubDir = false;
            cycleTimeEnabled = false;
        }

        public static UserData LoadUserData()
        {
            UserData loadingData = new UserData();

            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(UserData));
                XmlReader xr = XmlReader.Create(UserDataPath);
                if (xs.CanDeserialize(xr))
                {
                    loadingData = (UserData)xs.Deserialize(xr);
                }
                xr.Close();
            }
            catch (Exception ex)
            {
                String Date = DateTime.Now.ToShortDateString();
                String Time = DateTime.Now.ToShortTimeString();
                File.AppendAllText(ErrorLogPath, "\r\n" + Date + " " + Time + "\t" + ex.Message);
            }

            if (loadingData == null)
            {
                loadingData = new UserData();
            }
            else
            {
                while(loadingData.lastWallpaperPath.Count > 1)
                {
                    loadingData.lastWallpaperPath.RemoveAt(0);
                }
            }
            return loadingData;
        }

        public void SaveUserData()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(UserData));
                XmlWriter xw = XmlWriter.Create(UserDataPath);
                xs.Serialize(xw, this);
                xw.Close();
            }
            catch (Exception ex)
            {
                String Date = DateTime.Now.ToShortDateString();
                String Time = DateTime.Now.ToShortTimeString();
                File.AppendAllText(ErrorLogPath, "\r\n" + Date + " " + Time + "\t" + ex.Message);
            }
        }

        public void NextRandomWallpaper()
        {
            List<String> Files = Helper.ProcessDirectory(WallpaperDir, WallpaperSubDir, LastWallpaperPathCount + 1);
            if (Files == null || Files.Count == 0)
            {
                Helper.ClearDesktopBackground();
                return;
            }

            List<String> tempFileList = Files;
            foreach (var path in lastWallpaperPath)
            {
                tempFileList.Remove(path);
            }

            String ChosenPath = (tempFileList.Count == 0) ? lastWallpaperPath[0] : tempFileList[0];

            lastWallpaperPath.Remove(ChosenPath);
            lastWallpaperPath.Add(ChosenPath);
            while (lastWallpaperPath.Count > LastWallpaperPathCount)
            {
                lastWallpaperPath.RemoveAt(0);
            }

            Bitmap img = null;
            try
            {
                img = new Bitmap(ChosenPath);
            }
            catch (Exception ex)
            {
                String Date = DateTime.Now.ToShortDateString();
                String Time = DateTime.Now.ToShortTimeString();
                File.AppendAllText(ErrorLogPath, "\r\n" + Date + " " + Time + "\t" + ex.Message);
            }
            Helper.SetDesktopBackground(img, DetermineImageStyle(img));
        }

        /// <summary>
        /// Return a DesktopBackgroundStyle enum based on image size and
        /// behavior settings.
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private WallpaperStyle DetermineImageStyle(Bitmap img)
        {
            Int32 imgW = img.Width, imgH = img.Height;
            Int32 desktopW = Screen.PrimaryScreen.Bounds.Width,
                desktopH = Screen.PrimaryScreen.Bounds.Height;

            WallpaperStyle style;

            if (imgW > desktopW || imgH > desktopH)
                style = LargeImageStyle;
            else if (imgW <= SpecialImageSize && imgH <= SpecialImageSize)
                style = SpecialImageStyle;
            else
                style = SmallImageStyle;


            return style;
        }
    }
}
