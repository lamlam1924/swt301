


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System.Collections.Generic;

namespace pet_spa_system1.pet_spa_system1.Tests.Utils;

    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            var options = new ChromeOptions();
            var prefs = new Dictionary<string, object>
            {
                ["profile.managed_default_content_settings.javascript"] = 2
            };
            options.AddUserProfilePreference("prefs", prefs);
            options.AddArgument("--incognito");

            return new ChromeDriver(options);
        }
    }

   