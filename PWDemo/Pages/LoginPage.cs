using Microsoft.Playwright;

namespace PWDemo.Pages;
public class LoginPage : BasePage
{
    // Constructor to initialize the Homepage Object - We Use base class implementation.
    public LoginPage(IPage page) : base(page){

    }
    // Navigate to home page
    public async Task EnterCredentials(string username, string password)
    {
        await TypeTextAsync("text = username", username);
        await TypeTextAsync("text = password", password);
    }
    public async Task ClickLoginButton()
    {
        await ClickElementAsync("text = Log in");
    }
    
}