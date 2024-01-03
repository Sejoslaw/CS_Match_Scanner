namespace CsMatchScanner;

using Contexts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Scanner
{
    public ScannerContext Context { get; } = new();
    public IWebDriver Driver { get; } = new ChromeDriver();

    public void Run()
    {
        var offset = 0;
        
        do
        {
            Driver.Navigate().GoToUrl($"{Constants.Url.RESULTS}?offset={offset}");
            
            Thread.Sleep(30 * 100);

            var resultNodes = Driver.FindElements(By.ClassName(Constants.ClassName.RESULTS));

            resultNodes
                .Select(node => node.FindElement(By.TagName(Constants.Tag.MATCH_LINK)).GetAttribute(Constants.Attribute.MATCH_LINK))
                .ToList()
                .ForEach(ProcessMatch);
            
            offset += resultNodes.Count;
        } while (offset % 100 == 0);
    }

    private void ProcessMatch(string matchUrl)
    {
        var matchCtx = new MatchContext
        {
            Url = matchUrl
        };
        
        ProcessMatch(matchCtx);
        
        Context.AddMatch(matchCtx);
    }

    private void ProcessMatch(MatchContext ctx)
    {
        Driver.Navigate().GoToUrl(ctx.Url);
        
        Thread.Sleep(30 * 100);

        var mapNodes = Driver
            .FindElements(By.ClassName(Constants.ClassName.SINGLE_MAP));

        foreach (var mapNode in mapNodes)
        {
            var scoreNodes = mapNode
                .FindElements(By.ClassName(Constants.ClassName.TEAM_SCORE))
                .Select(node => node.Text)
                .ToList();
            
            var mapCtx = new MapContext
            {
                MapName = mapNode.FindElement(By.ClassName(Constants.ClassName.SINGLE_MAP_NAME)).Text,
                ScoreTeam1 = scoreNodes[0],
                ScoreTeam2 = scoreNodes[1]
            };
            
            ctx.AddMap(mapCtx);
        }
    }
}