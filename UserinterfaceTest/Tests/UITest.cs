using Aquality.Selenium.Browsers;
using Microsoft.Extensions.DependencyInjection;
using UserinterfaceTest.Steps;
using Framework.Utils;
using Definitions.Configurations;

namespace UserinterfaceTest.Tests
{
    public class UITest : BaseTest
    {
        private GamePageSteps GameSteps;
        private HomePageSteps HomeSteps;

        [SetUp]
        public void Setup()
        {
            GameSteps = ServiceProvider.GetService<GamePageSteps>();
            HomeSteps = ServiceProvider.GetService<HomePageSteps>();
            AqualityServices.Browser.Maximize();
            AqualityServices.Browser.GoTo(TestConfig.Url);
            
        }

        [Test]
        public void ShouldBePossibleToFillInCards()
        {
            string password = StringGenerator.GenerateString();
            string emailName = StringGenerator.GenerateString(upper: false);
            string emailDomain = StringGenerator.GenerateString(upper: false);
            string testImage = TestConfig.TestImage;

            HomeSteps.AssertHomePageOpened();

            HomeSteps.NavigateToGame();
            GameSteps.AssertFirstCardOpened();

            GameSteps.FillInFirstCard(password, emailName, emailDomain);
            GameSteps.AssertSecondCardOpened();

            GameSteps.FillInSecondCard(testImage);
            GameSteps.AssertThirdCardOpened();
        }

        [Test]
        public void ShouldBePossibleToHideHelpForm()
        {
            HomeSteps.AssertHomePageOpened();

            HomeSteps.NavigateToGame();
            GameSteps.AssertGamePageOpened();

            GameSteps.HideHelp();
            GameSteps.AssertHelpFormHidden();
        }

        [Test]
        public void ShouldBePossibleToAcceptCokies()
        {
            HomeSteps.AssertHomePageOpened();

            HomeSteps.NavigateToGame();
            GameSteps.AssertGamePageOpened();

            GameSteps.AcceptCookies();
            GameSteps.AssertCookiesFormClosed();
        }

        [Test]
        public void ValidateTimerStart()
        {
            string timeStart = "00:00";

            HomeSteps.AssertHomePageOpened();

            HomeSteps.NavigateToGame();
            GameSteps.AssertGamePageOpened();

            GameSteps.AssertTimerStart(timeStart);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(AqualityServices.Browser.DownloadDirectory))
            {
                Directory.Delete(AqualityServices.Browser.DownloadDirectory, true);
            }
            AqualityServices.Browser.Quit();

        }
    }
}