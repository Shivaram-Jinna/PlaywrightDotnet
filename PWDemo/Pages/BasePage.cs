using System.Security.Cryptography.X509Certificates;
using Microsoft.Playwright;

public abstract class BasePage
{
    protected readonly IPage _page;

    public BasePage(IPage page)
    {
        _page = page;
    }

    // Common method for navigating to a URL
    public async Task GoToAsync(string url)
    {
        await _page.GotoAsync(url);
    }

    // Common method for clicking an element
    public async Task ClickElementAsync(string selector)
    {
        await _page.ClickAsync(selector);
    }

    // Common method for typing into an input field
    public async Task TypeTextAsync(string selector, string text)
    {
        await _page.FillAsync(selector, text);
    }
    //Common method to selection option in a drop down menu
    public async Task dropdownSelectAsync(string selector, string option)
    {
         await _page.SelectOptionAsync(selector, new[] { option });
    }

    // Common method for waiting for an element to be visible
    public async Task WaitForElementAsync(string selector)
    {
        await _page.WaitForSelectorAsync(selector);
    }

    // Common method for getting page title
    public async Task<string> GetTitleAsync()
    {
        return await _page.TitleAsync();
    }
    // Method to check if an element is visible
     public async Task<bool> IsElementVisibleAsync(string selector)
    {
        try
        {
            var element = await _page.QuerySelectorAsync(selector);
            return element != null && await element.IsVisibleAsync();
        }
        catch
        {
            return false;
        }
    }
    public async Task<string> getElementTextasync(string selector)
    {
            var textValue = await _page.Locator(selector).TextContentAsync();
            return textValue ?? String.Empty;            
    }
    public async Task takeScreenshot()
    {
        await _page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "/Users/shivaramjinna/Desktop/PlaywrightDotnet/PWDemo/Test_ScreenShots/screenshot.png" // Specify the file path
        });
    }
    public async Task<string> GetHeaderAsync()
    {
        return await _page.InnerTextAsync("h2");
    }
    public async Task BrowserGoBack()
    {
        await _page.GoBackAsync();
    }
    public async Task<List<string>> getNavItems()
    { 
        // Left nav bar
        var navLinks = await _page.Locator("ul.nav.navbar-nav li a").AllAsync(); 
        List<string> navTextList = new List<string>();
        foreach (var link in navLinks)
        {
            navTextList.Add((await link.TextContentAsync()).Trim());
        }
         return navTextList;
    }
    //Implementing Network Listneres - Where Url Is verified, if user is navigate to correct page.
    public async Task Click_NavHome()
    {
        await ClickElementAsync("text=Home");
    }
    public async Task Click_NavAbout()
    {
        await ClickElementAsync("text=About");
        await _page.WaitForURLAsync("**/About");
    }
    public async Task Click_NavEmployeeList()
    {
        //await _page.RunAndWaitForResponseAsync(async()=> await ClickElementAsync("text=Employee List"), x => x.Url.Contains("/Employee"));
        await _page.RunAndWaitForRequestAsync(async()=> await ClickElementAsync("text=Employee List"), x => x.Url.Contains("/Employee"));
    } 
    public async Task Click_NavLogin()
    {
        await ClickElementAsync("text=Login");
        
        await _page.WaitForURLAsync("**/Login");
    }
    public async Task Click_NavRegister()
    {
        await ClickElementAsync("text=Register");
        await _page.WaitForURLAsync("**/Register");
    }
    
}
