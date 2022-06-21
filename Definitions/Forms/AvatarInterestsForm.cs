using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Framework.Utils;

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
        public void SelectRandomInterest(int count = 3)
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
            string downloadDir = AqualityServices.Browser.DownloadDirectory;
            string imagePath = Path.Combine(downloadDir, testImage);

            Download.Click();

            ConditionalWait.WaitFor(f => Directory.Exists(downloadDir));
            ConditionalWait.WaitFor(f => Directory.GetFiles(downloadDir).Contains(imagePath));
        }

        public void UploadAvatar(string testImage)
        {
            Upload.Click();
            FileUploader.UploadFile(testImage);
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
