namespace PWDemo;
public class RegisterUserTests : TestFixture
{
    [Test]
    public async Task registerUserTests()
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
    public async Task Invalid_UserName()
    {
        //step - 1: Navigate to homePage
        await _homePage.GoToHomePage();
        //step - 2: Navigate to RegisterPage
        await _homePage.clickonRegister();
        //step - 3: Verify if naviagted to RegisterPage.
        var pageHeader = await _registerPage.GetHeaderAsync();
        Assert.That(pageHeader, Is.EqualTo("Register."));
        //step - 4: Enter with userdeatils
        string uName = TestUtils.GenerateRandomUsername(0);
        string password = "Password@123";
        string cPassword = "Password@123";
        string emailAddress = TestUtils.GenerateRandomEmail();
        await _registerPage.RegisterUser(uName, password, cPassword,emailAddress);
        //Step - 5: Take Screenshot
        await _registerPage.takeScreenshot();
        //Step - 6: Click on Register Button
        await _registerPage.clickRegister();
        //Step - 7: Verify if the application displays, error message
        var errorMessage = await _registerPage.IsElementVisibleAsync("text=The UserName must be at least 6 charecters long.");
        Assert.That(errorMessage, "True");
    }
}