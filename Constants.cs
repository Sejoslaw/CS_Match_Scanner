namespace CsMatchScanner;

public static class Constants
{
    public static class Url
    {
        public const string HOME = "https://www.hltv.org";
        public const string RESULTS = $"{HOME}/results";
    }

    public static class Tag
    {
        public const string MATCH_LINK = "a";
    }

    public static class Attribute
    {
        public const string MATCH_LINK = "href";
    }

    public static class ClassName
    {
        public const string RESULTS = "result-con";
        public const string SINGLE_MAP = "mapholder";
        public const string SINGLE_MAP_NAME = "mapname";
        public const string TEAM_SCORE = "results-team-score";
    }
}