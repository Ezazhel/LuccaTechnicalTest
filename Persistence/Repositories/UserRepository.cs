using Lucca.Domain.Entities;
using Lucca.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default) => await FindByCondition(user => user.Id.Equals(userId)).FirstOrDefaultAsync();
    }
}