using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class MissingCommentException : Exception
    {
        public MissingCommentException()
        {
        }

        public MissingCommentException(string message) : base(message)
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