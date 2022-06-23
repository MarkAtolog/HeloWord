using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Definitions.Forms
{
    public class CookiesForm : Form
    {
        private readonly IButton AcceptButton = ElementFactory.GetButton(By.XPath("//button[contains(text(), 'Not really, no')]"), "Accept cookies");
        
        public CookiesForm() : base(By.XPath("//div[contains(@class, 'cookies')]"), "Cookies") { }

        public void AcceptCookies()
        {
            AcceptButton.WaitAndClick();
        }
    }
}
