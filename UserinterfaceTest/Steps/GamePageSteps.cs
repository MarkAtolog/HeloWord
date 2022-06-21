using Definitions.Pages;

namespace UserinterfaceTest.Steps
{
    public class GamePageSteps
    {
        private GamePage GamePage;

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

        public void FillInFirstCard(string password, string emailName, string emailDomain)
        {
            GamePage.LoginForm.EnterPassword(password);
            GamePage.LoginForm.EnterEmailName(emailName);
            GamePage.LoginForm.EnterEmailDomain(emailDomain);
            GamePage.LoginForm.ExpandEmailDomainZoneList();
            GamePage.LoginForm.SelectRandomEmailDomainZone();
            GamePage.LoginForm.AcceptTermsAndConditions();
            GamePage.LoginForm.SubmitForm();
        }

        public void AssertSecondCardOpened()
        {
            Assert.IsTrue(GamePage.AvatarInterestsForm.State.IsExist);
        }

        public void FillInSecondCard(string testImage)
        {
            GamePage.AvatarInterestsForm.DownloadImage(testImage);
            GamePage.AvatarInterestsForm.UnselectAllInterests();
            GamePage.AvatarInterestsForm.SelectRandomInterest();
            GamePage.AvatarInterestsForm.UploadAvatar(testImage);
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
