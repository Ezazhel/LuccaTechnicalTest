using Lucca.Domain.Entities;
using Lucca.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading;

using System.Threading.Tasks;

namespace Lucca.Domain.Repositories
{
    public interface IExpenseRepository : IRepositoryBase<Expense>
    {
        Task<IEnumerable<Expense>> GetAllExpensesForUserAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<IEnumerable<Expense>> GetAllExpensesSortedByAsync(ExpenseSort sortProperty, CancellationToken cancellationToken = default);

        Task<Expense> GetByIdAsync(Guid expenseId, CancellationToken cancellationToken = default);
    }
}