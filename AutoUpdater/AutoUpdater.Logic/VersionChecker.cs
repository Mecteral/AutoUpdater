using System.IO;
using System.Net;

namespace AutoUpdater.Logic
{
    public class VersionChecker
    {

        string mLocalVersion;
        string mRemoteVersionFile;
        string mUrlRemoteUpdateFile;
        string mPathToRemoteVerionsFile;

        public bool IsUpdateNeeded(string localVersionFile, string urlRemoteUpdateFile, string remoteVersionFile, string pathToRemoteVerionsFile)
        {
            mLocalVersion = localVersionFile;
            mRemoteVersionFile = remoteVersionFile;
            mUrlRemoteUpdateFile = urlRemoteUpdateFile;
            mPathToRemoteVerionsFile = pathToRemoteVerionsFile;
            return GetVersionFromFile() == GetVersionFromUpdateServer();
        }

        public string GetVersionFromUpdateServer()
        {
            var completeUpdatePath = mUrlRemoteUpdateFile + mRemoteVersionFile;
            using (var client = new WebClient())
            {
                client.DownloadFile(completeUpdatePath, mPathToRemoteVerionsFile);
            }
            return File.ReadAllText(mPathToRemoteVerionsFile);
        }

        string GetVersionFromFile()
        {
            return File.ReadAllText(mLocalVersion);
        }
    }
}