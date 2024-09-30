using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;
using PWDemo.Pages;

public class TestFixture
{
    protected IPlaywright _playwright;
    protected IBrowser _browser;
    protected IPage _page;
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
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
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
    public async Task TearDown()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}
