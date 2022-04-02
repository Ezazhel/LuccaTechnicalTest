using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class OutOfIntervalExpensesDateException : Exception
    {
        public OutOfIntervalExpensesDateException() : base("The date can't be out of interval. The Interval is up to 3 month till now.")
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