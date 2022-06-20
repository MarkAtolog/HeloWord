using Definitions.Pages;

namespace UserinterfaceTest.Steps
{
    class HomePageSteps
    {
        private static HomePage homePage = new();

        public void AssertHomePageOpened()
        {
            Assert.IsTrue(homePage.State.IsExist);
        }

        public void NavigateToGame()
        {
            homePage.ClickStartLink();
        }
    }
}
