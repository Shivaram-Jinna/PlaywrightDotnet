using Microsoft.Playwright;

public static class BrowserFactory
{
    public static async Task<IBrowser> GetBrowserAsync(IPlaywright playwright)
    {
        var browserName = Environment.GetEnvironmentVariable("BROWSER") ?? "chromium";

        return browserName switch
        {
            "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
            "webkit" => await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
            _ => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
        };
    }
}