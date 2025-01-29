namespace PWDemo;
public class EmployeeTest : TestFixture
{
    [Test]
    public async Task Verify_CanAddEmployee_WithValidDetails_TC11()
    //Merged TestCase : Verify_UserCan_ViewEmployeeDetails_TC14
    {
        //Login navigate to home page
        await _homePage.GoToHomePage();
        await _homePage.Click_NavBar_Login();
        string uName = "admin";
        string pWord = "password";
        //Click Login, enter credentials and login.
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginAsync();
        //Click on employee List on nav bar
        await _homePage.Click_NavBar_EmployeeList();
        //Click on create new Button
        await _employeePage.click_CreateNewAsync();
        //Enter employee details and click on create.
        string empName = TestUtils.GenerateRandomUsername();
        string empsalary = "90000";
        string empDWorked = "5";
        string empGrade = "1";
        string empEmail = TestUtils.GenerateRandomEmail();
        await _createEmployeePage.addEmployeeDetails(empName,empsalary,empDWorked,empGrade,empEmail);
        await _createEmployeePage.clickCreateAsync();
        //TC - 14 Verify_UserCan_ViewEmployeeDetails
        //enter empName in search box and click search.
        await _employeePage.searchEmployee(empName);
        //Verify all the employee details
        await _employeePage.verifyEmployee(empName,empsalary,empDWorked, empGrade, empEmail);
    }

    [Test]
    public async Task Verify_UserCan_Edit_EmployeeDetails_TC12()
    {
        //Login navigate to home page
        await _homePage.GoToHomePage();
        //Admin Login
        await _homePage.Click_NavBar_Login();
        string uName = "admin";
        string pWord = "password";
        //Click Login, enter credentials and login.
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginAsync();
        //Click on employee List on nav bar
        await _homePage.Click_NavBar_EmployeeList();
        //Click on create new Button
        await _employeePage.click_CreateNewAsync();
        //Enter employee details and click on create.
        string empName = TestUtils.GenerateRandomUsername();
        string empsalary = "90000";
        string empDWorked = "5";
        string empGrade = "1";
        string empEmail = TestUtils.GenerateRandomEmail();
        await _createEmployeePage.addEmployeeDetails(empName,empsalary,empDWorked,empGrade,empEmail);
        await _createEmployeePage.clickCreateAsync();
        await _employeePage.searchEmployee(empName);
        //Click on Edit Employee button
        await _employeePage.editEmployee();
        //edit Employee details
        empName = "edited"+empName;
        empsalary = "100000";
        empDWorked = "6";
        empGrade = "2";
        empEmail = "edited"+empEmail;
        await _editEmployeePage.editEmployeeDetails(empName,empsalary,empDWorked,empGrade,empEmail);
        await _editEmployeePage.clickSaveAsync();
        //Enter Edited empName in search box and click search.
        await _employeePage.searchEmployee(empName);
        //Verify Edited Employee details
        await _employeePage.verifyEmployee(empName,empsalary,empDWorked, empGrade, empEmail);
    }
    [Test]
    public async Task Verify_UserCan_DeleteEmployee_TC13()
    {
        //Login navigate to home page
        await _homePage.GoToHomePage();
        //Admin Login
        await _homePage.Click_NavBar_Login();
        string uName = "admin";
        string pWord = "password";
        //Click Login, enter credentials and login.
        await _loginPage.LoginAs(uName, pWord);
        await _loginPage.clickLoginAsync();
        //Click on employee List on nav bar
        await _homePage.Click_NavBar_EmployeeList();
        await _employeePage.click_CreateNewAsync();
        string empName = TestUtils.GenerateRandomUsername();
        string empsalary = "90000";
        string empDWorked = "5";
        string empGrade = "1";
        string empEmail = TestUtils.GenerateRandomEmail();
        await _createEmployeePage.addEmployeeDetails(empName,empsalary,empDWorked,empGrade,empEmail);
        await _createEmployeePage.clickCreateAsync();
        await _employeePage.searchEmployee(empName);
        await _employeePage.clickDeleteAsync();
        await _deleteEmployeePage.clickDeleteAsync();
        await _employeePage.searchEmployee(empName);
        // Was Unable to verify the test step in framework.
        // Step - 18 : Verify if Employee is deleted.

    }
}
