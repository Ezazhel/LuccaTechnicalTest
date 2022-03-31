using Lucca.Contracts;
using Lucca.Domain.Entities;

namespace Lucca.Services.Extensions
{
    public static class ExpenseExtension
    {
        public static ExpenseDto ToExpenseDto(this Expense expense)
        {
            return new ExpenseDto()
            {
            };
        }
    }
}