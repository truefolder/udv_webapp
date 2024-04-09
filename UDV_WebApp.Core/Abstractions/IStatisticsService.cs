namespace UDV_WebApp.Core.Abstractions
{
    public interface IStatisticsService
    {
        Dictionary<char, int> CountLetters(IEnumerable<string> strings);
    }
}
