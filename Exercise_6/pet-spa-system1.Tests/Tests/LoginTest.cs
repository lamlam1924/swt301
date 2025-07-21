using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using pet_spa_system1.Tests.Pages;
using SeleniumExtras.WaitHelpers;

namespace pet_spa_system1.Tests.Tests
{
    public class LoginTests : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;

        public LoginTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
        }

        [Fact]
        public void SuccessfulLogin_ShouldRedirectToHome()
        {
            loginPage.Open();
            loginPage.Login("user@example.com", "password123", true);

            // Đợi URL thay đổi, tức redirect sang trang Home (không còn url Login nữa)
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.Url != "https://localhost:7231/Login/Login");

            // Kiểm tra URL có chứa 'home' hoặc không phải login (bạn thay URL home thực tế nếu có)
            Assert.DoesNotContain("/Login/Login", driver.Url);

            // Hoặc kiểm tra xuất hiện một element đặc trưng trên trang Home, ví dụ
            var homePageIdentifier = driver.FindElement(By.CssSelector("div.slider_area"));
            Assert.NotNull(homePageIdentifier);
        }



        [Fact]
        public void SuccessfulRegistration_ShouldRedirectOrShowSuccess()
        {
            Console.WriteLine("===> Running SuccessfullRegistration_ShouldRedirectToHome");
            loginPage.Open();
            loginPage.Register("Lâm", "lamtest@example.com", "password123");

            // Đợi URL không còn là trang đăng ký nữa
            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.Url != "https://localhost:7231/Login/Login");

            Assert.NotEqual("https://localhost:7231/Login/Login", driver.Url);
        }


        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}