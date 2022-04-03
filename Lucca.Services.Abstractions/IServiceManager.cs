namespace Lucca.Services.Abstractions
{
    public interface IServiceManager
    {
        IExpenseService ExpenseService { get; }
        IUserService UserService { get; }
    }
}