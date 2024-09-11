namespace Application.Interface.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        Task SaveAsync(CancellationToken cancellationToken);

    }
}
