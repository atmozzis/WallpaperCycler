using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WallpaperCycler
{
    public enum WallpaperStyle
    {
        Center,
        Tile,
        Stretch
    }

    class Helper
    {
        private const String RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const String FILE_FILTER = ".jpg .bmp .gif";
        private const Int32 SPI_SETDESKWALLPAPER = 20;
        private const Int32 SPIF_UPDATEINIFILE = 0x01;
        private const Int32 SPIF_SENDWININICHANGE = 0x02;

        private static Random rnd = new Random();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(
            int uAction, int uParam, string lpvParam, int fuWinIni);

        /// <summary>
        /// Gets the Application Name
        /// </summary>
        public static String ApplicationName
        {
            get { return Application.ProductName; }
        }


        /// <summary>
        /// Gets the Applicaition's Executable Path
        /// </summary>
        public static String ApplicationPath
        {
            get { return Assembly.GetExecutingAssembly().Location; ;}
        }

        /// <summary>
        /// Gets the UserData FilePath
        /// </summary>
        private static String LocalWallpaperPath
        {
            get
            {
                String LoadPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                String DataFileName = Environment.UserName + ".wall";
                return Path.Combine(LoadPath, DataFileName);
            }
        }


        /// <summary>
        /// Sets the autostart value for the assembly.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        /// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>
        private static void SetAutoStart(String keyName, String assemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.SetValue(keyName, assemblyLocation);
        }

        /// <summary>
        /// Returns whether auto start is enabled.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        /// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>
        private static bool IsAutoStartEnabled(String keyName, String assemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
            if (key == null)
                return false;

            String value = (String)key.GetValue(keyName);
            if (value == null)
                return false;

            return (value == assemblyLocation);
        }

        /// <summary>
        /// Unsets the autostart value for the assembly.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        private static void UnSetAutoStart(String keyName)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.DeleteValue(keyName);
        }

        public static void SetAutoStart()
        {
            SetAutoStart(ApplicationName, ApplicationPath);
        }

        public static bool IsAutoStartEnabled()
        {
            return IsAutoStartEnabled(ApplicationName, ApplicationPath);
        }

        public static void UnSetAutoStart()
        {
            UnSetAutoStart(ApplicationName);
        }

        public static void ClearDesktopBackground()
        {
            // Clear the current background (releases lock on current bitmap)
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, "", SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public static void SetDesktopBackground(Bitmap img, WallpaperStyle style)
        {
            // Clear the current background (releases lock on current bitmap)
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, "", SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

            // Convert to BMP and save)
            img.Save(LocalWallpaperPath,
                  System.Drawing.Imaging.ImageFormat.Bmp);

            //Write style info to registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);

            switch (style)
            {
                case WallpaperStyle.Center:
                    key.SetValue(@"WallpaperStyle", "0");
                    key.SetValue(@"TileWallpaper", "0");
                    break;

                case WallpaperStyle.Tile:
                    key.SetValue(@"WallpaperStyle", "1");
                    key.SetValue(@"TileWallpaper", "1");
                    break;

                case WallpaperStyle.Stretch:
                    key.SetValue(@"WallpaperStyle", "2");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, LocalWallpaperPath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public static List<String> ProcessDirectory(String Dir, Boolean CheckSubFolders, Int32 ReturnFileCount)
        {
            if (!Directory.Exists(Dir))
            {
                return null;
            }

            // Specify top-level or sub-folders
            SearchOption opt = SearchOption.TopDirectoryOnly;
            if (CheckSubFolders) opt = SearchOption.AllDirectories;

            // Grab complete list of files
            string[] files = System.IO.Directory.GetFiles(Dir, "*", opt);
            if (files.Length == 0)
            {
                return null;
            }

            // Filter list to remove non-images, last image shown,
            // and the app-generated BMP file from a previous run.
            List<String> filteredFiles = new List<String>();
            foreach (String file in files)
            {
                String ext = file.Substring(file.LastIndexOf("."));

                if (".jpg .bmp .gif".IndexOf(ext) > -1)
                {
                    filteredFiles.Add(file);
                }
            }

            // Make sure there are any files left
            if (filteredFiles.Count == 0)
            {
                return null;
            }

            List<String> Return = new List<String>();
            for (int i = (ReturnFileCount <= filteredFiles.Count) ? ReturnFileCount : filteredFiles.Count; i > 0; i--)
            {
                // Randomly grab a file
                String filename = filteredFiles[rnd.Next(filteredFiles.Count)];
                while (Return.Contains(filename))
                {
                    filename = filteredFiles[rnd.Next(filteredFiles.Count)];
                }
                Return.Add(filename);
                filteredFiles.Remove(filename);
            }

            // Return the bitmap object from this filename
            return Return;
        }
    }
}
