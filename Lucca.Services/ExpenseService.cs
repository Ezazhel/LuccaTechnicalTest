using Lucca.Contracts;
using Lucca.Domain.Enums;
using Lucca.Domain.Exceptions;
using Lucca.Domain.Repositories;
using Lucca.Services.Abstractions;
using Lucca.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<Domain.Entities.Expense> expenses = await _repositoryManager.ExpenseRepository.GetAllExpensesForUserAsync(userId, cancellationToken);

            var expenseDto = expenses.Select(expense => expense.ToExpenseDto());

            return expenseDto;
        }

        public Task<IEnumerable<ExpenseDto>> GetAllExpensesSortedByAsync(ExpenseSort sortProperty, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpenseDto> GetByIdAsync(Guid expenseId, CancellationToken cancellationToken = default)
        {
            var expense = await _repositoryManager.ExpenseRepository.GetByIdAsync(expenseId, cancellationToken);

            if (expense is null)
            {
                throw new ExpenseNotFoundException(expenseId);
            }

            return expense.ToExpenseDto();
        }

        public async Task<ExpenseDto> InsertAsync(Guid userId, CreateExpenseDto createExpenseDto, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            var expense = createExpenseDto.ToExpense();

            expense.User = user;

            _repositoryManager.ExpenseRepository.Insert(expense);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return expense.ToExpenseDto();
        }
    }
}