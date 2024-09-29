using Microsoft.Playwright;

namespace PWDemo.Pages;
public class HomePage : BasePage
{
    // Constructor to initialize the Homepage Object - We Use base class implementation.
    public HomePage(IPage page) : base(page){

    }
    // Navigate to home page
    public async Task GoToHomePage()
    {
        await GoToAsync("http://www.eaapp.somee.com");
    }
    
}