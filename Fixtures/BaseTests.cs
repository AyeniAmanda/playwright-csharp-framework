using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDemo.Fixtures;

public class BaseTest
{
    protected IPlaywright Playwright;
    protected IBrowser Browser;
    protected IBrowserContext Context;
    protected IPage Page;

    [SetUp]
    public async Task Setup()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await Playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 500
            });

        Context = await Browser.NewContextAsync();


        await Context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });


        Page = await Context.NewPageAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status
            == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            var screenshotPath = $"screenshot-{TestContext.CurrentContext.Test.Name}.png";
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = screenshotPath,
                FullPage = true
            });
            TestContext.AddTestAttachment(screenshotPath, "Failure Screenshot");
        }

        await Context.Tracing.StopAsync(new()
        {
            Path = $"trace-{TestContext.CurrentContext.Test.Name}.zip"
        });

        if (Context != null) await Context.CloseAsync();
        if (Browser != null) await Browser.CloseAsync();
        Playwright?.Dispose();
    }
}