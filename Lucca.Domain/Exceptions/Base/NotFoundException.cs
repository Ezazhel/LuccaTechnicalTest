using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions.Base
{
    [Serializable]
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}