using BackgroundWorker.Data;
using BackgroundWorker.Repositories.Abstract;

namespace BackgroundWorker.Repositories.Concrete
{
    public class EFProductRepository:IProductRepository
    {
        private readonly MovieDbContext? _dbContext;

        public EFProductRepository(MovieDbContext? dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
