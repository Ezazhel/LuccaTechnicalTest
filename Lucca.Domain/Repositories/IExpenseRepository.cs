using Lucca.Domain.Entities;
using Lucca.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;

using System.Threading.Tasks;

namespace Lucca.Domain.Repositories
{
    public interface IExpenseRepository : IRepositoryBase<Expense>
    {
        Task<IEnumerable<Expense>> GetAllExpensesForUserAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<IEnumerable<Expense>> GetAllExpensesSortedByAsync(Guid userId, ExpenseParameters orderByParameters, CancellationToken cancellationToken = default);

        Task<IEnumerable<Expense>> GetExpensesByConditionAsync(Expression<Func<Expense, bool>> expression, CancellationToken cancellationToken = default);

        Task<Expense> GetByIdAsync(Guid expenseId, CancellationToken cancellationToken = default);
    }
}