using Definitions.Configuration;
using Framework.Utils;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using System.Drawing.Imaging;
using UserinterfaceTest.Steps;

namespace UserinterfaceTest.Tests
{
    public class UITest : BaseTest
    {
        private GamePageSteps GameSteps;
        private HomePageSteps HomeSteps;
        private BrowserUtils BrowserUtils;

        [SetUp]
        public void Setup()
        {
            GameSteps = ServiceProvider.GetRequiredService<GamePageSteps>();
            HomeSteps = ServiceProvider.GetRequiredService<HomePageSteps>();
            BrowserUtils = ServiceProvider.GetRequiredService<BrowserUtils>();

            BrowserUtils.Maximize();
            BrowserUtils.GoTo(TestConfig.Url);
        }

        [Test]
        [Category("TC1")]
        public void CardsFillingCheck()
        {
            //Arrange
            string password = StringUtils.GenerateString();
            string emailName = StringUtils.GenerateString(isUpper: false);
            string emailDomain = StringUtils.GenerateString(isUpper: false);
            string testImage = TestConfig.Image;

            //Assert
            HomeSteps.AssertHomePageOpened();

            //Act
            HomeSteps.NavigateToGame();
            //Assert
            GameSteps.AssertFirstCardOpened();

            //Act
            GameSteps.FillInUserCredentials(password, emailName, emailDomain);
            GameSteps.SubmitFirstCard();
            //Assert
            GameSteps.AssertSecondCardOpened();

            //Act
            GameSteps.SelectInterests();
            GameSteps.UploadAvatar(testImage);
            GameSteps.SubmitSecondCard();
            //Assert
            GameSteps.AssertThirdCardOpened();
        }

        [Test]
        [Category("TC2")]

        public void HelpFormHidingCheck()
        {
            //Assert
            HomeSteps.AssertHomePageOpened();

            //Act
            HomeSteps.NavigateToGame();
            //Assert
            GameSteps.AssertGamePageOpened();

            //Act
            GameSteps.HideHelp();
            //Assert
            GameSteps.AssertHelpFormHidden();
        }

        [Test]
        [Category("TC3")]

        public void CookiesAcceptionCheck()
        {
            //Assert
            HomeSteps.AssertHomePageOpened();

            //Act
            HomeSteps.NavigateToGame();
            //Assert
            GameSteps.AssertGamePageOpened();

            //Act
            GameSteps.AcceptCookies();
            //Assert
            GameSteps.AssertCookiesFormClosed();
        }

        [Test]
        [Category("TC4")]

        public void TimerStartingCheck()
        {
            //Arrange
            string timeStart = "00:00";

            //Assert
            HomeSteps.AssertHomePageOpened();

            //Act
            HomeSteps.NavigateToGame();

            //Assert
            GameSteps.AssertTimerStart(timeStart);
            Assert.Fail();
        }

        [TearDown]
        public void CleanUp()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString() != "Passed")
            {
                BrowserUtils.SaveScreenshot(testName);
            }

            FileUtils.CleanDownloadDirectory();
            BrowserUtils.Quit();
        }
    }
}