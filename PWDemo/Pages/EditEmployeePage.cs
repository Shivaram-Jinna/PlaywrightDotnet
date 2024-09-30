using Microsoft.Playwright;

namespace PWDemo.Pages;
public class EditEmployeePage : BasePage
{
    public EditEmployeePage(IPage page) : base(page){

    }

    public async Task editEmployeeDetails(string name, string salary, string durationWorked, string empGrade, string email)
    {
        await TypeTextAsync("#Name", name);
        await TypeTextAsync("#Salary", salary);
        await TypeTextAsync("#DurationWorked", durationWorked);
        await TypeTextAsync("#Email", email);
        await TypeTextAsync("#Grade", empGrade); 
    }
    public async Task clickSaveAsync()
    {
        await ClickElementAsync("[value='Save']");
    }
    
}