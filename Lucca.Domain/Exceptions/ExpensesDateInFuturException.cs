using Lucca.Domain.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace Lucca.Domain.Exceptions
{
    [Serializable]
    public sealed class ExpensesDateInFuturException : BadRequestException
    {
        public ExpensesDateInFuturException() : base("The date can't be set for the future.")
        {
        }

        private ExpensesDateInFuturException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}