using OpenQA.Selenium;

namespace SL_TestAutomationFramework.lib.pages 
{ 
    public class SL_InventoryPage 
    { 
        private IWebDriver _seleniumDriver;

        private IWebElement _passwordField
        {
            get { return _seleniumDriver.FindElement(By.Id("password")); }
        }

        private IWebElement _usernameField => _seleniumDriver.FindElement(By.Id("user-name"));
        private IWebElement _loginButton => _seleniumDriver.FindElement(By.Id("login-button"));
        private IWebElement _errorMessage => _seleniumDriver.FindElement(By.CssSelector("[data-test=\"error\"]"));

        private string _homePageUrl = AppConfigReader.BaseUrl;


        private IWebElement _sauceLabsBackPack => _seleniumDriver.FindElement(By.Id("item_4_title_link"));
        private IWebElement _addToCart => _seleniumDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement _cartBadge => _seleniumDriver.FindElement(By.ClassName("shopping_cart_badge"));


        private string _inventPageURL = AppConfigReader.InventoryPageUrl;


        public SL_InventoryPage(IWebDriver seleniumDriver) 
        {
            _seleniumDriver = seleniumDriver; 
        }

        public void VisitHomePage() => _seleniumDriver.Navigate().GoToUrl(_homePageUrl);
        public void EnterUserName(string username) => _usernameField.SendKeys(username);
        public void EnterPassword(string password) => _passwordField.SendKeys(password);
        public void ClickLoginButton() => _loginButton.Click();
        public string CheckErrorMessage() => _errorMessage.Text;

        public void VisitInventoryPage() => _seleniumDriver.Navigate().GoToUrl(_inventPageURL);
        public void ClickBackPagePage() => _sauceLabsBackPack.Click();
        public void ClickAddToCartButton() => _addToCart.Click();

        public string cartBadgeNum() => _cartBadge.Text;
    } 
}