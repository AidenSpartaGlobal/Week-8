using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumIntroduction
{
    public class Tests
    {
        [Test]
        [Category("Happy Path")]
        public void GivenIAmOnTheHomepage_WhenIEnterAValidEmailAndValidPassword_ThenIShouldLandOnTheInventoryPage()
        {
            //we can use headless mode = which means dun the test and the driver, but not the GUI of the browser
            var options = new ChromeOptions();
            options.AddArguments("headless");



            // the resource in using argument is disposed of when it leaves the closing brace
            // anything in the using statement argument must implement the IDisposable method
            // so when we leave the using block, the dispose method is called
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                var userName = driver.FindElement(By.Id("user-name"));
                userName.SendKeys("standard_user");
                var passwordField = driver.FindElement(By.Id("password"));
                passwordField.SendKeys("secret_sauce");
                var loginButton = driver.FindElement(By.Name("login-button"));
                loginButton.Click();

                Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
                Thread.Sleep(10000);
            }
        }
        [Test]
        [Category("Sad")]
        public void GivenIAmOnTheHomepage_WhenIEnterAValidEmailAndAInvalidPassword_ThenIShouldLandOnTheInventoryPage()
        {

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                var userName = driver.FindElement(By.Id("user-name"));
                userName.SendKeys("standard_user");
                var passwordField = driver.FindElement(By.Id("password"));
                passwordField.SendKeys("secretsauce");
                var loginButton = driver.FindElement(By.Id("login-button"));
                loginButton.Click();
                var errorMsg = driver.FindElement(By.ClassName("error-message-container"));
                Assert.That(errorMsg.Text, Does.Contain("Epic sadface"));
                Thread.Sleep(10000);
            }
        }


        [Test]
        public void AssertThatDroppedIsDisplayed()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/droppable/");

                var dragThis = driver.FindElement(By.Id("draggable"));

                var dropBox = driver.FindElement(By.Id("droppable"));

                Actions dragging = new Actions(driver);
                dragging.DragAndDrop(dragThis, dropBox).Perform();

                Assert.That(dropBox.Text.Contains("Dropped!"));

            }
        }
    }

}