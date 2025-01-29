using Microsoft.Playwright;

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
    public async Task enterUsername(string username)
    {
        await UserNameInput.FillAsync(username);
    }
    public async Task enterPassword(string password)
    {
        await PasswordInput.FillAsync(password);
    }
    public async Task enterConfirmPassword(string confirmPassword)
    {
        await ConfirmPasswordInput.FillAsync(confirmPassword);
    }
    public async Task enterEmail(string emailID)
    {
        await EmailInput.FillAsync(emailID);
    }
    public async Task RegisterUser(string username, string password, string confirmPassword, string email)
    {
        await enterUsername(username);
        await enterPassword(password);
        await enterConfirmPassword(confirmPassword);
        await enterEmail(email);
    }
    public async Task clickRegisterAsync()
    {
        await RegisterButton.ClickAsync();
    }
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