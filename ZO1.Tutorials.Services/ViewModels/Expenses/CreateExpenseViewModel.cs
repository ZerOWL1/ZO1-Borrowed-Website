using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ZO1.Tutorials.Core.Models.Entities;

namespace ZO1.Tutorials.Services.ViewModels.Expenses
{
    public class CreateExpenseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This expense field is required")]
        [MaxLength(500)]
        [DisplayName("Expense Name")]
        public string ExpenseName { get; set; }

        [Required(ErrorMessage = "This amount field is required")]
        [Range(0, int.MaxValue, ErrorMessage = "This field must greater than 0!")]
        public int Amount { get; set; }

        [DisplayName("Expense Type")]
        [Range(0, int.MaxValue, ErrorMessage = "This field has invalid data type")]
        public int? ExpenseTypeId { get; set; }

        public ExpenseType ExpenseType { get; set; }
    }
}