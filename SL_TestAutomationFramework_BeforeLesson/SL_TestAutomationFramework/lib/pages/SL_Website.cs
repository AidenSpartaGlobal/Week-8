using OpenQA.Selenium;
using SL_TestAutomationFramework.lib.driver_config;

namespace SL_TestAutomationFramework.lib.pages
{
    //Super class - essentiall acting as a service object for all pages
   
    public class SL_Website <T> where T : IWebDriver, new()
    {
        public IWebDriver SeleniumDriver { get; set; }
        public SL_HomePage SL_HomePage { get; set; }
        public SL_InventoryPage SL_InventoryPage { get; set; }

        public SL_Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs, isHeadless).Driver;
            SL_HomePage = new SL_HomePage(SeleniumDriver);
            SL_InventoryPage = new SL_InventoryPage(SeleniumDriver);
        }

    }
}
