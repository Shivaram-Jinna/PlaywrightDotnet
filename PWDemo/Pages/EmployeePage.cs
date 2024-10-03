using Allure.NUnit.Attributes;
using Microsoft.Playwright;

namespace PWDemo.Pages;
public class EmployeePage : BasePage
{
   
    public EmployeePage(IPage page) : base(page){

    }
    [AllureStep("Search Employee with username {0}")]
    public async Task searchEmployee(string name)
    {
        await _page.FillAsync("[name='searchTerm']", name);
        await _page.ClickAsync("[value='Search']");
    }

    [AllureStep("Click Create Button, on Employee list Page.")]
    public async Task clickCreateNewAsync()
    {
        await _page.Locator("text=Create New").ClickAsync();
    }

    [AllureStep("Click Delete Employee.")]
    public async Task clickDeleteAsync()
    {
        await _page.Locator("text=Delete").ClickAsync();
    }

    [AllureStep("Getting Actual Employee details on the list")]
    public async Task<List<string>> getEmpDetails()
    {
        var EmpDeatils = await _page.Locator("tr td ").AllAsync(); 
        if (EmpDeatils == null || EmpDeatils.Count == 0)
        {
            return new List<string>();
        }
        List<string> ActualEmpDetails = new List<string>();
        for(int i = 0;i <5; i++)
        {
            string? textContent = await EmpDeatils[i].TextContentAsync();
            ActualEmpDetails.Add(textContent?.Trim() ?? String.Empty);
        }
        return ActualEmpDetails;
    }
    
    [AllureStep("Comparing Actual Employee details,, with Expected Deatils")]
    public async Task<bool> verifyEmployee(string Expectedname, string Expectedsalary, string ExpecteddurationWorked, string ExpectedEmpgrade, string Expectedemail)
    {
        //bool result = true; // Assume all are true initially
        List<string> ExpectedEmpDetails = new List<string> { Expectedname, Expectedsalary, ExpecteddurationWorked, ExpectedEmpgrade, Expectedemail };
        List<string> ActualEmpDetails = await getEmpDetails();
        //Assert.That(ActualEmpDetails, Is.EquivalentTo(ExpectedEmpDetails));
        return ActualEmpDetails.SequenceEqual(ExpectedEmpDetails);
    }
    [AllureStep("Click Edit Employee Button.")]
    public async Task editEmployee()
    {
        await _page.ClickAsync("text=Edit");
    }


}