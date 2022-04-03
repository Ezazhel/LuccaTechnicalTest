using Lucca.Domain.Model;
using Lucca.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lucca.Presentation.Controllers
{
    [ApiController]
    [Route("api/users/{userId:guid}/expenses")]
    public class ExpensesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ExpensesController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetExpenses(Guid userId, CancellationToken cancellationToken)
        {
            IEnumerable<Contracts.ExpenseDto> expenses = await _serviceManager.ExpenseService.GetAllExpensesForUserAsync(userId, cancellationToken);

            return Ok(expenses);
        }

        [HttpGet]
        [Route("{expenseId:guid}")]
        public async Task<IActionResult> GetExpenseById(Guid userId, Guid expenseId, CancellationToken cancellationToken)
        {
            var expense = await _serviceManager.ExpenseService.GetByIdAsync(userId, expenseId, cancellationToken);

            return Ok(expense);
        }

        [HttpGet]
        [Route("/orderBy={string}")]
        public async Task<IActionResult> GetExpensesSortedBy(Guid userId, [FromQuery] ExpenseParameters expenseParameters, CancellationToken cancellationToken)
        {
            IEnumerable<Contracts.ExpenseDto> expenses = await _serviceManager.ExpenseService.GetAllExpensesSortedByAsync(userId, expenseParameters, cancellationToken);

            return Ok(expenses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(Guid userId, [FromBody] Contracts.CreateExpenseDto createExpenseDto, CancellationToken cancellationToken)
        {
            Contracts.ExpenseDto response = await _serviceManager.ExpenseService.InsertAsync(userId, createExpenseDto, cancellationToken);

            return CreatedAtAction(nameof(GetExpenseById), new { userId, expenseId = response.Id }, response);
        }
    }
}