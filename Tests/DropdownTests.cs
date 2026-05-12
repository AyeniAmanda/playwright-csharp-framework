using NUnit.Framework;
using static Microsoft.Playwright.Assertions;
using PlaywrightDemo.Fixtures;
using PlaywrightDemo.Pages;

namespace PlaywrightDemo.Tests;

public class DropdownTests : BaseTest
{
    [Test]
    public async Task CanSelectOption1()
    {
        var dropdownPage = new DropdownPage(Page);
        await dropdownPage.Navigate();
        await dropdownPage.SelectOption("Option 1");

        await Expect(dropdownPage.Dropdown).ToHaveValueAsync("1");
    }

    [Test]
    public async Task CanSelectOption2()
    {
        var dropdownPage = new DropdownPage(Page);
        await dropdownPage.Navigate();
        await dropdownPage.SelectOption("Option 2");

        await Expect(dropdownPage.Dropdown).ToHaveValueAsync("2");
    }
}