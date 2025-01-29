namespace PWDemo;
public class SearchTest : TestFixture
{

    [Test]
    public async Task Verify_EmplopyeeSearch_withValidDetails_RetrieveInformation_TC15()
    {
        //Employee name = Ramesh
        string searchName = "Ramesh";
        //Admin Login
        await _homePage.GoToHomePage();
        await _homePage.Click_NavBar_Login();
        string uName = "admin";
        string pWord = "password";
        //Click Login, enter credentials and login.
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginAsync();
        //Click on employee List on navigation bar
        await _homePage.Click_NavBar_EmployeeList();
        //Click on search button
        await _employeePage.searchEmployee(searchName);
        //verify is emp exists.
        //Should design a method to verify if searched employee exist.

        //Step - 7: Search employee without input 
    }
    [Test]
    public async Task Verify_EmplopyeeSearch_withInvalidDetails_DisplayEmptyList_TC16()
    {
        //Employee name = Ramesh
        string searchName = TestUtils.GenerateRandomUsername();
        //Admin Login
        await _homePage.GoToHomePage();
        await _homePage.Click_NavBar_Login();
        string uName = "admin";
        string pWord = "password";
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginAsync();
        //Click on employee List on navigation bar
        await _homePage.Click_NavBar_EmployeeList();
        //Click on search button
        await _employeePage.searchEmployee(searchName);
        //verify is emp exists.
        //Should design a method to verify if searched employee exist.

        //Step - 7: Search employee without input 
    }
}