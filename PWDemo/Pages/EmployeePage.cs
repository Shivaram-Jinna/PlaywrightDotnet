using Microsoft.Playwright;

namespace PWDemo.Pages;
public class EmployeePage : BasePage
{
    // Constructor to initialize the Homepage Object - We Use base class implementation.
    public EmployeePage(IPage page) : base(page){

    }
    public async Task searchEmployee(string name)
    {
        await _page.FillAsync("[name='searchTerm']", name);
        await _page.ClickAsync("[value='Search']");
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
    public async Task<bool> verifyEmployee(string Expectedname, string Expectedsalary, string ExpecteddurationWorked, string ExpectedEmpgrade, string Expectedemail)
    {
        //bool result = true; // Assume all are true initially
        List<string> ExpectedEmpDetails = new List<string> { Expectedname, Expectedsalary, ExpecteddurationWorked, ExpectedEmpgrade, Expectedemail };
        List<string> ActualEmpDetails = await getEmpDetails();
        //Assert.That(ActualEmpDetails, Is.EquivalentTo(ExpectedEmpDetails));
        return ActualEmpDetails.SequenceEqual(ExpectedEmpDetails);
    }
    public async Task editEmployee()
    {
        await _page.ClickAsync("text=Edit");
    }


}