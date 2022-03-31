namespace Lucca.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IUnitOfWork UnitOfWork { get; }
        IUserRepository UserRepository { get; }
        IExpenseRepository ExpenseRepository { get; }
    }
}