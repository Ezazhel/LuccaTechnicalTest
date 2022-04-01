using Lucca.Domain.Repositories;
using System;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IExpenseRepository> _lazyExpenseRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly Lazy<IUserRepository> _lazyUserRepository;

        public RepositoryManager(RepositoryDbContext repositoryDbContext)
        {
            _lazyExpenseRepository = new Lazy<IExpenseRepository>(() => new ExpenseRepository(repositoryDbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(repositoryDbContext));
            _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryDbContext));
        }

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

        public IUserRepository UserRepository => _lazyUserRepository.Value;

        public IExpenseRepository ExpenseRepository => _lazyExpenseRepository.Value;
    }
}