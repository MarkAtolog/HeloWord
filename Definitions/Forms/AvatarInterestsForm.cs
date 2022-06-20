using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using AutoItX3Lib;
using OpenQA.Selenium;

namespace Definitions.Forms
{
    public class AvatarInterestsForm : Form
    {
        public AvatarInterestsForm() : base(By.XPath("//div[contains(@class,\"avatar-and-interests__form\")]"), "Avatar and interests form") { }

        private static string CheckBoxXPath = "//span[contains(@class,'checkbox__box')]";
        private static ICheckBox UnselectAll => ElementFactory.GetCheckBox(By.XPath("//div[contains(@class, 'list__item') and contains(normalize-space(.), 'Unselect all')]" + CheckBoxXPath), "Unselect");
        private static IButton Download => ElementFactory.GetButton(By.XPath("//button[contains(., 'Download')]"), "Download");
        private static ILink Upload => ElementFactory.GetLink(By.XPath("//a[contains(@class, 'upload-button')]"), "Upload");
        private static ILabel Error => ElementFactory.GetLabel(By.XPath("//li[contains(@class, 'avatar-and-interests__error')]"), "Error");
        private static IButton Next => ElementFactory.GetButton(By.XPath("//button[contains(., 'Next')]"), "Next");
        private IList<ICheckBox> GetInterestsList()
        {
            List<ICheckBox> interests = new();
            IList<ICheckBox> items = ElementFactory.FindElements<ICheckBox>(By.XPath("//div[contains(@class, 'list__item')]"));

            foreach (var item in items)
            {
                if (item.GetText().Contains(" all"))
                    continue;
                else
                    interests.Add(item.FindChildElement<ICheckBox>(By.XPath(CheckBoxXPath)));
            }
            return interests;
        }

        public void UnselectAllInterests()
        {
            UnselectAll.Click();
        }
        public void SelectRandomInterests(int count = 3)
        {
            Random random = new Random();
            IList<ICheckBox> interests = GetInterestsList();
            for (int i = 0; i < count; i++)
            {
                var checkBox = interests[random.Next(interests.Count)];
                checkBox.Click();
                interests.Remove(checkBox);
            }
        }

        public void DownloadImage(string testImage)
        {
            Download.Click();
            ConditionalWait.WaitFor(f => Directory.GetFiles(AqualityServices.Browser.DownloadDirectory).Contains(testImage));
        }

        public void UploadAvatar(string testImage)
        {
            Upload.Click();
            AutoItX3 autoit = new();
            autoit.WinWaitActive("Open");
            autoit.ControlFocus("Open", "", "Edit1");
            autoit.ControlSetText("Open", "", "Edit1", Path.Combine(AqualityServices.Browser.DownloadDirectory, testImage));
            autoit.ControlClick("Open", "", "Button1");

        }

        public void SubmitForm()
        {
            Next.Click();

            if (this.State.IsExist)
            {
                ConditionalWait.WaitFor(f => !Error.State.IsExist);
                Next.Click();
            }
        }
    }
}
