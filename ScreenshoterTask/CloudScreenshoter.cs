using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ScreenshoterTask
{
    class CloudScreenshoter
    {
        private readonly string ApiKey = "23c9367d-4385-4615-910e-b5c082d425e5";
        private readonly string ApiSecret = "2kniOx1wJ18psbhVIGP6WdfBYraux2sED7eMPHjpSGg2kDgB3i";
        int[] _resolution;
        string _path;
        int _amountOfThreads;
        int _timeout;
        List<string> _inputLinks = new List<string>();
        ConcurrentQueue<string> _links = new ConcurrentQueue<string>();
        List<string> _logs = new List<string>();
        Dictionary<string, string> options = new Dictionary<string, string>();

        public CloudScreenshoter(string resolution, string path, int amountOfThreads, int timeout, string links)
        {
            _resolution = GetResolution(resolution);
            _path = path;
            _amountOfThreads = amountOfThreads;
            _timeout = timeout;
            _inputLinks = (links.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)).ToList<string>();
            _inputLinks.ForEach(l => _links.Enqueue(l));

            options.Add("width", _resolution[0].ToString());
            options.Add("viewport_height","("+ _resolution[1].ToString() + ")");
            options.Add("delay", _timeout.ToString());
            options.Add("force", "true");
            options.Add("format", "png");
          //  options.Add("full_page", "true");

        }

        private int[] GetResolution(string resolution)
        {
            return (Array.ConvertAll(resolution.Split('x'), s => int.Parse(s)));
        }

        private void GetScreenshot()
        {
            var input = "";
            while (_links.TryDequeue(out input))
            {
                Screenshotscloud screenshotscloud = new Screenshotscloud(ApiKey, ApiSecret);
                try
                {
                    
                    Dictionary<string, string> concreteOptions = options;
                    concreteOptions.Remove("url");
                    concreteOptions.Add("url", GetURL(input));

                    string result = screenshotscloud.screenshotUrl(options);

                    string localFilename = String.Format("{0}/{1}.png", _path, GetName(GetURL(input)));
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(result, localFilename);
                    }
                    concreteOptions.Remove("url");

                    AddToLog(input,"is Screensoted");
                }
                catch
                {
                    AddToLog(input, "could not be screenshoted.");
                }
            }
        }

        private string GetURL(string inputURL)
        {
            if (Regex.IsMatch(inputURL, @"^https?://"))
                return inputURL;
            else
                return "https://" + inputURL + "/";
        }

        private string GetName(string url)
        {
            return Regex.Match(url, @"^https?://(.+\.[a-zA-Z]+)/").Groups[1].ToString();
        }

        public void GetAllScreenshots()
        {
            int threadCount = _amountOfThreads;
            for (int i = 0; i < threadCount; i++)
                new Thread(GetScreenshot) { IsBackground = true }.Start();
        }

        private void AddToLog(string url, string result)
        {
            _logs.Add(url + " " + result);
            
        }

        public List<string> GetLogs()
        {
            return _logs;
        }

        public int GetAmountOfURLs()
        {
            return _inputLinks.Count();
        }
    }
}
