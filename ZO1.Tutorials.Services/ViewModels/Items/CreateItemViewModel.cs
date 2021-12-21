using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZO1.Tutorials.Services.ViewModels.Items
{
    public class CreateItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This name field is required")]
        [MaxLength(255)]
        [DisplayName("Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "This borrower field is required")]
        [DisplayName("Borrower")]
        [MaxLength(500)]
        public string BorrowerName { get; set; }

        [Required(ErrorMessage = "This lender field is required")]
        [MaxLength(255)]
        public string Lender { get; set; }
    }
}