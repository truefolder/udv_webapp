using UDV_WebApp.Core.Models;

namespace UDV_WebApp.Core.Abstractions
{
    public interface IRepository<T> where T : Model
    {
        Task<List<T>> GetAll();

        Task<Guid> Create(T item);
    }
}
