using Allure.NUnit;
using Allure.NUnit.Attributes;

namespace PWDemo;
[AllureNUnit]
public class RegisterUserTests : TestFixture
{
    [Test]
    [AllureStep]
    [AllureDescription("New user registration with valid details, Should login to user account and Navigate to HomePage.")]
    [AllureOwner("SJinna")]
    [AllureTag("Nunit", "SmokeTest","UserRegisteration")]
    [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    [AllureFeature("User Registration Functionality")]
    public async Task RegisterUser_WithValidDetails_ShouldRedirectToDashboard_TC5()
    {
        //step - 1: Navigate to homePage
        await _homePage.GoToHomePage();
        //step - 2: Navigate to RegisterPage
        await _homePage.Click_NavRegister();
        //step - 3: Verify if naviagted to RegisterPage.
        var pageHeader = await _registerPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Register."));
        //step - 4: Enter with userdeatils
        string uName = TestUtils.GenerateRandomUsername();
        string password = "Password@123";
        string cPassword = "Password@123";
        string emailAddress = TestUtils.GenerateRandomEmail();
        await _registerPage.RegisterUser(uName, password, cPassword,emailAddress);
        await _registerPage.clickRegisterAsync();
        //Step - 6: Verify if the user is Succesfully Registered
        var userAccount = await _homePage.validateAccountName(uName);
        Assert.That(userAccount, Is.EqualTo(true));
        
    }
    [Test]
    [AllureStep]
    [AllureDescription("New user registration with Missing details, Should Display field Error Messages")]
    [AllureOwner("SJinna")]
    [AllureTag("Nunit", "SmokeTest","UserRegisteration")]
    [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    [AllureFeature("User Registration Functionality")]
    public async Task RegisterUser_WithMisssingFields_DisplayErrorMessage_TC6()
    {
        //step - 1: Navigate to homePage
        await _homePage.GoToHomePage();
        //step - 2: Navigate to RegisterPage
        await _homePage.Click_NavRegister();
        //step - 3: Verify if naviagted to RegisterPage.
        var pageHeader = await _registerPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Register."));
        //step - 4: Enter with userdeatils
        string uName = "";
        string password = "";
        string cPassword = "";
        string emailAddress = "";
        await _registerPage.RegisterUser(uName, password, cPassword,emailAddress);
        await _registerPage.clickRegisterAsync();
        //Step - 7: Verify if the application displays, error message
        var UserName_Invalid = await _registerPage.IsElementVisibleAsync("text=The UserName field is required.");
        Assert.That(UserName_Invalid, "True");
        var Password_Invalid = await _registerPage.IsElementVisibleAsync("text=The Password field is required.");
        Assert.That(UserName_Invalid, "True");
        var Email_Invalid = await _registerPage.IsElementVisibleAsync("text=The Email field is required.");
        Assert.That(UserName_Invalid, "True");
    }

    [Test]
    [AllureStep]
    [AllureDescription("New user registration with Existing User details, Should not Allow User Registration, and Display Erro Message.")]
    [AllureOwner("SJinna")]
    [AllureTag("Nunit", "SmokeTest","UserRegisteration")]
    [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    [AllureFeature("User Registration Functionality")]
    public async Task RegisterUser_WithExsitingDetails_ShouldDisplayErrorMessage_TC7()
    {
        await _homePage.GoToHomePage();
        await _homePage.Click_NavRegister();
        var pageHeader = await _registerPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Register."));
        string uName = TestUtils.GenerateRandomUsername();
        string password = "Password@123";
        string cPassword = "Password@123";
        string emailAddress = TestUtils.GenerateRandomEmail();
        await _registerPage.RegisterUser(uName, password, cPassword,emailAddress);
        await _registerPage.clickRegisterAsync();
        var userAccount = await _homePage.validateAccountName(uName);
        Assert.That(userAccount, Is.EqualTo(true));
        //Logout of the account 
        await _homePage.Click_NavLogOff();
        await _homePage.Click_NavRegister();
        await _registerPage.RegisterUser(uName, password, cPassword,emailAddress);
        await _registerPage.clickRegisterAsync();
        //Step - 6: Verify if the error messages are diaplyed
        string UN_errorMessage = "text=Name "+uName+" is already taken.";
        var UserNameError = await _registerPage.IsElementVisibleAsync(UN_errorMessage);
        Assert.That(UserNameError, "True");
        string EM_errorMessage = "text=Email "+emailAddress+" is already taken.";
        var EmailError = await _registerPage.IsElementVisibleAsync(EM_errorMessage);
        Assert.That(UserNameError, "True");
    } 
}