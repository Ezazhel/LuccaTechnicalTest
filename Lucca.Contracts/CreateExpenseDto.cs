using System;

namespace Lucca.Contracts
{
    public sealed class CreateExpenseDto
    {
        public DateTime Date { get; set; }
        public int Category { get; set; }
        public decimal Amount { get; set; }
        public string Currency_ISO { get; set; }
        public string Comment { get; set; }
    }
}