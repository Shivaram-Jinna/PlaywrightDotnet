using Allure.NUnit;
using Allure.NUnit.Attributes;

namespace PWDemo;
[AllureNUnit]
public class HomePageNavigationTest : TestFixture
{
    [Test]
    [AllureStep]
    [AllureDescription("Clicking Navigation bar links should navigate usr to appropiate pages.")]
    [AllureOwner("SJinna")]
    [AllureTag("Nunit", "SmokeTest","NavigationLinks")]
    [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    [AllureFeature("Navigation Functionality")]
    public async Task Verify_UserCanSwitch_ThroughNavigationLinks_TC8()
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
    [AllureStep]
    [AllureDescription("Navigation Links Should Be Consistent in all the pages.")]
    [AllureOwner("SJinna")]
    [AllureTag("Nunit", "SmokeTest","NavigationLinks")]
    [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
    [AllureFeature("Navigation Functionality")]
    public async Task Verify_UserSwitchPages_NavigationLinks_Consitant_TC9()
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