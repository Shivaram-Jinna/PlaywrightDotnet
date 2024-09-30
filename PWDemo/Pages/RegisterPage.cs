using Microsoft.Playwright;

namespace PWDemo.Pages;
public class RegisterPage : BasePage
{
    public RegisterPage(IPage page) : base(page)
    {

    }
    public async Task RegisterUser(string username, string password, string confirmPassword, string email)
    {
        await TypeTextAsync("#UserName", username);
        await TypeTextAsync("#Password", password);
        await TypeTextAsync("#ConfirmPassword", confirmPassword);
        await TypeTextAsync("#Email", email);
    } 
    public async Task clickRegister()
    {
        await ClickElementAsync("input[type='submit']");
    }
}