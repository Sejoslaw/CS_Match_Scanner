namespace CsMatchScanner.Contexts;

public class ScannerContext 
{
    public string HomeUrl { get; } = "https://www.hltv.org";
    public string ResultsUrl { get; }
    public IEnumerable<MatchContext> Matches { get; } = new HashSet<MatchContext>();

    public ScannerContext()
    {
        ResultsUrl = $"{HomeUrl}/results";
    }

    public void AddMatch(string matchUrl)
    {
        var matchContext = new MatchContext
        {
            Url = matchUrl
        };

        ((HashSet<MatchContext>)Matches).Add(matchContext);
    }
}