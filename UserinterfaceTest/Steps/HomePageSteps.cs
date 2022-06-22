using Definitions.Pages;

namespace UserinterfaceTest.Steps
{
    public class HomePageSteps
    {
        private readonly HomePage HomePage;

        public HomePageSteps(HomePage homePage)
        {
            HomePage = homePage;
        }

        public void AssertHomePageOpened()
        {
            Assert.IsTrue(HomePage.State.IsExist, "Home page is not loaded");
        }

        public void NavigateToGame()
        {
            HomePage.ClickStartLink();
        }
    }
}
