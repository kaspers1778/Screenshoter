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
using System.Collections.Concurrent;

namespace ScreenshoterTask
{
    class Screenshoter
    {
        int[] _resolution;
        string _path;
        int _amountOfThreads;
        int _timeout;
        List<string> _inputLinks = new List<string>();
        ConcurrentQueue<string> _links = new ConcurrentQueue<string>();
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

        private void GetScreenshot()
        {
            var input = "";
            while (_links.TryDequeue(out input))
            {                
                IWebDriver driver = InitializeDriver();
                string url = GetURL(input);
                try
                {
                    driver.Url = url;
                    AddToLog(input, " is done.");
                    ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(String.Format("{0}/{1}.png", _path, GetName(url)), ScreenshotImageFormat.Png);
                }
                catch (WebDriverTimeoutException tex)
                {
                    AddToLog(input, " timeout of loading is over.");
                }
                catch (WebDriverException wex)
                {
                    AddToLog(input, " reached EROR page.");
                }
                catch (InvalidOperationException)
                {
                    AddToLog(input, " has unsecure sertificate.");
                }
                catch
                {
                    AddToLog(input, "can't be done");
                }
                finally
                {
                    driver.Quit();
                }
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
            var serv = FirefoxDriverService.CreateDefaultService();
            serv.HideCommandPromptWindow = true;
            IWebDriver driver = new FirefoxDriver(serv,options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_timeout);
            
            driver.Manage().Window.Size = new Size(_resolution[0], _resolution[1] + 74);//delta high is 74 pxl
            return driver;
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
             for(int i = 0;i<threadCount;i++)
                new Thread(GetScreenshot) {IsBackground = true }.Start();
        }

        public IList<string> GetLogs()
        {
            return _logs;
        }

        public int GetAmountOfURLs()
        {
            return _inputLinks.Count();
        }
    }
}
