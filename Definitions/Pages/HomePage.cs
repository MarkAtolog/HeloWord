using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Definitions.Pages
{
    public class HomePage : Form
    {
        private const string StartLinkLocator = "//a[contains(@class, 'start__link')]";

        private ILink StartLink => ElementFactory.GetLink(By.XPath(StartLinkLocator), "Start link");

        public HomePage() : base(By.XPath(StartLinkLocator), "Home page") { }

        public void ClickStartLink()
        {
            StartLink.Click();
        }
    }
}
