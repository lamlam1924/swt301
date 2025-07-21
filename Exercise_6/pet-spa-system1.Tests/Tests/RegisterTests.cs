// using Xunit;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Chrome;
// using pet_spa_system1.Tests.Pages;
//
// namespace pet_spa_system1.Tests.Tests
// {
//     public class RegisterTests : IDisposable
//     {
//         private readonly IWebDriver driver;
//         private readonly RegisterPage registerPage;
//
//         public RegisterTests()
//         {
//             driver = new ChromeDriver();
//             registerPage = new RegisterPage(driver);
//         }
//
//         [Fact]
//         public void SuccessfulRegistration_ShouldRedirectOrShowSuccess()
//         {
//             registerPage.Navigate();
//
//             string uniqueEmail = $"test{DateTime.Now.Ticks}@example.com";
//
//             registerPage.Register("Test User", uniqueEmail, "TestSelenium123");
//
//             // Cách 1: nếu redirect
//             Assert.DoesNotContain("Login", driver.Url);
//
//             // Cách 2: nếu hiển thị thông báo (tuỳ app nhóm bạn)
//             // Assert.Contains("thành công", driver.PageSource);
//         }
//
//         public void Dispose()
//         {
//             driver.Quit();
//         }
//     }
// }