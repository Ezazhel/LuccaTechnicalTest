using Lucca.Contracts;
using Lucca.Domain.Exceptions;
using Lucca.Domain.Model;
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
            var user = await _repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            IEnumerable<Domain.Entities.Expense> expenses = await _repositoryManager.ExpenseRepository.GetAllExpensesForUserAsync(userId, cancellationToken);

            var expensesDto = expenses.Select(expense => {
                var expenseDto = expense.ToExpenseDto();
                expenseDto.User = user.GetFullName();
                return expenseDto;
            });

            return expensesDto;
        }

        public async Task<IEnumerable<ExpenseDto>> GetAllExpensesSortedByAsync(Guid userId, ExpenseParameters orderByParameters, CancellationToken cancellationToken = default)
        {
            var expenses = await _repositoryManager.ExpenseRepository.GetAllExpensesSortedByAsync(userId, orderByParameters, cancellationToken);

            var expensesDto = expenses.Select(expense => expense.ToExpenseDto());

            return expensesDto;
        }

        public async Task<ExpenseDto> GetByIdAsync(Guid userId, Guid expenseId, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            var expense = await _repositoryManager.ExpenseRepository.GetByIdAsync(expenseId, cancellationToken);

            if (expense is null)
            {
                throw new ExpenseNotFoundException(expenseId);
            }

            var expenseDto = expense.ToExpenseDto();
            expenseDto.User = user.GetFullName();

            return expenseDto;
        }

        public async Task<ExpenseDto> InsertAsync(Guid userId, CreateExpenseDto createExpenseDto, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(createExpenseDto.Comment))
            {
                throw new MissingCommentException();
            }

            if (createExpenseDto.Date < DateTime.Now.AddMonths(-3))
            {
                throw new OutOfIntervalExpensesDateException();
            }

            if (createExpenseDto.Date > DateTime.Now)
            {
                throw new ExpensesDateInFuturException();
            }

            var user = await _repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            if (user.Currency_ISO != createExpenseDto.Currency_ISO)
            {
                throw new CurrencyIsDifferentFromUserException();
            }

            var duplicateExpense = (await _repositoryManager.ExpenseRepository.GetExpensesByConditionAsync(expense => expense.Date == createExpenseDto.Date && expense.Amount == createExpenseDto.Amount)).FirstOrDefault();

            if (duplicateExpense != null)
            {
                throw new DuplicateExpensesException();
            }

            var expense = createExpenseDto.ToExpense();

            expense.UserId = user.Id;

            _repositoryManager.ExpenseRepository.Insert(expense);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            var expenseDto = expense.ToExpenseDto();

            expenseDto.User = user.GetFullName();

            return expenseDto;
        }
    }
}