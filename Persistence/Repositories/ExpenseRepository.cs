using Lucca.Domain.Entities;
using Lucca.Domain.Enums;
using Lucca.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesForUserAsync(Guid userId, CancellationToken cancellationToken = default) => await FindByCondition(expense => expense.UserId.Equals(userId)).ToListAsync(cancellationToken);

        public async Task<IEnumerable<Expense>> GetAllExpensesSortedByAsync(ExpenseSort sortProperty, CancellationToken cancellationToken = default)
        {
            var expenses = FindAll();
            var expensesOrdered = sortProperty switch
            {
                ExpenseSort.Amount => expenses.OrderBy(expense => expense.Amount),
                ExpenseSort.Date => expenses.OrderBy(expense => expense.Date),
                _ => throw new NotImplementedException(),
            };

            return await expensesOrdered.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Expense>> GetExpensesByConditionAsync(Expression<Func<Expense, bool>> expression, CancellationToken cancellationToken = default) => await FindByCondition(expression).ToListAsync(cancellationToken);

        public async Task<Expense> GetByIdAsync(Guid expenseId, CancellationToken cancellationToken = default) => await FindByCondition(expense => expense.Id.Equals(expenseId)).FirstOrDefaultAsync(cancellationToken);
    }
}