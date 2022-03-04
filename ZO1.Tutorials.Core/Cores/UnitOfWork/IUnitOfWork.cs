using System;
using System.Threading.Tasks;
using ZO1.Tutorials.Core.Contexts;
using ZO1.Tutorials.Core.Cores.IRepositories;

namespace ZO1.Tutorials.Core.Cores.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public BorrowedContext BorrowedContext { get; }

        public IItemRepository Items { get; }
        public IExpenseRepository Expenses { get; }
        public IExpenseTypeRepository ExpenseTypes { get; }

        void Complete();
        Task<int> CompleteAsync();
    }
}