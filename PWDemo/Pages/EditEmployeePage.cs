using Allure.NUnit.Attributes;
using Microsoft.Playwright;

namespace PWDemo.Pages;
public class EditEmployeePage : BasePage
{
    public EditEmployeePage(IPage page) : base(page){

    }
    [AllureStep("Edit Employee with username {0}, Salaray {1}, Duration worked {2}, email{3} and grade {4}")]
    public async Task editEmployeeDetails(string name, string salary, string durationWorked, string empGrade, string email)
    {
        await TypeTextAsync("#Name", name);
        await TypeTextAsync("#Salary", salary);
        await TypeTextAsync("#DurationWorked", durationWorked);
        await TypeTextAsync("#Email", email);
        await TypeTextAsync("#Grade", empGrade);
    }
    [AllureStep("click Save Button.")]
    public async Task clickSaveAsync()
    {
        await ClickElementAsync("[value='Save']");
    }
    
}