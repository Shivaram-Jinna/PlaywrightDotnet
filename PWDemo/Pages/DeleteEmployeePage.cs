using Microsoft.Playwright;

namespace PWDemo.Pages;
public class DeleteEmployeePage : BasePage
{
    public DeleteEmployeePage(IPage page) : base(page){

    }
    public async Task clickDeleteAsync()
    {
        await ClickElementAsync("[value='Delete']");
    }
}