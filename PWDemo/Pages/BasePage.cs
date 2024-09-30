using Microsoft.Playwright;
using System.Threading.Tasks;

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
            return false; // Return false if an error occurs (element not found, etc.)
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
    
}
