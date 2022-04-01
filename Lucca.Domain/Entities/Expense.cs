using System;

namespace Lucca.Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public decimal Amount { get; set; }
        public string Currency_ISO { get; set; }
        public string Comment { get; set; }
    }
}