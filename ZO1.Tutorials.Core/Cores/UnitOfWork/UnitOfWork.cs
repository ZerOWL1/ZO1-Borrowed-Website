using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZO1.Tutorials.Core.Contexts;
using ZO1.Tutorials.Core.Cores.IRepositories;
using ZO1.Tutorials.Core.Cores.Repositories;

namespace ZO1.Tutorials.Core.Cores.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IItemRepository _itemRepository; 


        public BorrowedContext BorrowedContext { get; }


        public IItemRepository Items => _itemRepository ??= new ItemRepository(BorrowedContext);

        public UnitOfWork(BorrowedContext context)
        {
            BorrowedContext = context;
        }

        public void Dispose()
        {
            BorrowedContext.Dispose();
        }

        public void Complete()
        {
            BorrowedContext.BeforeComplete();

            do
            {
                try
                {
                    BorrowedContext.SaveChanges();
                    break;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // Update the values of the entity that failed to save from the store
                    ex.Entries.Single().Reload();
                }

            } while (true);
        }

        public Task<int> CompleteAsync()
        {
            return BorrowedContext.SaveChangesAsync();
        }
    }
}