namespace PWDemo;
public class EmployeeTest : TestFixture
{

    [Test]
    public async Task addEmployee_TC11_12_13_14()
    {
        //Step - 1: Login navigate to home page
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
        // Step - 4 : Click on employee List on nav bar
        await _homePage.Click_NavEmployeeList();
        // Step - 5 : Click on create new Button
        await _homePage.ClickElementAsync("text=Create New");
        // step - 6 : enter employee details and click on create.
        string empName = TestUtils.GenerateRandomUsername();
        string empsalary = "90000";
        string empDWorked = "5";
        string empGrade = "1";
        string empEmail = TestUtils.GenerateRandomEmail();
        await _createEmployeePage.addEmployeeDetails(empName,empsalary,empDWorked,empGrade,empEmail);
        //Step - 7: Click on Create
        await _createEmployeePage.clickCreateAsync();

        //TC - 14 Verifying Employee details
        //Step - 8 : enter empName in search box and click search.
        await _employeePage.searchEmployee(empName);
        // Step - 9 : Verify all the employee details
        await _employeePage.verifyEmployee(empName,empsalary,empDWorked, empGrade, empEmail);
        

        //TC - 12 Editing Employee Deatilas
        // Step - 10 : Click on Edit Employee button
        await _employeePage.editEmployee();
        //step - 11 : edit Employee details
        empName = "edited"+empName;
        empsalary = "100000";
        empDWorked = "6";
        empGrade = "2";
        empEmail = "edited"+empEmail;
        await _editEmployeePage.editEmployeeDetails(empName,empsalary,empDWorked,empGrade,empEmail);
        await _editEmployeePage.clickSaveAsync();
        //Step - 12 : enter Edited empName in search box and click search.
        await _employeePage.searchEmployee(empName);
        // Step - 13 : Verify all the employee details
        await _employeePage.verifyEmployee(empName,empsalary,empDWorked, empGrade, empEmail);
        


        //TC-13 Deleting Employee
        //Step - 14 : search employeee to delete 
        await _employeePage.searchEmployee(empName);
        //Step - 15 : click on delete
        await _employeePage.ClickElementAsync("text=Delete");
        //Step - 16 : click on delete on Employee/delete page
        await _deleteEmployeePage.clickDeleteAsync();
        //Step - 17: Searc hand Verify;
        await _employeePage.searchEmployee(empName);


        // Was Unable to verify the test step in framework.
        // Step - 18 : Verify if Employee is deleted.
        
        // var isPresent = await _employeePage.IsElementVisibleAsync($"td:has-text('{empName}')");      
        // Assert.That(isPresent, "False");
    }
}
