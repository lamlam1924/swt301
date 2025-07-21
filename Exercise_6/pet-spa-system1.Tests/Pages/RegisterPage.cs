// using OpenQA.Selenium;
// using pet_spa_system1.pet_spa_system1.Tests.Pages;
//
// namespace pet_spa_system1.Tests.Pages
// {
//     public class RegisterPage : BasePage
//     {
//         public RegisterPage(IWebDriver driver) : base(driver)
//         {
//         }
//
//         // Element locator
//         private readonly By nameField = By.Name("Register.Name");
//         private readonly By emailField = By.Name("Register.Email");
//         private readonly By passwordField = By.Name("Register.Password");
//         private readonly By registerButton = By.CssSelector("form[action*='Register'] button[type='submit']");
//
//         public void Navigate()
//         {
//             GoTo("https://localhost:7231/Login/Login"); // Trang có cả form đăng ký & đăng nhập
//             var container = driver.FindElement(By.Id("container-login"));
//             if (!container.GetAttribute("class").Contains("right-panel-active"))
//             {
//                 var signUpButton = driver.FindElement(By.Id("signUp"));
//                 signUpButton.Click();
//             }
//         }
//
//         public void Register(string name, string email, string password)
//         {
//             Type(nameField, name);
//             Type(emailField, email);
//             Type(passwordField, password);
//             Click(registerButton);
//         }
//     }
// }