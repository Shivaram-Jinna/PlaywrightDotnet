namespace PWDemo;
public class HomePageNavigationTest : TestFixture
{
    [Test]
    [Category("SmokeTests")]
    public async Task navBarItems_TC9()
    {
        //step - 1: Navigate to HomePage
        await  _homePage.GoToHomePage();
        //step -2: Test Each Nav bar items
        await _homePage.Click_NavHome();
        await _homePage.Click_NavAbout();
        
        await _homePage.Click_NavEmployeeList();

        await _homePage.Click_NavRegister();
        await _homePage.Click_NavLogin();
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
    [Test]
    public async Task AmazonTrackinginfo()
    {
        await _homePage.GoToAsync("")
    }
}