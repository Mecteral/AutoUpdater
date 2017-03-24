using System.Net;

namespace AutoUpdater.Logic
{
    public class InternetConnectivityChecker
    {
        public bool CheckConnectionTo(string server)
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead(server))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                //Create Log for server connectivity failure
                return false;
            }
        }
    }
}