using Definitions.Pages;

namespace UserinterfaceTest.Steps
{
    class GamePageSteps
    {
        private static GamePage gamePage = new();

        public void AssertFirstCardOpened()
        {
            Assert.IsTrue(gamePage.LoginForm.State.IsExist);
        }

        public void AssertGamePageOpened()
        {
            Assert.IsTrue(gamePage.State.IsExist);
        }

        public void FillInFirstCard(string password, string emailName, string emailDomain)
        {
            gamePage.LoginForm.EnterPassword(password);
            gamePage.LoginForm.EnterEmailName(emailName);
            gamePage.LoginForm.EnterEmailDomain(emailDomain);
            gamePage.LoginForm.ExpandEmailDomainZoneList();
            gamePage.LoginForm.SelectRandomEmailDomainZone();
            gamePage.LoginForm.AcceptTermsAndConditions();
            gamePage.LoginForm.SubmitForm();
        }

        public void AssertSecondCardOpened()
        {
            Assert.IsTrue(gamePage.AvatarInterestsForm.State.IsExist);
        }

        public void FillInSecondCard(string testImage)
        {
            gamePage.AvatarInterestsForm.DownloadImage(testImage);
            gamePage.AvatarInterestsForm.UnselectAllInterests();
            gamePage.AvatarInterestsForm.SelectRandomInterests();
            gamePage.AvatarInterestsForm.UploadAvatar(testImage);
            gamePage.AvatarInterestsForm.SubmitForm();
        }

        public void AssertThirdCardOpened()
        {
            Assert.IsTrue(gamePage.PersonalDetailsForm.State.IsExist);
        }

        public void AcceptCookies()
        {
            gamePage.CookiesForm.AcceptCookies();
        }

        public void AssertCookiesFormClosed()
        {
            Assert.IsTrue(!gamePage.CookiesForm.State.IsExist);
        }

        public void HideHelp()
        {
            gamePage.HelpForm.HideHelp();
        }

        public void AssertHelpFormHidden()
        {
            Assert.IsTrue(gamePage.HelpForm.IsHelpFormContentHidden());
        }

        public void AssertTimerStart(string time)
        {
            string timer = gamePage.GetTimer();
            Assert.IsTrue(timer.EndsWith(time));
        }
    }
}
