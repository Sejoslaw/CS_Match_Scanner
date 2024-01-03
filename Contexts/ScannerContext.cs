namespace CsMatchScanner.Contexts;

public class ScannerContext 
{
    public IEnumerable<MatchContext> Matches { get; } = new HashSet<MatchContext>();

    public void AddMatch(MatchContext ctx)
    {
        ((HashSet<MatchContext>)Matches).Add(ctx);
    }
}