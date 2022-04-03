using Lucca.Contracts;
using Lucca.Domain.Entities;
using Lucca.Domain.Exceptions;
using Lucca.Domain.Repositories;
using Lucca.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Lucca.UnitTest
{
    public class ExpenseCreationUnitTest
    {
        private readonly Mock<IRepositoryManager> _mockRepositoryManager;
        private readonly ServiceManager _serviceManager;

        public ExpenseCreationUnitTest()
        {
            _mockRepositoryManager = new Mock<IRepositoryManager>();
            _serviceManager = new ServiceManager(_mockRepositoryManager.Object);
        }

        [Fact]
        public async Task Should_ThrowError_For_FutureDate()
        {
            var expenseToCreate = new CreateExpenseDto()
            {
                Amount = 10,
                Date = DateTime.Now.AddDays(1),
                Comment = "Test Comment",
                Currency_ISO = "USD",
                Category = 0
            };

            await Assert.ThrowsAsync<ExpensesDateInFuturException>(async () => await _serviceManager.ExpenseService.InsertAsync(Guid.NewGuid(), expenseToCreate, default));
        }

        [Fact]
        public async Task Should_ThrowError_For_MissingComment()
        {
            var expenseToCreate = new CreateExpenseDto()
            {
                Amount = 10,
                Date = DateTime.Now.AddDays(1),
                Comment = "",
                Currency_ISO = "USD",
                Category = 0
            };

            await Assert.ThrowsAsync<MissingCommentException>(async () => await _serviceManager.ExpenseService.InsertAsync(Guid.NewGuid(), expenseToCreate, default));
        }

        [Fact]
        public async Task Should_ThrowError_For_DateOutOfInterval()
        {
            var expenseToCreate = new CreateExpenseDto()
            {
                Amount = 10,
                Date = DateTime.Now.AddMonths(-4),
                Comment = "Test comment",
                Currency_ISO = "USD",
                Category = 0
            };

            await Assert.ThrowsAsync<OutOfIntervalExpensesDateException>(async () => await _serviceManager.ExpenseService.InsertAsync(Guid.NewGuid(), expenseToCreate, default));
        }

        [Fact]
        public async Task Should_ThrowError_For_MissingUser()
        {
            _mockRepositoryManager.Setup(repository => repository.UserRepository.GetByIdAsync(It.IsAny<Guid>(), default)).Returns(Task.FromResult<User>(null));

            var expenseToCreate = new CreateExpenseDto()
            {
                Amount = 10,
                Date = DateTime.Now,
                Comment = "Test comment",
                Currency_ISO = "USD",
                Category = 0
            };

            await Assert.ThrowsAsync<UserNotFoundException>(async () => await _serviceManager.ExpenseService.InsertAsync(Guid.NewGuid(), expenseToCreate, default));
        }

        [Fact]
        public async Task Should_ThrowError_For_NotTheSameCurrency()
        {
            _mockRepositoryManager.Setup(repository => repository.UserRepository.GetByIdAsync(It.IsAny<Guid>(), default)).Returns(Task.FromResult<User>(new User() { Currency_ISO = "RUB" }));

            var expenseToCreate = new CreateExpenseDto()
            {
                Amount = 10,
                Date = DateTime.Now,
                Comment = "Test comment",
                Currency_ISO = "USD",
                Category = 0
            };

            await Assert.ThrowsAsync<CurrencyIsDifferentFromUserException>(async () => await _serviceManager.ExpenseService.InsertAsync(Guid.NewGuid(), expenseToCreate, default));
        }

        [Fact]
        public async Task Should_ThrowError_For_DuplicateCommentAndDate()
        {
            var dateNow = DateTime.Now;
            _mockRepositoryManager.Setup(repository => repository.UserRepository.GetByIdAsync(It.IsAny<Guid>(), default))
                .Returns(Task.FromResult<User>(new User() { Currency_ISO = "USD" }));

            _mockRepositoryManager.Setup(repository => repository.ExpenseRepository.GetExpensesByConditionAsync(It.IsAny<Expression<Func<Expense, bool>>>(), default))
                .Returns(Task.FromResult<IEnumerable<Expense>>(new Expense[] { new Expense() { Amount = 10, Date = dateNow } }));

            var expenseToCreate = new CreateExpenseDto()
            {
                Amount = 10,
                Date = dateNow,
                Comment = "Test comment",
                Currency_ISO = "USD",
                Category = 0
            };

            await Assert.ThrowsAsync<DuplicateExpensesException>(async () => await _serviceManager.ExpenseService.InsertAsync(Guid.NewGuid(), expenseToCreate, default));
        }

        [Fact]
        public async Task Should_CreateExpense()
        {
            var dateNow = DateTime.Now;
            _mockRepositoryManager.Setup(repository => repository.UserRepository.GetByIdAsync(It.IsAny<Guid>(), default))
                .Returns(Task.FromResult<User>(new User() { Currency_ISO = "USD" }));

            _mockRepositoryManager.Setup(repository => repository.ExpenseRepository.GetExpensesByConditionAsync(It.IsAny<Expression<Func<Expense, bool>>>(), default))
                .Returns(Task.FromResult<IEnumerable<Expense>>(new Expense[] { }));

            _mockRepositoryManager.Setup(repository => repository.ExpenseRepository.Insert(It.IsAny<Expense>()));
            _mockRepositoryManager.Setup(repository => repository.UnitOfWork.SaveChangesAsync(default)).Returns(Task.FromResult<int>(1));

            var expenseToCreate = new CreateExpenseDto()
            {
                Amount = 10,
                Date = dateNow,
                Comment = "Test comment",
                Currency_ISO = "USD",
                Category = 0
            };

            var expenseDto = await _serviceManager.ExpenseService.InsertAsync(Guid.NewGuid(), expenseToCreate, default);

            Assert.NotNull(expenseDto);
        }
    }
}