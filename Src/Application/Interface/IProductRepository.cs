using Application.Entities;
using Application.Interface.Common;
using Application.Utils;


namespace Application.Interface;
    public interface IProductRepository : IRepository<Product>
    {
        Task<DefaultResult<Product>>AddNewOrUpdate (Product product);
        
    }

