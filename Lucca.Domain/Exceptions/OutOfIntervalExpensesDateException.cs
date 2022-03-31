using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class OutOfIntervalExpensesDateException : Exception
    {
        public OutOfIntervalExpensesDateException()
        {
        }

        public OutOfIntervalExpensesDateException(string message) : base(message)
        {
        }

        public OutOfIntervalExpensesDateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        private OutOfIntervalExpensesDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}