using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Definitions.Forms
{
    public class HelpForm : Form
    {
        private static IButton HideHelpButton => ElementFactory.GetButton(By.XPath("//button[contains(@class, 'send-to-bottom-button')]"), "Hide help");
        private static ILabel HelpFormTitle => ElementFactory.GetLabel(By.XPath("//h2[contains(@class, 'help-form__title')]"), "Help form title");

        public HelpForm() : base(By.XPath("//div[contains(@class, 'help-form')]"), "Personal details") { }

        public void HideHelp()
        {
            HideHelpButton.Click();
            ConditionalWait.WaitFor(f => IsHelpFormContentHidden());
        }

        public bool IsHelpFormContentHidden()
        {
            return !HelpFormTitle.State.IsDisplayed;
        }
    }
}
