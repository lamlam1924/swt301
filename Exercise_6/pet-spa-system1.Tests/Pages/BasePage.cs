using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace pet_spa_system1.Tests.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected void GoTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Click(By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            try
            {
                element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                // Nếu click trực tiếp thất bại, thử click bằng JS
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
            }
        }




        protected void Type(By by, string text)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            element.Clear();
            element.SendKeys(text);
        }

        protected bool IsDisplayed(By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected string GetText(By by)
        {
            return driver.FindElement(by).Text;
        }
    }
}