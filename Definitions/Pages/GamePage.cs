using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Definitions.Forms;
using OpenQA.Selenium;

namespace Definitions.Pages
{
    public class GamePage : Form
    {
        private static readonly string TimerXPath = "//div[contains(@class,\"timer\")]";

        private ILabel Timer => ElementFactory.GetLabel(By.XPath(TimerXPath), "Timer");
        public GamePage() : base(By.XPath(TimerXPath), "Game page") { }
        public LoginForm LoginForm = new();
        public AvatarInterestsForm AvatarInterestsForm = new();
        public PersonalDetailsForm PersonalDetailsForm = new();
        public HelpForm HelpForm = new();
        public CookiesForm CookiesForm = new();

        public string GetTimer()
        {
            return Timer.GetText();
        }
    }
}
