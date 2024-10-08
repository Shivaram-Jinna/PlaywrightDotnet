using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using NUnit.Framework.Constraints;

namespace PWDemo.Pages;
public class RegisterPage : BasePage
{
    public RegisterPage(IPage page) : base(page)
    {

    }
    //page specific Web Elements and locators
    private ILocator UserNameInput => _page.Locator("#UserName");
    private ILocator PasswordInput => _page.Locator("#Password");
    private ILocator ConfirmPasswordInput => _page.Locator("#ConfirmPassword");    
    private ILocator EmailInput => _page.Locator("#Email");
    private ILocator RegisterButton => _page.Locator("input[type='submit']");

    //Decalring enum to make the page elementNames easliy accessable.
    public enum RegisterPageElements
    {
        UserNameInput,
        PasswordInput,
        ConfirmPasswordInput,
        EmailInput,
        RegisterButton
    }

    public ILocator GetLocatorByName(RegisterPageElements elementName)
    {
        return elementName switch
        {
            RegisterPageElements.UserNameInput => UserNameInput,
            RegisterPageElements.PasswordInput => PasswordInput,
            RegisterPageElements.ConfirmPasswordInput => ConfirmPasswordInput,
            RegisterPageElements.EmailInput => EmailInput,
            RegisterPageElements.RegisterButton => RegisterButton,
            _ => throw new ArgumentException($"No locator found for element name: {elementName}", nameof(elementName))
        };
    }
    [AllureStep("Enter {0} in to username text Field")]
    public async Task enterUsername(string username)
    {
        await UserNameInput.FillAsync(username);
    }
    [AllureStep("Enter {0} in to Password Field")]
    public async Task enterPassword(string password)
    {
        await PasswordInput.FillAsync(password);
    }
    [AllureStep("Enter {0} in to Confirm Password Field")]
    public async Task enterConfirmPassword(string confirmPassword)
    {
        await ConfirmPasswordInput.FillAsync(confirmPassword);
    }
    [AllureStep("Enter {0} in to Email Field")]
    public async Task enterEmail(string emailID)
    {
        await EmailInput.FillAsync(emailID);
    }
    [AllureStep("Register new User with Username {0}, Password {1}, Confirm Password {2}, Email {3}, And click on Register Button")]
    public async Task RegisterUser(string username, string password, string confirmPassword, string email)
    {
        await enterUsername(username);
        await enterPassword(password);
        await enterConfirmPassword(confirmPassword);
        await enterEmail(email);
    }
    [AllureStep("Click on Register Button")]
    public async Task clickRegisterAsync()
    {
        await RegisterButton.ClickAsync();
    }
    [AllureStep("Verify Error Messages in the following Order: {0}")]
    public async Task ValidateErrorMessages(List<string> expectedErrorMessagesList)
    {
        var errorMessagesGroup = await _page.Locator(".text-danger").GetByRole(AriaRole.Listitem).AllAsync();
        List<string> actualErrorMessagesList = new List<string>();
        foreach(var errorMessage in errorMessagesGroup)
        {
            actualErrorMessagesList.Add(await errorMessage.TextContentAsync());
        }
        Assert.That(actualErrorMessagesList, Is.EqualTo(expectedErrorMessagesList));
        
    }
}