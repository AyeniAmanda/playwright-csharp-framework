using NUnit.Framework;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using PlaywrightDemo.Fixtures;
using PlaywrightDemo.Pages;


namespace PlaywrightDemo.Tests;

public class LoginTests : BaseTest
{
    [Test]
    public async Task SuccessfulLogin()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.Navigate();

        await loginPage.Login(
            "tomsmith",
            "SuperSecretPassword!");

        await Assertions.Expect(loginPage.SuccessMessage)
     .ToContainTextAsync("You logged into a secure area!");
    }

    [Test]
    public async Task FailedLogin_WrongPassword()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.Navigate();
        await loginPage.Login("tomsmith", "wrongpassword");

        await Expect(loginPage.ErrorMessage)
            .ToContainTextAsync("Your password is invalid!");
    }

    [Test]
    public async Task FailedLogin_EmptyFields()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.Navigate();
        await loginPage.Login("", "");

        await Expect(loginPage.ErrorMessage)
            .ToContainTextAsync("Your username is invalid!");
    }
}