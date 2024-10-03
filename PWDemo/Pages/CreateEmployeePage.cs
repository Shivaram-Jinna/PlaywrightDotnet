using Allure.NUnit.Attributes;
using Microsoft.Playwright;

namespace PWDemo.Pages;
public class CreateEmployeePage : BasePage
{
    public CreateEmployeePage(IPage page) : base(page){

    }
    [AllureStep("Creating new Employee with username {0}, Salaray {1}, Duration worked {2}, email{3} and grade {4}, and click Save")]
    public async Task addEmployeeDetails(string name, string salary, string durationWorked, string empGrade, string email)
    {
        await TypeTextAsync("#Name", name);
        await TypeTextAsync("#Salary", salary);
        await TypeTextAsync("#DurationWorked", durationWorked);
        await TypeTextAsync("#Email", email);
        await dropdownSelectAsync("#Grade", empGrade);
    }
    [AllureStep("Click on Create Button")]
    public async Task clickCreateAsync()
    {
        await ClickElementAsync("[value='Create']");  
    }
    
}