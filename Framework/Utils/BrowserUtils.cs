using Aquality.Selenium.Browsers;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace Framework.Utils
{
    public class BrowserUtils
    {
        private readonly Browser Browser;

        public BrowserUtils()
        {
            Browser = AqualityServices.Browser;
        }

        public string BrowserName => Browser.BrowserName.ToString();

        public string DownloadDirectory => Browser.DownloadDirectory;

        public string CurrentUrl => Browser.CurrentUrl;

        public DevToolsHandling DevTools => Browser.DevTools;

        public void SaveScreenshot(string testName)
        {
            var screenshot = Browser.GetScreenshot();
            string imagePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"../../../../{testName}_screenshot.png");
            using (Image image = Image.FromStream(new MemoryStream(screenshot)))
            {
                image.Save(imagePath, ImageFormat.Png);
            }
        }

        public void Quit() => Browser.Quit();

        public void GoTo(string url)
        {
            Browser.GoTo(url);
        }

        public void GoBack()
        {
            Browser.GoBack();
        }

        public void GoForward()
        {
            Browser.GoForward();
        }

        public void RefreshPageWithAlert(AlertAction alertAction)
        {
            Browser.RefreshPageWithAlert(alertAction);
        }

        public void Refresh()
        {
            Browser.Refresh();
        }

        public void HandleAlert(AlertAction alertAction, string text = null)
        {
            Browser.HandleAlert(alertAction, text);
        }

        public void Maximize()
        {
            Browser.Maximize();
        }

        public void WaitForPageToLoad()
        {
            Browser.WaitForPageToLoad();
        }

        public byte[] GetScreenshot()
        {
            return Browser.GetScreenshot();
        }

        public void ScrollWindowBy(int x, int y)
        {
            Browser.ScrollWindowBy(x, y);
        }

        public void ExecuteScriptFromFile(string embeddedResourcePath, params object[] arguments)
        {
            Browser.ExecuteScriptFromFile(embeddedResourcePath, arguments);
        }

        public T ExecuteScriptFromFile<T>(string embeddedResourcePath, params object[] arguments)
        {
            return Browser.ExecuteScript<T>(embeddedResourcePath, arguments);
        }

        public void ExecuteScript(JavaScript scriptName, params object[] arguments)
        {
            Browser.ExecuteScript(scriptName, arguments);
        }

        public void ExecuteScript(string script, params object[] arguments)
        {
            Browser.ExecuteScript(script, arguments);
        }

        public T ExecuteScript<T>(JavaScript scriptName, params object[] arguments)
        {
            return Browser.ExecuteScript<T>(scriptName, arguments);
        }

        public T ExecuteScript<T>(string script, params object[] arguments)
        {
            return Browser.ExecuteScript<T>(script, arguments);
        }

        public object ExecuteAsyncScriptFromFile(string embeddedResourcePath, params object[] arguments)
        {
            return Browser.ExecuteAsyncScriptFromFile(embeddedResourcePath, arguments);
        }

        public object ExecuteAsyncScript(JavaScript scriptName, params object[] arguments)
        {
            return Browser.ExecuteAsyncScript(scriptName, arguments);
        }

        public object ExecuteAsyncScript(string script, params object[] arguments)
        {
            return Browser.ExecuteAsyncScript(script, arguments);
        }

        public void SetWindowSize(int width, int height)
        {
            Browser.SetWindowSize(width, height);
        }
    }
}
