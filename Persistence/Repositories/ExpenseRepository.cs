using Lucca.Domain.Entities;
using Lucca.Domain.Model;
using Lucca.Domain.Repositories;
using Lucca.Persistence.Helper;
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
        private readonly ISortHelper<Expense> _sortHelper;

        public ExpenseRepository(RepositoryDbContext repositoryDbContext, ISortHelper<Expense> sortHelper) : base(repositoryDbContext)
        {
            _sortHelper = sortHelper;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesForUserAsync(Guid userId, CancellationToken cancellationToken = default) => await FindByCondition(expense => expense.UserId.Equals(userId)).ToListAsync(cancellationToken);

        public async Task<IEnumerable<Expense>> GetAllExpensesSortedByAsync(Guid userId, ExpenseParameters orderByParameters, CancellationToken cancellationToken = default)
        {
            IQueryable<Expense> expenses = FindByCondition(expense => expense.UserId.Equals(userId));

            expenses = _sortHelper.ApplySort(expenses, orderByParameters.OrderBy);

            return await expenses.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Expense>> GetExpensesByConditionAsync(Expression<Func<Expense, bool>> expression, CancellationToken cancellationToken = default) => await FindByCondition(expression).ToListAsync(cancellationToken);

        public async Task<Expense> GetByIdAsync(Guid expenseId, CancellationToken cancellationToken = default) => await FindByCondition(expense => expense.Id.Equals(expenseId)).FirstOrDefaultAsync(cancellationToken);
    }
}