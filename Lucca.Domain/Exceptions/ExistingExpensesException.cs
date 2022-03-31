using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class ExistingExpensesException : Exception
    {
        public ExistingExpensesException()
        {
        }

        public ExistingExpensesException(string message) : base(message)
        {
        }

        public ExistingExpensesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        private ExistingExpensesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}