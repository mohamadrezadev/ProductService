namespace Application.Interface;

public interface IProductService
{
    Task AddOrUpdateProduct();
    Task GetProduct (int idProduct);
}