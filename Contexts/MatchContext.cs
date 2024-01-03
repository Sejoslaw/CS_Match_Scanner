namespace CsMatchScanner.Contexts;

public class MatchContext
{
    public string? Url { get; init; }
    public IEnumerable<MapContext> Maps { get; } = new HashSet<MapContext>();

    public void AddMap(MapContext ctx)
    {
        ((HashSet<MapContext>)Maps).Add(ctx);
    }
}