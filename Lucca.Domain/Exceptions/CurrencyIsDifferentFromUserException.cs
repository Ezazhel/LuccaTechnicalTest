using Lucca.Domain.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class CurrencyIsDifferentFromUserException : BadRequestException
    {
        public CurrencyIsDifferentFromUserException() : base("The currency for this expense is different from the user's one.")
        {
        }

        private CurrencyIsDifferentFromUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}