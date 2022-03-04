using ZO1.Tutorials.Core.Models.EntitiesBase;

namespace ZO1.Tutorials.Core.Models.Entities
{
    public class Expense : BaseEntities
    {
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
        public int? ExpenseTypeId { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }

    }
}