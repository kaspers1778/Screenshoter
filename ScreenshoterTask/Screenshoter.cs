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

        public void GetScreenshot(object callback)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new FirefoxDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_timeout);
            driver.Manage().Window.Size = new Size(_resolution[0],_resolution[1] + 74);//delta high is 74 pxl
            string url = "https://" + _links.Dequeue();
            driver.Url = url;
            string name = Regex.Replace(url, @"[^0-9a-zA-Z:.]+", "");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(_path + "/"+name+".png", ScreenshotImageFormat.Png);
            driver.Quit();
        }

        public void GetAllScreenshots()
        {
            ThreadPool.SetMinThreads(_amountOfThreads, _amountOfThreads);

            for (int i = 0; i < _inputLinks.Count; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(GetScreenshot));
            }
        }
    }
}
