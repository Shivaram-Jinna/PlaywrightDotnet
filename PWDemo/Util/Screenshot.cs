using System.Net.NetworkInformation;
using System.Reflection;
using Allure.Commons;
using Microsoft.Playwright;

namespace PWDemo;
public static class Screenshot
{
    public static async Task takeScreenshot(IPage page, string stepDetail, Status status = Status.passed)
    {
        var SSPath = $"/Users/shivaramjinna/Desktop/PlaywrightDotnet/PWDemo/bin/Debug/net8.0/allure-results/ScreenShots/img-{Guid.NewGuid()}.png";
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = SSPath
        });
        AllureLifecycle.Instance.AddAttachment("screeshot", "image/png", SSPath);
    }

}