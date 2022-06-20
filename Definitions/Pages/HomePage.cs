using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Definitions.Pages
{
    public class HomePage : Form
    {
        private static readonly By StartLinkLocator = By.XPath("//a[contains(@class,\"start__link\")]");
        public HomePage() : base(StartLinkLocator, "Home page")
        {
        }
        private ILink StartLink => ElementFactory.GetLink(StartLinkLocator, "Start link");

        public void ClickStartLink()
        {
            StartLink.Click();
        }
    }
}
