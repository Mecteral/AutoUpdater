using System.Net;

namespace AutoUpdater.Logic
{
    public class UpdateDownloader
    {
        public void DownloadUpdateTo(string pathToUpdateFile, string urlToUpdateFile, string updateFileName)
        {
            var completeUpdatePath = urlToUpdateFile + updateFileName;
            using (var client = new WebClient())
            {
                client.DownloadFile(completeUpdatePath, pathToUpdateFile);
            }
        }
    }
}