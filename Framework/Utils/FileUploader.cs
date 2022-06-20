using Aquality.Selenium.Browsers;
using AutoItX3Lib;

namespace Framework.Utils
{
    public class FileUploader
    {
        private static string UploadWindow = "Open";
        private static string FileNameField = "Edit1";
        private static string SubmitButton = "Button1";
        public static void UploadFile(string path)
        {
            string FileName = Path.Combine(AqualityServices.Browser.DownloadDirectory, path);
            AutoItX3 autoit = new();
            autoit.WinWaitActive(UploadWindow);
            autoit.ControlFocus(UploadWindow, "", FileNameField);
            autoit.ControlSetText(UploadWindow, "", FileNameField, FileName);
            autoit.ControlClick(UploadWindow, "", SubmitButton);
        }
    }
}
