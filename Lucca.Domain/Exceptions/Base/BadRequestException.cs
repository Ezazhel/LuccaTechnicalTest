using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions.Base
{
    [Serializable]
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message) : base(message)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}