using Application.Interface;
using Application.Interface.Common;
using Microsoft.AspNetCore.Identity;
using Persistances.Data;
using Persistances.Repositories;

namespace Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        


        public IProductRepository ProductRepository { get; }


    
        public UnitOfWork( AppDbContext dbContext )
        {
            ProductRepository = new ProductRepository(dbContext);
        }

        public  void Dispose( )
        {



        }
        public async Task SaveAsync(CancellationToken cancellationToken )
        {
            await _context.SaveChangesAsync();
        }
    }
}
