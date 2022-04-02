using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class CurrencyIsDifferentFromUserException : Exception
    {
        public CurrencyIsDifferentFromUserException() : base("The currency for this expense is different from the user's one.")
        {
        }

        public CurrencyIsDifferentFromUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        private CurrencyIsDifferentFromUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}