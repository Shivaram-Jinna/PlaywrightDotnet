using Microsoft.Playwright;
using NUnit.Framework;

namespace PWDemo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        //Create Playwright Instance 
        using var pw = await Playwright.CreateAsync();
        //Create a Browser instance, using our Playwright obj 'pw'
        await using var browser = await pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions{
            Headless = false
        });
        //Opening the Url using the browser instance
        var page = await browser.NewPageAsync();

        // navigating to website
        await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        await page.ClickAsync("text=Login");
        await page.ScreenshotAsync(new PageScreenshotOptions{
            Path = "OrangeHRM.png" 
        });


    }
}