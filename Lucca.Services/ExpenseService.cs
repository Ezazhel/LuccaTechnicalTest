using Lucca.Contracts;
using Lucca.Domain.Enums;
using Lucca.Domain.Repositories;
using Lucca.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lucca.Services
{
    internal sealed class ExpenseService : IExpenseService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ExpenseService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<ExpenseDto>> GetAllExpensesForUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            IEnumerable<Domain.Entities.Expense> expense = await _repositoryManager.ExpenseRepository.GetAllExpensesForUserAsync(userId, cancellationToken);

            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExpenseDto>> GetAllExpensesSortedByAsync(ExpenseSort sortProperty, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseDto> GetByIdAsync(Guid expenseId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseDto> InsertAsync(Guid userId, CreateExpenseDto createExpenseDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}