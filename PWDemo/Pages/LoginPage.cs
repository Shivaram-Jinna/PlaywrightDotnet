using Allure.NUnit.Attributes;
using Microsoft.Playwright;

namespace PWDemo.Pages;
public class LoginPage : BasePage
{
    public LoginPage(IPage page) : base(page){

    }
    [AllureStep("Enter {0} in to username text Field")]
    public async Task enterUsername(string username)
    {
        await TypeTextAsync("text = username", username);
    }
    [AllureStep("Enter {0} in to Password Field")]
    public async Task enterPassword(string password)
    {
        await TypeTextAsync("text = password", password);
    }
    [AllureStep("Login with Username {0} and Password {1}")]
    public async Task LoginAs(string uName, string password)
    {   
        await enterUsername(uName);
        await enterPassword(password);
        //await Screenshot.takeScreenshot(_page, "User Login");
    }
    [AllureStep("Click on Login Button")]
    public async Task clickLoginaAsync()
    {
        await ClickElementAsync("text = Log in");
    }
}