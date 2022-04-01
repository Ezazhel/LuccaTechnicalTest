using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(Guid userId) : base($"The user with the id {userId} was not found.")
        {
        }

        private UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}