namespace UDV_WebApp.Core.Abstractions
{
    public interface IStatisticsService
    {
        Task<Dictionary<char, int>> CountLetters(IEnumerable<string> strings);
    }
}
