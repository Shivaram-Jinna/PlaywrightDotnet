namespace PWDemo;
public class SearchTest : TestFixture
{
    public SearchTest(string browserType) : base(browserType)
    {
    }

    [Test]
    public async Task SearchEmployee()
    {
        //Employee name = Ramesh
        string searchName = "Ramesh";
        //step - 1: Navigate to homePage
        await _homePage.GoToHomePage();
        //Step - 2: Navigate to Login Page
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
        // Step - 4 : Click on employee List on nav bar
        await _homePage.Click_NavEmployeeList();
        // Step - 5 : Click on search button
        await _employeePage.searchEmployee(searchName);
        //Step - 6 : verify is emp exists.

        //Should design a method to verify if searched employee exist.

        //Step - 7: Search employee without input 
    }
}