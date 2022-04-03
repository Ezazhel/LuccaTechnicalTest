using Lucca.Domain.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class DuplicateExpensesException : BadRequestException
    {
        public DuplicateExpensesException() : base("This expense is duplicate.")
        {
        }

        private DuplicateExpensesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}