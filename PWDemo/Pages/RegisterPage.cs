using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using NUnit.Framework.Constraints;

namespace PWDemo.Pages;
public class RegisterPage : BasePage
{
    public RegisterPage(IPage page) : base(page)
    {

    }
    [AllureStep("Register new User with Username {0}, Password {1}, Confirm Password {2}, Email {3}, And click on Register Button")]
    public async Task RegisterUser(string username, string password, string confirmPassword, string email)
    {
        await TypeTextAsync("#UserName", username);
        await TypeTextAsync("#Password", password);
        await TypeTextAsync("#ConfirmPassword", confirmPassword);
        await TypeTextAsync("#Email", email);
    }
    [AllureStep("Click on Register Button")]
    public async Task clickRegisterAsync()
    {
        await ClickElementAsync("input[type='submit']");
    }
}