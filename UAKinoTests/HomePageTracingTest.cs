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
    public override BrowserNewContextOptions ContextOptions()
    {
        var options = new BrowserNewContextOptions();
        var proxyServer = Environment.GetEnvironmentVariable("PROXY_SERVER");
        
        if (!string.IsNullOrEmpty(proxyServer))
        {
            options.Proxy = new Proxy
            {
                Server = proxyServer,
                Username = Environment.GetEnvironmentVariable("PROXY_USERNAME"),
                Password = Environment.GetEnvironmentVariable("PROXY_PASSWORD")
            };
        }

        return options;
    }
    [Test]
    public async Task VisibleFilmBanner()
    {
        await Page.GotoAsync("https://uakino.best/ua/");
        await Page.Locator("html").ClickAsync();
        await Expect(Page.GetByRole(AriaRole.Banner)).ToContainTextAsync("ФІЛЬМИ");
    }
}