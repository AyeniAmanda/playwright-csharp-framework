using NUnit.Framework;
using static Microsoft.Playwright.Assertions;
using PlaywrightDemo.Fixtures;
using PlaywrightDemo.Pages;

namespace PlaywrightDemo.Tests;

public class SecureAreaTests : BaseTest
{
    [Test]
    public async Task CanAccessSecureAreaAfterLogin()
    {
        var loginPage = new LoginPage(Page);
        var securePage = new SecurePage(Page);

        await loginPage.Navigate();
        await loginPage.Login("tomsmith", "SuperSecretPassword!");

        await Expect(securePage.Header).ToBeVisibleAsync();
        await Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/secure");
    }

    [Test]
    public async Task CanLogoutFromSecureArea()
    {
        var loginPage = new LoginPage(Page);
        var securePage = new SecurePage(Page);

        await loginPage.Navigate();
        await loginPage.Login("tomsmith", "SuperSecretPassword!");
        await securePage.Logout();

        await Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/login");
        await Expect(loginPage.SuccessMessage)
            .ToContainTextAsync("You logged out of the secure area!");
    }
}