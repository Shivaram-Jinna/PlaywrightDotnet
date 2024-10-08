using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using PWDemo;

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
     public async Task IsElementVisibleAsync(string selector)
    {
        bool isExist;
        try
        {
            var element = await _page.QuerySelectorAsync(selector);
            isExist = element != null ? await element.IsVisibleAsync() : false;
        }
        catch(NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
            isExist = false;
        }
        Assert.That(isExist, Is.True);
    }
    public async Task<string> getElementTextasync(string selector)
    {
            var textValue = await _page.Locator(selector).TextContentAsync();
            return textValue ?? String.Empty;            
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

    //Implemented Network Listneres for all the navigation links
    //Url Is verified, if user is navigate to correct page.
    [AllureStep("Click on Home on navigation bar.")]
    public async Task Click_NavBar_Home()
    {
        await _page.ClickAsync("text=Home");
        await _page.WaitForURLAsync("http://www.eaapp.somee.com/"); 
    }
    [AllureStep("Click on Abuot on navigation bar.")]
    public async Task Click_NavBar_About()
    {
        await _page.ClickAsync("text=About");
        await _page.WaitForURLAsync("http://www.eaapp.somee.com/Home/About");
    }
    [AllureStep("Click on Employee list on navigation bar.")]
    public async Task Click_NavBar_EmployeeList()
    {
        await _page.ClickAsync("text=Employee");
        await _page.WaitForURLAsync("http://www.eaapp.somee.com/Employee");
    }
    [AllureStep("Click on Login on navigation bar.")] 
    public async Task Click_NavBar_Login()
    {
        await _page.ClickAsync("text=Login");
        await _page.WaitForURLAsync("http://www.eaapp.somee.com/Account/Login");
    }
    [AllureStep("Click on Register on navigation bar.")]
    public async Task Click_NavBar_Register()
    {
        await _page.ClickAsync("text=Register");
        await _page.WaitForURLAsync("http://www.eaapp.somee.com/Account/Register");
    }
    [AllureStep("Logout of User account.")]
    public async Task Click_NavBar_LogOff()
    {
        await _page.ClickAsync("text=Log off");
    }
    [AllureStep("Verify username is {0} on manage account Section on Naviagtion bar.")]
    public async Task validate_AccountName(string uName)
    {   
        var actualUsername =  await _page.GetByTitle("Manage").InnerTextAsync();
        var expectedUsername = $"Hello {uName}!";
        Assert.That(actualUsername, Is.EqualTo(expectedUsername));
    }
}
