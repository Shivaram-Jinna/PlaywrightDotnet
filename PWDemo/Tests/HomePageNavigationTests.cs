namespace PWDemo;
public class HomePageNavigationTest : TestFixture
{
    public HomePageNavigationTest(string browserType) : base(browserType)
    {
    }

    [Test]
    public async Task navBarItems_TC9()
    {
        //step - 1: Navigate to HomePage
        await  _homePage.GoToHomePage();
        //step -2: Test Each Nav bar items
        await _homePage.ClickElementAsync("text=Home");
        string pageTitle = await _homePage.GetTitleAsync();
        Assert.That(pageTitle, Is.EquivalentTo("Home - Execute Automation Employee App"));
        await _homePage.ClickElementAsync("text=About");
        pageTitle = await _aboutPage.GetTitleAsync();
        Assert.That(pageTitle, Is.EquivalentTo("About - Execute Automation Employee App"));
        await _homePage.BrowserGoBack();
        await _homePage.ClickElementAsync("text=Register");
        pageTitle = await _registerPage.GetTitleAsync();
        Assert.That(pageTitle, Is.EquivalentTo("Register - Execute Automation Employee App"));
        await _homePage.BrowserGoBack();
        await _homePage.ClickElementAsync("text=Login");
        pageTitle = await _loginPage.GetTitleAsync();
        Assert.That(pageTitle, Is.EquivalentTo("Login - Execute Automation Employee App"));
        await _homePage.BrowserGoBack();
    }
    [Test]
    public async Task VerifyNavLinks_TC10()
    {
        await _homePage.GoToHomePage();
        var homepage_NavLinks = await _homePage.getNavItems();
        await _homePage.Click_NavLogin();
        var loginPage_NavLinks = await _loginPage.getNavItems();
        Assert.That(loginPage_NavLinks, Is.EqualTo(homepage_NavLinks));
        await _loginPage.Click_NavAbout();
        var aboutPage_NavLinks = await _aboutPage.getNavItems();
        Assert.That(aboutPage_NavLinks, Is.EqualTo(homepage_NavLinks));
        await _aboutPage.Click_NavEmployeeList();
        var employeePage_NavLinks = await _aboutPage.getNavItems();
        Assert.That(employeePage_NavLinks, Is.EqualTo(homepage_NavLinks));
        await _employeePage.Click_NavRegister();
        var registerPage_NavLinks = await _aboutPage.getNavItems();
        Assert.That(registerPage_NavLinks, Is.EqualTo(homepage_NavLinks));
        
    }
}