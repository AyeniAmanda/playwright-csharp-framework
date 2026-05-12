using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class SecurePage
{
    private readonly IPage _page;

    public SecurePage(IPage page)
    {
        _page = page;
    }

    public async Task Logout()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).ClickAsync();
    }

    public ILocator Header => _page.GetByRole(AriaRole.Heading, new() { Name = "Secure Area", Exact = true });
}