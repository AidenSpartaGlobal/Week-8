using OpenQA.Selenium.Chrome;
using SL_TestAutomationFramework.lib.pages;


namespace SL_TestAutomationFramework.tests
{
    public class SL_Inventory_Tests
    {
        private SL_Website<ChromeDriver> SL_Website = new();

        [Test]
        public void IAmOnTheInventoryPage()
        {
            // Maximise browser
            SL_Website.SeleniumDriver.Manage().Window.Maximize();
            // Navigate to home page
            SL_Website.SL_HomePage.VisitHomePage();
            // Enter valid username
            SL_Website.SL_HomePage.EnterUserName(AppConfigReader.UserName);
            // Enter valid password
            SL_Website.SL_HomePage.EnterPassword(AppConfigReader.Password);
            // Click login button
            SL_Website.SL_HomePage.ClickLoginButton();
            // Check landing page is correct
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.InventoryPageUrl));
        }


        [Test]
        public void AddToCart()
        {
            // Maximise browser
            SL_Website.SeleniumDriver.Manage().Window.Maximize();
            // Navigate to home page
            SL_Website.SL_HomePage.VisitHomePage();
            // Enter valid username
            SL_Website.SL_HomePage.EnterUserName(AppConfigReader.UserName);
            // Enter valid password
            SL_Website.SL_HomePage.EnterPassword(AppConfigReader.Password);
            // Click login button
            SL_Website.SL_HomePage.ClickLoginButton();
            // Check landing page is correct
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.InventoryPageUrl));



            SL_Website.SL_InventoryPage.ClickAddToCartButton();

            Assert.That(SL_Website.SL_InventoryPage.cartBadgeNum, Is.EqualTo("1"));
        }

        //Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/cart.html"));

        [OneTimeTearDown]
        public void CleanUp()
        {
            SL_Website.SeleniumDriver.Quit();
        }
    }
}
