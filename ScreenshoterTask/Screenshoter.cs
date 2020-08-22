using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Drawing;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScreenshoterTask
{
    class Screenshoter
    {
        int[] _resolution;
        string _path;
        int _amountOfThreads;
        int _timeout;
        List<string> _inputLinks = new List<string>();
        Queue<string> _links = new Queue<string>();
        List<string> _logs = new List<string>();

        public Screenshoter(string resolution, string path, int amountOfThreads, int timeout, string links)
        {
            _resolution = GetResolution(resolution);
            _path = path;
            _amountOfThreads = amountOfThreads;
            _timeout = timeout;
            _inputLinks = (links.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)).ToList<string>();
            _inputLinks.ForEach(l => _links.Enqueue(l));
        }

        private int[] GetResolution(string resolution)
        {
            return (Array.ConvertAll(resolution.Split('x'), s => int.Parse(s)));
        }

        private void GetScreenshot(object callback)
        {
            if(_links.Count > 0)
            {
                
                IWebDriver driver = InitializeDriver();
                string input = _links.Dequeue();
                string url = GetURL(input);
                
                try
                {
                    driver.Url = url;
                    AddToLog(input, "is done.");
                }
                catch (Exception e)
                {
                    AddToLog(input, "is not reached.");
                }

                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(String.Format("{0}/{1}.png", _path, GetName(url)), ScreenshotImageFormat.Png);
                driver.Quit();
            }
        }

        private void AddToLog(string url, string result)
        {
            _logs.Add(url + " " + result);
        }

        private IWebDriver InitializeDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new FirefoxDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_timeout);
            driver.Manage().Window.Size = new Size(_resolution[0], _resolution[1] + 74);//delta high is 74 pxl
            return driver;
        }

        private string GetURL(string inputURL)
        {
            if (Regex.IsMatch(inputURL, @"^https?://"))
                return inputURL;
            else 
                return "https://" + inputURL;
        }

        private string GetName(string url)
        {
            return Regex.Match(url, @"^https?://(.+\.\w+)/").Groups[1].ToString();
        }

        public void GetAllScreenshots()
        {
       //     Console.WriteLine(ThreadPool.SetMaxThreads(_amountOfThreads, _amountOfThreads));
            Console.WriteLine(ThreadPool.SetMinThreads(_amountOfThreads, _amountOfThreads));

            for (int i = 0; i < _inputLinks.Count; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(GetScreenshot));
            }

        }

        public IList<string> GetLogs()
        {
            return _logs;
        }
    }
}
