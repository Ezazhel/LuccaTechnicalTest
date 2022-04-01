using Lucca.Domain.Repositories;
using Lucca.Services.Abstractions;
using System;

namespace Lucca.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IExpenseService> _lazyExpenseService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyExpenseService = new Lazy<IExpenseService>(() => new ExpenseService(repositoryManager));
        }

        public IExpenseService ExpenseService => _lazyExpenseService.Value;
    }
}