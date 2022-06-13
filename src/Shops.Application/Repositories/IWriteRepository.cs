using Shops.Domain.Common;

namespace Shops.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model, CancellationToken cancellationToken);

        bool Remove(T model);

        bool Update(T model);

        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}