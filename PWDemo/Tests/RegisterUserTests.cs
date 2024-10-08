using System.Collections.Generic;
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
        await _homePage.Click_NavBar_Register();
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
        await _homePage.validate_AccountName(uName);
        
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
        await _homePage.Click_NavBar_Register();
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
        List<string> expectedErrorMessage = new List<string> 
        {
            "The UserName field is required.",
            "The Password field is required.",
            "The Email field is required."
        };
        await _registerPage.ValidateErrorMessages(expectedErrorMessage);
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
        await _homePage.Click_NavBar_Register();
        var pageHeader = await _registerPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Register."));
        string uName = TestUtils.GenerateRandomUsername();
        string password = "Password@123";
        string cPassword = "Password@123";
        string emailAddress = TestUtils.GenerateRandomEmail();
        await _registerPage.RegisterUser(uName, password, cPassword,emailAddress);
        await _registerPage.clickRegisterAsync();
        await _homePage.validate_AccountName(uName);
        //Logout of the account 
        await _homePage.Click_NavBar_LogOff();
        await _homePage.Click_NavBar_Register();
        await _registerPage.RegisterUser(uName, password, cPassword,emailAddress);
        await _registerPage.clickRegisterAsync();
        //Step - 6: Verify if the error messages are diaplyed
        List<string> expectedErrorMessage = new List<string> 
        {
            "Name "+uName+" is already taken.",
            "Email '"+emailAddress+"' is already taken."
        };
        await _registerPage.ValidateErrorMessages(expectedErrorMessage);
    } 
    
    //More TestCases Can Be Added.
}