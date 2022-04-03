using Lucca.Contracts;
using Lucca.Domain.Entities;
using Lucca.Domain.Repositories;
using Lucca.Services.Abstractions;
using Lucca.Services.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lucca.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<User> users = await _repositoryManager.UserRepository.GetAllUsersAsync(cancellationToken);

            IEnumerable<UserDto> usersDto = users.Select(user => user.ToUserDto());

            return usersDto;
        }
    }
}