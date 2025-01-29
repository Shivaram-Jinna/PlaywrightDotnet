using Microsoft.Playwright;

namespace PWDemo.Pages;
public class EmployeePage : BasePage
{
   
    public EmployeePage(IPage page) : base(page){

    }
    //page specific Web Elements and locators
    private ILocator searchNameField => _page.Locator("[name='searchTerm']");
    private ILocator searchButton => _page.Locator("[value='Search']");
    private ILocator CreateNewButton => _page.Locator("text=Create New");
    private ILocator emp_DeleteButton => _page.Locator("text=Delete");
    private ILocator emp_EditButton => _page.Locator("text=Edit");
    
    public async Task searchEmployee(string name)
    {
        await searchNameField.FillAsync(name);
        await searchButton.ClickAsync();
    }
    public async Task click_CreateNewAsync()
    {
        await CreateNewButton.ClickAsync();
    }

    public async Task clickDeleteAsync()
    {
        await emp_DeleteButton.ClickAsync();
    }
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
    
    public async Task verifyEmployee(string Expectedname, string Expectedsalary, string ExpecteddurationWorked, string ExpectedEmpgrade, string Expectedemail)
    {
        //bool result = true; // Assume all are true initially
        List<string> ExpectedEmpDetails = new List<string> { Expectedname, Expectedsalary, ExpecteddurationWorked, ExpectedEmpgrade, Expectedemail };
        List<string> ActualEmpDetails = await getEmpDetails();
        //Assert.That(ActualEmpDetails, Is.EquivalentTo(ExpectedEmpDetails));
        Assert.That(ActualEmpDetails, Is.EqualTo(ExpectedEmpDetails));
    }
    public async Task editEmployee()
    {
        await emp_EditButton.ClickAsync();
    }


}