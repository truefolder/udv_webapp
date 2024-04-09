using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using UDV_WebApp.Core.Abstractions;
using UDV_WebApp.Core.Models;
using UDV_WebApp.DataAccess.Entities;

namespace UDV_WebApp.DataAccess.Repositories
{
    public class CountResultRepository : IRepository<CountResult>
    {
        private readonly VkAppDbContext _context;

        public CountResultRepository(VkAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CountResult>> GetAll()
        {
            var countResultEntities = await _context.CountResultEntities
                .AsNoTracking()
                .ToListAsync();
            
            var countResults = countResultEntities
                .Select(c => new CountResult(c.Id, JsonSerializer.Deserialize<Dictionary<char, int>>(c.LettersCount)))
                .ToList();

            return countResults;
        }

        public async Task<Guid> Create(CountResult item)
        {
            var countResultEntity = new CountResultEntity
            {
                Id = item.Id,
                LettersCount = JsonSerializer.Serialize(item.LettersCount),
            };

            await _context.CountResultEntities.AddAsync(countResultEntity);
            await _context.SaveChangesAsync();

            return countResultEntity.Id;
        }
    }
}
