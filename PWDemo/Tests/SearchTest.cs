using Allure.NUnit;
using Allure.NUnit.Attributes;

namespace PWDemo;
[AllureNUnit]
public class SearchTest : TestFixture
{

    [Test]
    [AllureStep]
    [AllureDescription("Admin Should be able to Search Existing employee and verify details are displayed properly.")]
    [AllureOwner("SJinna")]
    [AllureTag("Nunit", "SmokeTest","EmployeeSearch")]
    [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    [AllureFeature("Search Functionality")]
    public async Task Verify_EmplopyeeSearch_withValidDetails_RetrieveInformation_TC15()
    {
        //Employee name = Ramesh
        string searchName = "Ramesh";
        //Admin Login
        await _homePage.GoToHomePage();
        await _homePage.Click_NavLogin();
        string uName = "admin";
        string pWord = "password";
        //Click Login, enter credentials and login.
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginaAsync();
        //Click on employee List on navigation bar
        await _homePage.Click_NavEmployeeList();
        //Click on search button
        await _employeePage.searchEmployee(searchName);
        //verify is emp exists.
        //Should design a method to verify if searched employee exist.

        //Step - 7: Search employee without input 
    }
    [Test]
    [AllureStep]
    [AllureDescription("Admin Should See Empty list, when trying Search Non Existing employee")]
    [AllureOwner("SJinna")]
    [AllureTag("Nunit", "SmokeTest","EmployeeSearch")]
    [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    [AllureFeature("Search Functionality")]
    public async Task Verify_EmplopyeeSearch_withInvalidDetails_DisplayEmptyList_TC16()
    {
        //Employee name = Ramesh
        string searchName = TestUtils.GenerateRandomUsername();
        //Admin Login
        await _homePage.GoToHomePage();
        await _homePage.Click_NavLogin();
        string uName = "admin";
        string pWord = "password";
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginaAsync();
        //Click on employee List on navigation bar
        await _homePage.Click_NavEmployeeList();
        //Click on search button
        await _employeePage.searchEmployee(searchName);
        //verify is emp exists.
        //Should design a method to verify if searched employee exist.

        //Step - 7: Search employee without input 
    }
}