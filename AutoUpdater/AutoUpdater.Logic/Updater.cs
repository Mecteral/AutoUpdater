using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace AutoUpdater.Logic
{
    public class Updater
    {
        const string CalculatorExeFileName = "";

        const string PathToLocalUpdateFile = "C:\\Users\\Public";

        const string UrlToUpdateFile = "";
        const string UpdateFileName = "Calculator.zip";

        const string PathToLocalVersionFile = "C:\\Users\\Public";

        const string UrlToVersionFile = "";
        const string VersionFileName = "UpdateVerion.xml";
        const string PathToRemoteVersionFile = "";

        readonly UpdateDownloader mUpdateDownloader;
        readonly VersionChecker mVersionChecker;

        public Updater()
        {
            mVersionChecker = new VersionChecker();
            mUpdateDownloader = new UpdateDownloader();
        }

        public void Update()
        {
            if (mVersionChecker.IsUpdateNeeded(PathToLocalVersionFile, UrlToVersionFile, VersionFileName, PathToRemoteVersionFile))
            {
                mUpdateDownloader.DownloadUpdateTo(PathToLocalUpdateFile, UrlToUpdateFile, UpdateFileName);
                ApplyUpdate();
                RemoveUpdateFiles();
                StartCalculator();
            }
        }

        static void RemoveUpdateFiles()
        {
            File.Delete(PathToLocalUpdateFile + UpdateFileName);
            File.Delete(PathToRemoteVersionFile + VersionFileName);
        }

        public void StartCalculator()
        {
            try
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + CalculatorExeFileName);
                Environment.Exit(-1);
            }
            catch
            {
                //Log Error
            }
        }

        static void ApplyUpdate()
        {
            ZipFile.ExtractToDirectory(PathToLocalUpdateFile + UpdateFileName, AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}