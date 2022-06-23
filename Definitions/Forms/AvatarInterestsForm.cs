using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Core.Elements;

namespace Definitions.Forms
{
    public class AvatarInterestsForm : Form
    {
        private const string ListItemXPath = "//div[contains(@class, 'list__item')]";
        private const string CheckBoxXPath = "//span[contains(@class,'checkbox__box')]";
        private const string UnselectXPath = "//div[contains(normalize-space(.), 'Unselect all')]";

        private readonly IButton UnselectAllButton = ElementFactory.GetButton(By.XPath(ListItemXPath + UnselectXPath + CheckBoxXPath), "Unselect all");
        private readonly IButton NextButton = ElementFactory.GetButton(By.XPath("//button[contains(text(), 'Next')]"), "Next");
        private readonly IButton DownloadButton = ElementFactory.GetButton(By.XPath("//button[contains(text(), 'Download')]"), "Download avatar");
        private readonly ILink UploadButton = ElementFactory.GetLink(By.XPath("//a[contains(@class, 'upload-button')]"), "Upload avatar");
        private readonly ILabel ErrorLabel = ElementFactory.GetLabel(By.XPath("//li[contains(@class, 'avatar-and-interests__error')]"), "Error");

        public AvatarInterestsForm() : base(By.XPath("//div[contains(@class,'avatar-and-interests__form')]"), "Avatar and interests form") { }

        public void UnselectAllInterests()
        {
            UnselectAllButton.Click();
        }

        public void SelectRandomInterests(int count)
        {
            Random random = new();
            var interests = GetInterestsList();
            for (int i = 0; i < count; i++)
            {
                var checkBox = interests[random.Next(interests.Count)];
                checkBox.Click();
                interests.Remove(checkBox);
            }
        }

        public void ClickDownloadImage()
        {
            DownloadButton.Click();
        }

        public void ClickUploadAvatar()
        {
            UploadButton.Click();
        }

        public void SubmitForm()
        {
            NextButton.Click();

            if (State.IsExist)
            {
                ConditionalWait.WaitFor(f => !ErrorLabel.State.IsExist);
                NextButton.Click();
            }
        }

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
    }
}
