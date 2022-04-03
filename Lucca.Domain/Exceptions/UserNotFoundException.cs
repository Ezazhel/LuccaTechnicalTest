using Lucca.Domain.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid userId) : base($"The user with the id {userId} was not found.")
        {
        }

        private UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}