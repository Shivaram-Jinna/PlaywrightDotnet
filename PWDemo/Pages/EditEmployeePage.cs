using Microsoft.Playwright;

namespace PWDemo.Pages;
public class EditEmployeePage : BasePage
{
    public EditEmployeePage(IPage page) : base(page){

    }
    //page specific Web Elements and locators
    private ILocator NameField => _page.Locator("#Name");
    private ILocator SalaryField => _page.Locator("#Salary");
    private ILocator DurationWorkedField => _page.Locator("#DurationWorked");
    private ILocator GradeField => _page.Locator("#Grade");
    private ILocator EmailField => _page.Locator("#Email");
    private ILocator SaveButton => _page.Locator("[value='Save']");
    
    public async Task editEmployeeDetails(string name, string salary, string durationWorked, string empGrade, string email)
    {
        await NameField.FillAsync(name);
        await SalaryField.FillAsync(salary);
        await DurationWorkedField.FillAsync(durationWorked);
        await GradeField.FillAsync(empGrade);
        await EmailField.FillAsync(email);
    }
    public async Task clickSaveAsync()
    {
        await SaveButton.ClickAsync();
    }
    
}