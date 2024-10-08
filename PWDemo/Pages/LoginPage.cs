using System.ComponentModel.DataAnnotations;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;

namespace PWDemo.Pages;
public class LoginPage : BasePage
{
    public LoginPage(IPage page) : base(page){

    }
    //page specific Web Elements and locators
    private ILocator UserNameInput => _page.Locator("#UserName");
    private ILocator PasswordInput => _page.Locator("#Password");
    private ILocator loginButton => _page.Locator("input[type='submit']");
    private ILocator invalidLoginError => _page.Locator(".text-danger").GetByRole(AriaRole.Listitem);
    private ILocator UserNameError => _page.Locator("span[data-valmsg-for='UserName']");
    private ILocator PasswordError => _page.Locator("span[data-valmsg-for='Password']");
    
    //Decalring enum to make the page elementNames easliy accessable.
    public enum loginPageElements
    {
        UserNameInput,
        PasswordInput,
        loginButton,
        invalidLoginError,
        UserNameError,
        PasswordError
    }
    //Common method to get element, with string input
    public ILocator GetLocatorByName(loginPageElements elementName)
    {
        return elementName switch
        {
            loginPageElements.UserNameInput => UserNameInput,
            loginPageElements.PasswordInput => PasswordInput,
            loginPageElements.loginButton => loginButton,
            loginPageElements.invalidLoginError => invalidLoginError,
            loginPageElements.UserNameError => UserNameError,
            loginPageElements.PasswordError => PasswordError,
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

    [AllureStep("Login with Username {0} and Password {1}")]
    public async Task LoginAs(string uName, string password)
    {   
        await enterUsername(uName);
        await enterPassword(password);
    }

    [AllureStep("Click on Login Button")]
    public async Task clickLoginAsync()
    {
        await loginButton.ClickAsync();
    }
    
    [AllureStep("Verify {1} is displayed")]
    public async Task validateErrorMessage(loginPageElements errMessageElement, string expectedErrorMessage)
    {
        ILocator element = GetLocatorByName(errMessageElement);
        if (string.IsNullOrEmpty(expectedErrorMessage))
        {
            throw new ArgumentException("Expected error message cannot be null or empty.", nameof(expectedErrorMessage));
        }
        string actualErrorMessage = String.Empty;
        try{
            if(element != null)
            {
                actualErrorMessage = await element.TextContentAsync() ?? String.Empty;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error Occured : {ex.Message}");
        }
        Assert.That(expectedErrorMessage,Is.EqualTo(actualErrorMessage.Trim()), $"Error Message does not match Expected: '{expectedErrorMessage}', Actual: '{actualErrorMessage?.Trim()}'");
        
    }
}