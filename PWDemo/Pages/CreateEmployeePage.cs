using Microsoft.Playwright;

namespace PWDemo.Pages;
public class CreateEmployeePage : BasePage
{
    public CreateEmployeePage(IPage page) : base(page){

    }

    public async Task addEmployeeDetails(string name, string salary, string durationWorked, string empGrade, string email)
    {
        await TypeTextAsync("#Name", name);
        await TypeTextAsync("#Salary", salary);
        await TypeTextAsync("#DurationWorked", durationWorked);
        await TypeTextAsync("#Email", email);
        await dropdownSelectAsync("#Grade", empGrade); 
    }
    public async Task clickCreateAsync()
    {
        await ClickElementAsync("[value='Create']");
    }
    
}