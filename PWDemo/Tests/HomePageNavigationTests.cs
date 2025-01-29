namespace PWDemo;
public class HomePageNavigationTest : TestFixture
{
    [Test]
    public async Task Verify_UserCanSwitch_ThroughNavigationLinks_TC8()
    {
        //step - 1: Navigate to HomePage
        await  _homePage.GoToHomePage();
        //step -2: Test Each Nav bar items
        await _homePage.Click_NavBar_Home();
        await _homePage.Click_NavBar_About();
        await _homePage.Click_NavBar_EmployeeList();
        await _homePage.Click_NavBar_Register();
        await _homePage.Click_NavBar_Login();
    }
    [Test]
    public async Task Verify_UserSwitchPages_NavigationLinks_Consitant_TC9()
    {
        await _homePage.GoToHomePage();
        var homepage_NavLinks = await _homePage.getNavItems();
        await _homePage.Click_NavBar_Login();
        var loginPage_NavLinks = await _loginPage.getNavItems();
        Assert.That(loginPage_NavLinks, Is.EqualTo(homepage_NavLinks));
        await _loginPage.Click_NavBar_About();
        var aboutPage_NavLinks = await _aboutPage.getNavItems();
        Assert.That(aboutPage_NavLinks, Is.EqualTo(homepage_NavLinks));
        await _aboutPage.Click_NavBar_EmployeeList();
        var employeePage_NavLinks = await _aboutPage.getNavItems();
        Assert.That(employeePage_NavLinks, Is.EqualTo(homepage_NavLinks));
        await _employeePage.Click_NavBar_Register();
        var registerPage_NavLinks = await _aboutPage.getNavItems();
        Assert.That(registerPage_NavLinks, Is.EqualTo(homepage_NavLinks));  
    }
}