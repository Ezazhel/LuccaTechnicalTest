using Lucca.Domain.Repositories;
using Lucca.Services.Abstractions;
using System;

namespace Lucca.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IExpenseService> _lazyExpenseService;
        private readonly Lazy<IUserService> _lazyUserService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyExpenseService = new Lazy<IExpenseService>(() => new ExpenseService(repositoryManager));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager));
        }

        public IExpenseService ExpenseService => _lazyExpenseService.Value;

        public IUserService UserService => _lazyUserService.Value;
    }
}