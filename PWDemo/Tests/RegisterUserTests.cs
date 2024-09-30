namespace PWDemo;
public class RegisterUserTests : TestFixture
{
    [Test]
    public async Task registerUserTests_TC5()
    {
        //step - 1: Navigate to homePage
        await _homePage.GoToHomePage();
        //step - 2: Navigate to RegisterPage
        await _homePage.clickonRegister();
        //step - 3: Verify if naviagted to RegisterPage.
        var pageHeader = await _registerPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Register."));
        //step - 4: Enter with userdeatils
        string uName = TestUtils.GenerateRandomUsername();
        string password = "Password@123";
        string cPassword = "Password@123";
        string emailAddress = TestUtils.GenerateRandomEmail();
        await _registerPage.RegisterUser(uName, password, cPassword,emailAddress);
        //Step - 5: Click on Register Button
        await _registerPage.clickRegister();
        //Step - 6: Verify if the user is Succesfully Registered
        var userGreetings = await _homePage.getElementTextasync("a[title='Manage']");
        Assert.That(userGreetings, Is.EqualTo("Hello "+uName+"!"));
    }
    [Test]
    public async Task Invalid_UserName_TC6()
    {
        //step - 1: Navigate to homePage
        await _homePage.GoToHomePage();
        //step - 2: Navigate to RegisterPage
        await _homePage.clickonRegister();
        //step - 3: Verify if naviagted to RegisterPage.
        var pageHeader = await _registerPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Register."));
        //step - 4: Enter with userdeatils
        string uName = "";
        string password = "";
        string cPassword = "";
        string emailAddress = "";
        await _registerPage.RegisterUser(uName, password, cPassword,emailAddress);
        //Step - 5: Take Screenshot
        await _registerPage.takeScreenshot();
        //Step - 6: Click on Register Button
        await _registerPage.clickRegister();
        //Step - 7: Verify if the application displays, error message
        var UserName_Invalid = await _registerPage.IsElementVisibleAsync("text=The UserName field is required.");
        Assert.That(UserName_Invalid, "True");
        var Password_Invalid = await _registerPage.IsElementVisibleAsync("text=The Password field is required.");
        Assert.That(UserName_Invalid, "True");
        var Email_Invalid = await _registerPage.IsElementVisibleAsync("text=The Email field is required.");
        Assert.That(UserName_Invalid, "True");
    }

    [Test]
    public async Task registerExistingUserDetails_TC7()
    {
        //step - 1: Navigate to homePage
        await _homePage.GoToHomePage();
        //step - 2: Navigate to RegisterPage
        await _homePage.clickonRegister();
        //step - 3: Verify if naviagted to RegisterPage.
        var pageHeader = await _registerPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Register."));
        //step - 4: Enter with userdeatils
        string uName = "admin69";
        string password = "Password@123";
        string cPassword = "Password@123";
        string emailAddress = "admin69@eaapp.com";
        await _registerPage.RegisterUser(uName, password, cPassword,emailAddress);
        //Step - 5: Click on Register Button
        await _registerPage.clickRegister();
        //Step - 6: Verify if the error messages are diaplyed
        string UN_errorMessage = "text=Name "+uName+" is already taken.";
        var UserNameError = await _registerPage.IsElementVisibleAsync(UN_errorMessage);
        Assert.That(UserNameError, "True");
        string EM_errorMessage = "text=Email "+emailAddress+" is already taken.";
        var EmailError = await _registerPage.IsElementVisibleAsync(EM_errorMessage);
        Assert.That(UserNameError, "True");
    } 
}