using System.Reflection;
using System.Text;
using Allure.Commons;
using Microsoft.Playwright;
namespace PWDemo;
public static class TestUtils
{
    // Random username generator
    public static string GenerateRandomUsername(int length = 6)
    {
        string prefix = "User";
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var randomString = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            randomString.Append(chars[random.Next(chars.Length)]);
        }
        return $"{prefix}{randomString}";
    }

    // Random email generator
    public static string GenerateRandomEmail()
    {
        return $"{GenerateRandomUsername()}@example.com";
    }
    // ScreenShotMethod
    public static async Task take_ScreenShot(IPage page, string stepDetail, Status status = Status.passed)
    {
        if (AllureLifecycle.Instance == null)
        {
            throw new InvalidOperationException("Allure lifecycle is not properly initialized.");
        }
        byte[] bytes = await page.ScreenshotAsync(new PageScreenshotOptions{
            Path=$"/Users/shivaramjinna/Desktop/PlaywrightDotnet/PWDemo/bin/Debug/net8.0/Test_ScreenShots/{stepDetail}.png"
        });
        AllureLifecycle.Instance.AddAttachment(stepDetail, "image/png", bytes);
    }
}