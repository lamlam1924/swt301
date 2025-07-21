package pages;

import base.BasePage;
import org.openqa.selenium.*;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.time.Duration;

import static base.BaseTest.driver;

public class PracticeFormPage extends BasePage {

    public PracticeFormPage(WebDriver driver) {
        super(driver);
    }
    public void open() {
        driver.get("https://demoqa.com/automation-practice-form");
    }

    public void enterFirstName(String firstName) {
        driver.findElement(By.id("firstName")).sendKeys(firstName);
    }

    public void enterLastName(String lastName) {
        driver.findElement(By.id("lastName")).sendKeys(lastName);
    }

    public void enterEmail(String email) {
        driver.findElement(By.id("userEmail")).sendKeys(email);
    }

    public void selectGender(String gender) {
        driver.findElement(By.xpath("//label[text()='" + gender + "']")).click();
    }

    public void enterMobile(String mobile) {
        driver.findElement(By.id("userNumber")).sendKeys(mobile);
    }

    public void enterDOB(String dob) {
        WebElement dobInput = driver.findElement(By.id("dateOfBirthInput"));
        dobInput.click();
        dobInput.sendKeys(Keys.CONTROL + "a");
        dobInput.sendKeys(dob);
        dobInput.sendKeys(Keys.ENTER);
    }


    public void enterAddress(String address) {
        driver.findElement(By.id("currentAddress")).sendKeys(address);
    }

    public void submit() {
        driver.findElement(By.id("submit")).click();
    }

    public boolean isSubmittedSuccessfully() {
        try {
            new WebDriverWait(driver, Duration.ofSeconds(3))
                    .until(ExpectedConditions.visibilityOfElementLocated(By.id("example-modal-sizes-title-lg")));
            return true;
        } catch (TimeoutException e) {
            return false;
        }
    }
    public void clickSubmit() {
        driver.findElement(By.id("submit")).click();
    }
    public boolean isSuccessModalDisplayed() {
        try {
            WebElement modal = driver.findElement(By.className("modal-content"));
            return modal.isDisplayed();
        } catch (NoSuchElementException e) {
            return false;
        }
    }
    public String getModalTitleText() {
        return driver.findElement(By.id("example-modal-sizes-title-lg")).getText();
    }

}
