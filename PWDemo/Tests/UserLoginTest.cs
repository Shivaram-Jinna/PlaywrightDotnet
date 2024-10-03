using Allure.NUnit;
using Allure.NUnit.Attributes;

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
        await _homePage.Click_NavLogin();
        string uName = "admin";
        string pWord = "password";
        //Click Login, enter credentials and login.
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginaAsync();
        //Verify user login
        var userAccount = await _homePage.validateAccountName(uName);
        Assert.That(userAccount, Is.EqualTo(true));
        //Verify logout Functionlity
        //Navigate to different page 
        await _homePage.Click_NavAbout();
        await _aboutPage.Click_NavLogOff();
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
        await _homePage.Click_NavLogin();
        string uName = TestUtils.GenerateRandomUsername();
        string pWord = "password";
        //Click Login, enter credentials and login.
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginaAsync();
        //Verify Error Message.
        var errorMessage = await _loginPage.IsElementVisibleAsync("text=Invalid login attempt.");
        Assert.That(errorMessage, "True");
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
        await _homePage.Click_NavLogin();
        string uName = "";
        string pWord = "";
        //Click Login, enter credentials and login.
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginaAsync();
        //Verify error messages.
        bool usernameErrormessage = await _loginPage.IsElementVisibleAsync("text=The UserName field is required.");
        Assert.That(usernameErrormessage, "True");
        bool passwordErrormessage = await _loginPage.IsElementVisibleAsync("text=The Password field is required.");
        Assert.That(passwordErrormessage, "True"); 
    } 
}