using System;

namespace Lucca.Contracts
{
    public sealed class ExpenseDto
    {
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Currency_ISO { get; set; }
        public string Comment { get; set; }
    }
}