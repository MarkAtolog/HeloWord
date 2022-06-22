using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Definitions.Forms
{
    public class LoginForm : Form
    {
        private const string OtherZone = "other";
        private const string DomainZoneSelectXPath = "//div[contains(@class, 'dropdown__list-item') and contains(text(), '{0}')]";

        private readonly ITextBox PasswordInput = ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder, 'Password')]"), "Password");
        private readonly ITextBox EmailInput = ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder, 'email')]"), "Email");
        private readonly ITextBox EmailDomainInput = ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder, 'Domain')]"), "Email domain");
        private readonly IButton EmailDomainZoneList = ElementFactory.GetButton(By.XPath("//div[contains(@class, 'dropdown__header')]"), "Dropdown domain zone");
        private readonly ICheckBox AcceptTermsConditions = ElementFactory.GetCheckBox(By.XPath("//span[contains(@class, 'checkbox__box')]"), "Accept terms and conditions");
        private readonly ILink Next = ElementFactory.GetLink(By.XPath("//a[contains(text(), 'Next')]"), "Next");

        public LoginForm() : base(By.XPath("//form"), "Login form") { }

        public void EnterPassword(string password)
        {
            PasswordInput.ClearAndType(password);
        }

        public void EnterEmailName(string emailName)
        {
            EmailInput.ClearAndType(emailName);
        }

        public void EnterEmailDomain(string domain)
        {
            EmailDomainInput.ClearAndType(domain);
        }

        public void ExpandEmailDomainZoneList()
        {
            EmailDomainZoneList.Click();
        }

        public void SelectRandomEmailDomainZone()
        {
            Random random = new();
            IList<IButton> emailDomainZones = ElementFactory.FindElements<IButton>(By.XPath(string.Format(DomainZoneSelectXPath, "")), "Email domain zone");

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
            Next.Click();
        }
    }
}
