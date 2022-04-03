using Lucca.Domain.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class OutOfIntervalExpensesDateException : BadRequestException
    {
        public OutOfIntervalExpensesDateException() : base("The date can't be out of interval. The Interval is up to 3 month till now.")
        {
        }

        private OutOfIntervalExpensesDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}