using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Framework.Utils;
using Aquality.Selenium.Core.Elements;

namespace Definitions.Forms
{
    public class AvatarInterestsForm : Form
    {
        private const string ListItemXPath = "//div[contains(@class, 'list__item')]";
        private const string CheckBoxXPath = "//span[contains(@class,'checkbox__box')]";
        private const string UnselectXPath = "//div[contains(normalize-space(.), 'Unselect all')]";

        private readonly ICheckBox UnselectAll = ElementFactory.GetCheckBox(By.XPath(ListItemXPath + UnselectXPath + CheckBoxXPath), "Unselect");
        private readonly IButton Next = ElementFactory.GetButton(By.XPath("//button[contains(text(), 'Next')]"), "Next");
        private readonly IButton Download = ElementFactory.GetButton(By.XPath("//button[contains(text(), 'Download')]"), "Download avatar");
        private readonly ILink Upload = ElementFactory.GetLink(By.XPath("//a[contains(@class, 'upload-button')]"), "Upload avatar");
        private readonly ILabel Error = ElementFactory.GetLabel(By.XPath("//li[contains(@class, 'avatar-and-interests__error')]"), "Error");

        public AvatarInterestsForm() : base(By.XPath("//div[contains(@class,'avatar-and-interests__form')]"), "Avatar and interests form") { }

        private IList<ICheckBox> GetInterestsList()
        {
            List<ICheckBox> interests = new();
            IList<ICheckBox> items = ElementFactory.FindElements<ICheckBox>(By.XPath(ListItemXPath));

            foreach (var item in items)
            {
                if (item.GetText().Contains(" all") || item.FindChildElement<ICheckBox>(By.TagName("input"), "Input", state: ElementState.ExistsInAnyState).IsChecked)
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

        public void SelectRandomInterests(int count)
        {
            Random random = new();
            IList<ICheckBox> interests = GetInterestsList();
            for (int i = 0; i < count; i++)
            {
                var checkBox = interests[random.Next(interests.Count)];
                checkBox.Click();
                interests.Remove(checkBox);
            }
        }

        public void DownloadImage()
        {
            Download.Click();
        }

        public void UploadAvatar(string testImage)
        {
            Upload.Click();
            FileUtils.UploadFile(testImage);
        }

        public void SubmitForm()
        {
            Next.Click();

            if (State.IsExist)
            {
                ConditionalWait.WaitFor(f => !Error.State.IsExist);
                Next.Click();
            }
        }
    }
}
