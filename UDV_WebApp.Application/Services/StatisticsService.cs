using UDV_WebApp.Core.Abstractions;

namespace UDV_WebApp.Application.Services
{
    public class StatisticsService : IStatisticsService
    {
        public StatisticsService()
        {
        }

        /// <summary>
        /// Регистронезависимо считает вхождение одинаковых букв в <paramref name="strings"/>
        /// </summary>
        /// <param name="strings">Строки</param>
        /// <returns>Словарь "символ - количество повторений в <paramref name="strings"/>"</returns>
        public Dictionary<char, int> CountLetters(IEnumerable<string> strings)
        {
            var letters = new Dictionary<char, int>();
            foreach (var str in strings)
            {
                foreach (var letter in str.ToLower())
                {
                    if (letters.ContainsKey(letter))
                        letters[letter]++;
                    else
                        letters[letter] = 1;
                }
            }

            return letters.OrderBy(l => l.Key).ToDictionary();
        }
    }
}
