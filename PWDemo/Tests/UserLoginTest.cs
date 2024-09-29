using Microsoft.Playwright;
using PWDemo.Pages;

namespace PWDemo;

public class HomePageTests : TestFixture
{
    [Test]
    public async Task HomeTest()
    {
        await _homePage.GoToHomePage();
        bool isExist = await _homePage.IsElementVisibleAsync("text=Home");
        Assert.That(isExist, "True");
    }
    
    
}