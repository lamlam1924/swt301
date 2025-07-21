

using OpenQA.Selenium;
using pet_spa_system1.pet_spa_system1.Tests.Utils;
using Xunit;

namespace pet_spa_system1.pet_spa_system1.Tests.UI.Tests;

    public abstract class BaseTest : IDisposable
    {
        protected IWebDriver driver;

        public BaseTest()
        {
            driver = DriverFactory.CreateDriver();
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }


