using Lucca.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lucca.Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken = default);
    }
}