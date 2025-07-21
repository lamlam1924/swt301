package tests;

import base.BaseTest;
import org.junit.jupiter.api.*;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvFileSource;
import pages.PracticeFormPage;

import static org.junit.jupiter.api.Assertions.*;

@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
public class PracticeFormTest extends BaseTest {

    public PracticeFormPage formPage;

    @BeforeEach
    public void initformPage() {
        formPage = new PracticeFormPage(driver);
        formPage.open();
    }

    @Test
    @Order(1)
    @DisplayName(" formPage.enterDOB(\"01 Jan 2008\");")
    void testSuccessfulFormSubmit() {
        formPage.enterFirstName("Hoang");
        formPage.enterLastName("Le");
        formPage.enterEmail("hoang@example.com");
        formPage.selectGender("Male");
        formPage.enterMobile("0912345678");
//        formPage.enterDOB("01 Jan 2008");
        formPage.enterAddress("123 ABC Street");
        formPage.clickSubmit();

        assertTrue(formPage.isSuccessModalDisplayed());
        assertTrue(formPage.getModalTitleText().contains("Thanks for submitting the form"));
    }


    @ParameterizedTest(name = "Test data row #{index}")
    @CsvFileSource(resources = "/test-data.csv", numLinesToSkip = 1)
    @DisplayName("Test form submission with CSV data")
    void testRegistrationForm(String firstName, String lastName, String email,
                              String gender, String mobile, String dob, String address,
                              boolean isValid) {

        formPage.enterFirstName(firstName);
        formPage.enterLastName(lastName);
        formPage.enterEmail(email);
        formPage.selectGender(gender);
        formPage.enterMobile(mobile);
        formPage.enterDOB(dob);
        formPage.enterAddress(address);
        formPage.clickSubmit();

        if (isValid) {
            assertTrue(formPage.isSuccessModalDisplayed(), "Form should be valid but failed.");
        } else {
            assertFalse(formPage.isSuccessModalDisplayed(), "Form should be invalid but passed.");
        }
    }
}
