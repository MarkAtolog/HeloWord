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
            foreach (var a in autoit.WinList(UploadWindow))
                Console.WriteLine(a);
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
