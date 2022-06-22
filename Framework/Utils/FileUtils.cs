using Aquality.Selenium.Browsers;
using AutoItX3Lib;

namespace Framework.Utils
{
    public class FileUtils
    {
        public static void UploadFile(string path)
        {
            string UploadWindow = "Open";
            string FileNameField = "Edit1";
            string SubmitButton = "Button1";

            string FileName = Path.Combine(AqualityServices.Browser.DownloadDirectory, path);

            AutoItX3 autoit = new();

            autoit.WinWaitActive(UploadWindow);
            autoit.ControlFocus(UploadWindow, "", FileNameField);
            autoit.ControlSetText(UploadWindow, "", FileNameField, FileName);
            autoit.ControlClick(UploadWindow, "", SubmitButton);
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
