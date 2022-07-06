using Aquality.Selenium.Browsers;
using AutoItX3Lib;
using Definitions.Pages;

namespace Framework.Utils
{
    public class FileUtils
    {
        public static void UploadFile(string path)
        {
            string UploadWindow = "Open";
            string FileNameField = "Edit1";
            string SubmitButton = "Button1";

            BrowserUtils BrowserUtils = new();
            AutoItX3 autoit = new();

            string FileName = Path.Combine(AqualityServices.Browser.DownloadDirectory, path);

            autoit.WinActivate(GamePage.GetTitle() + " - " + BrowserUtils.BrowserName);
            autoit.WinActivate(UploadWindow);
            autoit.ControlFocus(UploadWindow, string.Empty, FileNameField);
            autoit.ControlSetText(UploadWindow, string.Empty, FileNameField, FileName);
            autoit.ControlClick(UploadWindow, string.Empty, SubmitButton);
        }

        public static void CleanDownloadDirectory()
        {
            if (Directory.Exists(AqualityServices.Browser.DownloadDirectory))
            {
                Directory.Delete(AqualityServices.Browser.DownloadDirectory, true);
            }
        }
    }
}
