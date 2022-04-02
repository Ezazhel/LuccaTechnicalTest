using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class MissingCommentException : Exception
    {
        public MissingCommentException() : base("The property Comment is mandatory to create an expense")
        {
        }

        public MissingCommentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        private MissingCommentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}