using System.Collections.Generic;
using ZO1.Tutorials.Core.Models.EntitiesBase;

namespace ZO1.Tutorials.Core.Models.Entities
{
    public class ExpenseType : BaseEntities
    {
        public string Name { get; set; }
        public ICollection<Expense> Expenses { get; set; }  
    }
}