using Aquality.Selenium.Browsers;
using Definitions.Pages;

namespace UserinterfaceTest.Steps
{
    public class GamePageSteps
    {
        private readonly GamePage GamePage;

        public GamePageSteps(GamePage gamePage)
        {
            GamePage = gamePage;
        }

        public void AssertFirstCardOpened()
        {
            Assert.IsTrue(GamePage.LoginForm.State.IsExist);
        }

        public void AssertGamePageOpened()
        {
            Assert.IsTrue(GamePage.State.IsExist);
        }

        public void FillInUserCredentials(string password, string emailName, string emailDomain)
        {
            GamePage.LoginForm.EnterPassword(password);

            GamePage.LoginForm.EnterEmailName(emailName);
            GamePage.LoginForm.EnterEmailDomain(emailDomain);
            GamePage.LoginForm.ExpandEmailDomainZoneList();
            GamePage.LoginForm.SelectRandomEmailDomainZone();
        }

        public void SubmitFirstCard()
        {
            GamePage.LoginForm.AcceptTermsAndConditions();
            GamePage.LoginForm.SubmitForm();
        }

        public void AssertSecondCardOpened()
        {
            Assert.IsTrue(GamePage.AvatarInterestsForm.State.IsExist);
        }

        public void SelectInterests(int numberOfInterests = 3)
        {
            GamePage.AvatarInterestsForm.UnselectAllInterests();
            GamePage.AvatarInterestsForm.SelectRandomInterests(numberOfInterests);
        }

        public void UploadAvatar(string testImage)
        {
            GamePage.AvatarInterestsForm.DownloadImage();
            AqualityServices.ConditionalWait.WaitFor(f => Directory.Exists(AqualityServices.Browser.DownloadDirectory));
            AqualityServices.ConditionalWait.WaitFor(f => File.Exists(Path.Combine(AqualityServices.Browser.DownloadDirectory, testImage)));
            GamePage.AvatarInterestsForm.UploadAvatar(testImage);
        }

        public void SubmitSecondCard()
        {
            GamePage.AvatarInterestsForm.SubmitForm();
        }

        public void AssertThirdCardOpened()
        {
            Assert.IsTrue(GamePage.PersonalDetailsForm.State.IsExist);
        }

        public void AcceptCookies()
        {
            GamePage.CookiesForm.AcceptCookies();
        }

        public void AssertCookiesFormClosed()
        {
            Assert.IsTrue(!GamePage.CookiesForm.State.IsExist);
        }

        public void HideHelp()
        {
            GamePage.HelpForm.HideHelp();
            AqualityServices.ConditionalWait.WaitFor(f => GamePage.HelpForm.IsHelpFormContentHidden());
        }

        public void AssertHelpFormHidden()
        {
            Assert.IsTrue(GamePage.HelpForm.IsHelpFormContentHidden());
        }

        public void AssertTimerStart(string time)
        {
            string timer = GamePage.GetTimer();
            Assert.IsTrue(timer.EndsWith(time));
        }
    }
}
