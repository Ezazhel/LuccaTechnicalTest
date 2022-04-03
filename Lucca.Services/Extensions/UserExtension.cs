using Lucca.Contracts;
using Lucca.Domain.Entities;

namespace Lucca.Services.Extensions
{
    public static class UserExtension
    {
        public static UserDto ToUserDto(this User user) => new UserDto
        {
            Currency_ISO = user.Currency_ISO,
            FullName = user.GetFullName(),
            Id = user.Id
        };
    }
}