using Lucca.Domain.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class MissingCommentException : BadRequestException
    {
        public MissingCommentException() : base("The property Comment is mandatory to create an expense")
        {
        }

        private MissingCommentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}