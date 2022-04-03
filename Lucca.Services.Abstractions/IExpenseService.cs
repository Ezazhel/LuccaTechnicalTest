using Lucca.Contracts;
using Lucca.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lucca.Services.Abstractions
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDto>> GetAllExpensesSortedByAsync(Guid userId, ExpenseParameters orderByParameters, CancellationToken cancellationToken = default);

        Task<ExpenseDto> GetByIdAsync(Guid userId, Guid expenseId, CancellationToken cancellationToken = default);

        Task<ExpenseDto> InsertAsync(Guid userId, CreateExpenseDto createExpenseDto, CancellationToken cancellationToken = default);
    }
}