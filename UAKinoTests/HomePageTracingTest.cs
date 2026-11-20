namespace UAKino.UiTests.UAKinoTests;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HomePageTracingTest : PageTest
{
    /*[SetUp]
    public async Task Setup()
    {
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                "../../../PagesTested/",
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }*/
    
    [Test]
    public async Task VisibleFilmBanner()
    {
        await Page.GotoAsync("https://uakino.best/ua/");
        await Page.Locator("html").ClickAsync();
        await Expect(Page.GetByRole(AriaRole.Banner)).ToContainTextAsync("ФІЛЬМИ");
    }
}