using static PWDemo.Pages.LoginPage;

namespace PWDemo;

public class UserLoginTest : TestFixture
{
    [Test] 
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