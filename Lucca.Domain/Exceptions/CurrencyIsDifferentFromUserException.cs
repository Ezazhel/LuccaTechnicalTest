using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class CurrencyIsDifferentFromUserException : Exception
    {
        public CurrencyIsDifferentFromUserException()
        {
        }

        public CurrencyIsDifferentFromUserException(string message) : base(message)
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