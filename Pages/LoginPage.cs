using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }
    private const string Url = "https://the-internet.herokuapp.com/login";


    public async Task Navigate()
    {
        await _page.GotoAsync(Url);
    }

    public async Task Login(string username, string password)
    {
        await _page.GetByLabel("Username").FillAsync(username);
        await _page.GetByLabel("Password").FillAsync(password);
        await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
    }

    public ILocator SuccessMessage => _page.Locator("#flash.success");
    public ILocator ErrorMessage => _page.Locator("#flash.error");

}