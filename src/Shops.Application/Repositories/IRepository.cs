using Microsoft.EntityFrameworkCore;
using Shops.Domain.Common;

namespace Shops.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}