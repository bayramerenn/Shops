using Shops.Domain.Common;
using System.Linq.Expressions;

namespace Shops.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool tracking = true);
    }
}