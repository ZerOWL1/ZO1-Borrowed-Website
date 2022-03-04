using ZO1.Tutorials.Core.Contexts;
using ZO1.Tutorials.Core.Cores.Infrastructures;
using ZO1.Tutorials.Core.Cores.IRepositories;
using ZO1.Tutorials.Core.Models.Entities;

namespace ZO1.Tutorials.Core.Cores.Repositories
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(BorrowedContext context) : base(context)
        {
        }
    }
}