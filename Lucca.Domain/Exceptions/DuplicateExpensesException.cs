using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class DuplicateExpensesException : Exception
    {
        public DuplicateExpensesException() : base("This expense is duplicate.")
        {
        }

        public DuplicateExpensesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        private DuplicateExpensesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}