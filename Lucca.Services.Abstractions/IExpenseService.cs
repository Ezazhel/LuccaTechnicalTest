using Lucca.Contracts;
using Lucca.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lucca.Services.Abstractions
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDto>> GetAllExpensesForUserAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<IEnumerable<ExpenseDto>> GetAllExpensesSortedByAsync(ExpenseSort sortProperty, CancellationToken cancellationToken = default);

        Task<ExpenseDto> GetByIdAsync(Guid userId, Guid expenseId, CancellationToken cancellationToken = default);

        Task<ExpenseDto> InsertAsync(Guid userId, CreateExpenseDto createExpenseDto, CancellationToken cancellationToken = default);
    }
}