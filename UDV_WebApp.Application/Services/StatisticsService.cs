using UDV_WebApp.Core.Abstractions;
using UDV_WebApp.Core.Models;

namespace UDV_WebApp.Application.Services
{
    public class StatisticsService : IStatisticsService
    {
        IRepository<CountResult> _repository;

        public StatisticsService(IRepository<CountResult> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Регистронезависимо считает вхождение одинаковых букв в <paramref name="strings"/> и записывает результат в БД.
        /// </summary>
        /// <param name="strings">Строки</param>
        /// <returns>Словарь "символ - количество повторений в <paramref name="strings"/>"</returns>
        public async Task<Dictionary<char, int>> CountLetters(IEnumerable<string> strings)
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

            var result = letters.OrderBy(l => l.Key).ToDictionary();
            await _repository.Create(new CountResult(Guid.NewGuid(), result));

            return result;
        }
    }
}
