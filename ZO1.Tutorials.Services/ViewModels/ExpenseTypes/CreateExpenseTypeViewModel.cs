using System.ComponentModel.DataAnnotations;

namespace ZO1.Tutorials.Services.ViewModels.ExpenseTypes
{
    public class CreateExpenseTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This ExpenseType name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}