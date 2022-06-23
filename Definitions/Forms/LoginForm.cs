using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Definitions.Forms
{
    public class LoginForm : Form
    {
        private const string OtherZone = "other";
        private const string DomainZoneSelectXPath = "//div[contains(@class, 'dropdown__list-item') and contains(text(), '{0}')]";
        private const string TextBoxXPath = "//input[contains(@Placeholder,'{0}')]";

        private readonly ITextBox PasswordTextBox = ElementFactory.GetTextBox(By.XPath(string.Format(TextBoxXPath, "Password")), "Password");
        private readonly ITextBox EmailTextBox = ElementFactory.GetTextBox(By.XPath(string.Format(TextBoxXPath, "email")), "Email");
        private readonly ITextBox EmailDomainTextBox = ElementFactory.GetTextBox(By.XPath(string.Format(TextBoxXPath, "Domain")), "Email domain");
        private readonly IButton ShowEmailDomainZonesButton = ElementFactory.GetButton(By.XPath("//div[contains(@class, 'dropdown__header')]"), "Show domain zones");
        private readonly IButton NextButton = ElementFactory.GetButton(By.XPath("//a[contains(text(), 'Next')]"), "Next");
        private readonly ICheckBox AcceptTermsConditions = ElementFactory.GetCheckBox(By.XPath("//span[contains(@class, 'checkbox__box')]"), "Accept terms and conditions");

        public LoginForm() : base(By.XPath("//form"), "Login form") { }

        public void EnterPassword(string password)
        {
            PasswordTextBox.ClearAndType(password);
        }

        public void EnterEmailName(string emailName)
        {
            EmailTextBox.ClearAndType(emailName);
        }

        public void EnterEmailDomain(string domain)
        {
            EmailDomainTextBox.ClearAndType(domain);
        }

        public void SelectRandomEmailDomainZone()
        {
            Random random = new();
            ExpandEmailDomainZoneList();

            var emailDomainZones = ElementFactory.FindElements<IButton>(By.XPath(string.Format(DomainZoneSelectXPath, "")), "Email domain zone");

            var zone = emailDomainZones[random.Next(emailDomainZones.Count)];

            if (zone.Text.Contains(OtherZone))
            {
                emailDomainZones.Remove(zone);
                zone = emailDomainZones[random.Next(emailDomainZones.Count)];
            }

            zone.Click();
        }

        public void SelectEmailDomainZone(string domainZone)
        {
            IElement EmailDomainZoneSelect = ElementFactory.GetButton(By.XPath(string.Format(DomainZoneSelectXPath, domainZone)), "Email domain zone");
            EmailDomainZoneSelect.Click();
        }

        public void AcceptTermsAndConditions()
        {
            AcceptTermsConditions.Click();
        }

        public void SubmitForm()
        {
            NextButton.Click();
        }

        private void ExpandEmailDomainZoneList()
        {
            ShowEmailDomainZonesButton.Click();
        }
    }
}
