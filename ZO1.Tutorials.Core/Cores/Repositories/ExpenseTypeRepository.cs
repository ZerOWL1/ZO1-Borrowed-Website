using ZO1.Tutorials.Core.Contexts;
using ZO1.Tutorials.Core.Cores.Infrastructures;
using ZO1.Tutorials.Core.Cores.IRepositories;
using ZO1.Tutorials.Core.Models.Entities;

namespace ZO1.Tutorials.Core.Cores.Repositories
{
    public class ExpenseTypeRepository : GenericRepository<ExpenseType>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(BorrowedContext context) : base(context)
        {
        }
    }
}