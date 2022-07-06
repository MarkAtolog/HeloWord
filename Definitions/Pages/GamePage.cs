using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Definitions.Forms;
using OpenQA.Selenium;

namespace Definitions.Pages
{
    public class GamePage : Form
    {
        private const string TimerXPath = "//div[contains(@class, 'timer')]";

        private readonly ILabel Timer = ElementFactory.GetLabel(By.XPath(TimerXPath), "Timer");
        private static ILabel Title = ElementFactory.GetLabel(By.XPath("//head//title"), "Title", ElementState.ExistsInAnyState);

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

        public static string GetTitle()
        {
            return Title.GetText();
        }
    }
}
