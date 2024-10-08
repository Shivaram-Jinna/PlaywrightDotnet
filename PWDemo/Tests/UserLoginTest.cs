using Allure.NUnit;
using Allure.NUnit.Attributes;
using static PWDemo.Pages.LoginPage;

namespace PWDemo;

[AllureNUnit]
public class UserLoginTest : TestFixture
{
    [Test]
    [AllureStep]
    [AllureDescription("User should be able to login with Valid username and password, and Navigate to Home Page.")]
    [AllureOwner("SJinna")]
    [AllureTag("Nunit", "SmokeTest","Login")]
    //[Category("Login_Functionality")]
    [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    [AllureFeature("Login Functionality")]  
    public async Task Login_WithValidCredentials_ShouldRedirectToDashboard_TC1()
    //Merged Testcase -  Logout_ShouldRedirectToDashboard_TC4
    {
        //Navigate to Home page
        await _homePage.GoToHomePage();
        await _homePage.Click_NavBar_Login();
        string uName = "admin";
        string pWord = "password";
        //Click Login, enter credentials and login.
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginAsync();
        //Verify user login
        await _homePage.validate_AccountName(uName);
        //Verify logout Functionlity
        //Navigate to different page 
        await _homePage.Click_NavBar_About();
        await _aboutPage.Click_NavBar_LogOff();
    }

    [Test]
    [AllureStep]
    [AllureDescription("Error Message Should be Displayed, when User tries to login with Invalid username and password.")]
    [AllureOwner("SJinna")]
    [AllureTag("Nunit", "SmokeTest","Login")]
    [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    [AllureFeature("Login Functionality")]
    public async Task Login_WithInvalidCredentials_ShouldDisplayErrorMessage_TC2()
    {
        //Navigate to Home page
        await _homePage.GoToHomePage();
        await _homePage.Click_NavBar_Login();
        string uName = TestUtils.GenerateRandomUsername();
        string pWord = "password";
        //enter credentials and click login.
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginAsync();
        //Verify Error Message.
        string expectedErroMessage = "Invalid login attempt.";
        await _loginPage.validateErrorMessage(loginPageElements.invalidLoginError, expectedErroMessage);
    }
    [Test]
    [AllureStep]
    [AllureDescription("Username and password are required Fields Message Should be Displayed, when User tries to login with Empty Fields.")]
    [AllureOwner("SJinna")]
    [AllureTag("Nunit", "SmokeTest","Login")]
    [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    [AllureFeature("Login Functionality")]
    public async Task Login_WithNoCredentials_ShouldDisplayErrorMessage_TC3()
    {
        //Navigate to Home page
        await _homePage.GoToHomePage();
        await _homePage.Click_NavBar_Login();
        //Click Login, enter credentials and login.
        await _loginPage.LoginAs("", "");
        await _loginPage.clickLoginAsync();
        //Verify error messages.
        string expected_UN_error = "The UserName field is required.";
        string expected_PW_error = "The Password field is required.";
        await _loginPage.validateErrorMessage(loginPageElements.UserNameError, expected_UN_error);
        await _loginPage.validateErrorMessage(loginPageElements.PasswordError, expected_PW_error);
    } 
}