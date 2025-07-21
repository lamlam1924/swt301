using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace pet_spa_system1.Tests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private readonly string url = "https://localhost:7231/Login/Login";

        // Selectors Login
        private readonly By loginEmail = By.Name("Login.Email");
        private readonly By loginPassword = By.Name("Login.Password");
        private readonly By loginRememberMe = By.Name("Login.RememberMe");
        private readonly By loginButton = By.XPath("//div[contains(@class,'sign-in-container')]//button[text()='Đăng Nhập']");

        // Selectors Register
        private readonly By registerName = By.Name("Register.Name");
        private readonly By registerEmail = By.Name("Register.Email");
        private readonly By registerPassword = By.Name("Register.Password");
        private readonly By registerButton = By.XPath("//div[contains(@class,'sign-up-container')]//button[text()='Đăng Ký']");

        private WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        public void Open()
        {
            GoTo(url);
            // Đợi page load, có thể chờ form login hoặc register hiện lên
            wait.Until(ExpectedConditions.ElementIsVisible(loginEmail));
        }

        // Bật form đăng nhập
        public void ShowLoginForm()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('container-login').classList.remove('right-panel-active');");
            // Chờ phần tử form login hiện
            wait.Until(ExpectedConditions.ElementIsVisible(loginEmail));
        }

        // Bật form đăng ký
        public void ShowRegisterForm()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('container-login').classList.add('right-panel-active');");
            // Chờ phần tử form đăng ký hiện
            wait.Until(ExpectedConditions.ElementIsVisible(registerName));
        }

        public void Login(string email, string password, bool rememberMe)
        {
            ShowLoginForm();

            Type(loginEmail, email);
            Type(loginPassword, password);

            var checkbox = driver.FindElement(loginRememberMe);
            if (checkbox.Selected != rememberMe)
                checkbox.Click();

            Click(loginButton);
        }

        public void Register(string name, string email, string password)
        {
            ShowRegisterForm();

            Type(registerName, name);
            Type(registerEmail, email);
            Type(registerPassword, password);

            Click(registerButton);
        }
        public bool IsLoggedIn()
        {
            try
            {
                return driver.FindElement(By.Id("welcomeMessage")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
