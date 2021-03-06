using Lucca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lucca.Domain.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    }
}