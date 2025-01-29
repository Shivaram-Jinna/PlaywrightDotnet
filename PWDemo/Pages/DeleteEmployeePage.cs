
using Microsoft.Playwright;

namespace PWDemo.Pages;
public class DeleteEmployeePage : BasePage
{
    public DeleteEmployeePage(IPage page) : base(page){

    }
    //page specific Web Elements and locators
    private ILocator DeleteButton => _page.Locator("[value='Delete']");
    private ILocator backToListButton => _page.Locator("text=Back to List");
    public async Task clickDeleteAsync()
    {
        await DeleteButton.ClickAsync();
    }
    public async Task clickBackToListAsync()
    {
        await backToListButton.ClickAsync();
    }
}