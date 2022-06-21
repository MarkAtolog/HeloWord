using Definitions.Pages;
using UserinterfaceTest.Tests;

namespace UserinterfaceTest.Steps
{
    public class HomePageSteps
    {
        private HomePage HomePage;

        public HomePageSteps(HomePage homePage)
        {
            HomePage = homePage;
        }

        public void AssertHomePageOpened()
        {
            Assert.IsTrue(HomePage.State.IsExist);
        }

        public void NavigateToGame()
        {
            HomePage.ClickStartLink();
        }
    }
}
