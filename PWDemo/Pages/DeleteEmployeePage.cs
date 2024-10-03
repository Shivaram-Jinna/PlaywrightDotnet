using Allure.NUnit.Attributes;
using Microsoft.Playwright;

namespace PWDemo.Pages;
public class DeleteEmployeePage : BasePage
{
    public DeleteEmployeePage(IPage page) : base(page){

    }
    [AllureStep("Click Delete Employee")]
    public async Task clickDeleteAsync()
    {
        await ClickElementAsync("input[Value='Delete']");
    }

    [AllureStep("Click Delete Employee")]
    public async Task clickBackToListAsync()
    {
        await ClickElementAsync("text=Back to List");
    }
}