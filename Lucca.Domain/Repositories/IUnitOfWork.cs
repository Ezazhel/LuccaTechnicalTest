using System.Threading;
using System.Threading.Tasks;

namespace Lucca.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}