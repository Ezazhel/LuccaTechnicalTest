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
                Id = expense.Id,
                Amount = expense.Amount,
                Category = expense.Category.ToString(),
                Comment = expense.Comment,
                Currency_ISO = expense.Currency_ISO,
                Date = expense.Date,
            };
        }

        public static Expense ToExpense(this CreateExpenseDto expense)
        {
            return new Expense()
            {
                Amount = expense.Amount,
                Category = (Category)expense.Category,
                Comment = expense.Comment,
                Currency_ISO = expense.Currency_ISO,
                Date = expense.Date,
            };
        }
    }
}