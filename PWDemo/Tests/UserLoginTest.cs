using System.Runtime.CompilerServices;
using Microsoft.Playwright;
using PWDemo.Pages;

namespace PWDemo;

public class UserLoginTest : TestFixture
{
    public UserLoginTest(string browserType) : base(browserType)
    {
    }

    [Test]
    public async Task ValidLogin_TC1()
    {
        //Navigate to Home page
        await _homePage.GoToHomePage();
        //Step - 1: Navigate to Login Page
        await _homePage.Click_NavLogin();
        // Verify, user is navigated to Login Page
        string pageHeader = await _loginPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Login."));
        //Step - 2 : Enter Username, password
        string uName = "admin";
        string pWord = "password";
        await _loginPage.EnterCredentials(uName, pWord);
        //step - 3 : Click on login button
        await _loginPage.ClickLoginButton();
        //Step - 4: Verify user login
        var userGreetings = await _homePage.getElementTextasync("a[title='Manage']");
        Assert.That(userGreetings, Is.EqualTo("Hello "+uName+"!"));
    }
    [Test]
    public async Task inValidLogin_TC2()
    {
        //Navigate to Home page
        await _homePage.GoToHomePage();
        //Step - 1: Navigate to Login Page
        await _homePage.Click_NavLogin();
        // Verify, user is navigated to Login Page
        string pageHeader = await _loginPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Login."));
        //Step - 2 : Enter Username, password
        string uName = "asdads";
        string pWord = "adafafsf";
        await _loginPage.EnterCredentials(uName, pWord);
        //step - 3 : Click on login button
        await _loginPage.ClickLoginButton();
        //Step - 4: Verify user login
        var errorMessage = await _loginPage.IsElementVisibleAsync("text=Invalid login attempt.");
        Assert.That(errorMessage, "True");
    }
    [Test]
    public async Task NoCredentials_TC3()
    {
        //Navigate to Home page
        await _homePage.GoToHomePage();
        //Step - 1: Navigate to Login Page
        await _homePage.Click_NavLogin();
        // Verify, user is navigated to Login Page
        string pageHeader = await _loginPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Login."));
        //Step - 2 : Enter Username, password
        string uName = "";
        string pWord = "";
        await _loginPage.EnterCredentials(uName, pWord);
        //step - 3 : Click on login button
        await _loginPage.ClickLoginButton();
        //Step - 4: Verify error messages.
        bool usernameErrormessage = await _loginPage.IsElementVisibleAsync("text=The UserName field is required.");
        Assert.That(usernameErrormessage, "True");
        bool passwordErrormessage = await _loginPage.IsElementVisibleAsync("text=The Password field is required.");
        Assert.That(passwordErrormessage, "True");
       
    }
    [Test]
    public async Task ValidLogout_TC4()
    {
        //Navigate to Home page
        await _homePage.GoToHomePage();
        //Step - 1: Navigate to Login Page
        await _homePage.Click_NavLogin();
        // Verify, user is navigated to Login Page
        string pageHeader = await _loginPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Login."));
        //Step - 2 : Enter Username, password
        string uName = "admin";
        string pWord = "password";
        await _loginPage.EnterCredentials(uName, pWord);
        //step - 3 : Click on login button
        await _loginPage.ClickLoginButton();
        //Step - 4: Verify user login
        var userGreetings = await _homePage.getElementTextasync("a[title='Manage']");
        Assert.That(userGreetings, Is.EqualTo("Hello "+uName+"!"));
        //step - 5: Click on Logout
        await _homePage.ClickElementAsync("text=Log off");
        //Verify if login button is visible again
        bool isLoginVisible = await _loginPage.IsElementVisibleAsync("text=Login");
        Assert.That(isLoginVisible, "True");       
    }   
    
}