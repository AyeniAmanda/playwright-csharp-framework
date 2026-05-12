using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class DropdownPage
{
    private readonly IPage _page;

    private const string Url = "https://the-internet.herokuapp.com/dropdown";

    public DropdownPage(IPage page)
    {
        _page = page;
    }

    public async Task Navigate()
    {
        await _page.GotoAsync(Url);
    }

    public async Task SelectOption(string option)
    {
        await _page.SelectOptionAsync("#dropdown", new SelectOptionValue { Label = option });
    }

    public ILocator Dropdown => _page.Locator("#dropdown");
}