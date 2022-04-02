using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class ExpensesDateInFuturException : Exception
    {
        public ExpensesDateInFuturException() : base("The date can't be set for the future.")
        {
        }

        public ExpensesDateInFuturException(string message, Exception innerException) : base(message, innerException)
        {
        }

        private ExpensesDateInFuturException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}