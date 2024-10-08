using Allure.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using PWDemo;
using PWDemo.Pages;

//Enabling parallel runs at assembly level
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]
public class TestFixture
{
    protected IPlaywright _playwright;
    protected IBrowser _browser;
    protected IPage _page;
    private TestConfig _config;

    //All the pagename variables
    protected HomePage _homePage;
    protected LoginPage _loginPage;
    protected RegisterPage _registerPage;
    protected AboutPage _aboutPage;
    protected EmployeePage _employeePage;
    protected CreateEmployeePage _createEmployeePage;
    protected EditEmployeePage _editEmployeePage;
    protected DeleteEmployeePage _deleteEmployeePage;

    [SetUp]
    [AllureStep("Setting up test environment")]
    public async Task Setup()
    {

        //Load Test Environment Configurations.
         _config = ConfigLoader.LoadConfiguration();

        _playwright = await Playwright.CreateAsync();
        
        _browser = _config.BrowserType switch
            {
                "firefox" => await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = _config.Headless }),
                "webkit" => await _playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = _config.Headless }),
                _ => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = _config.Headless }),
            };

        
        _page = await _browser.NewPageAsync();
        
        // Initialize page objects
        _homePage = new HomePage(_page);
        _loginPage = new LoginPage(_page);
        _registerPage = new RegisterPage(_page);
        _aboutPage = new AboutPage(_page);
        _employeePage = new EmployeePage(_page);
        _createEmployeePage = new CreateEmployeePage(_page);
        _editEmployeePage = new EditEmployeePage(_page);
        _deleteEmployeePage = new DeleteEmployeePage(_page);
    }


    [TearDown]
    [AllureStep("Tearing down test environment")]
    public async Task TearDown()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
        
    }
}