using System.ComponentModel.DataAnnotations;

namespace ZO1.Tutorials.Services.ViewModels.Items
{
    public class CreateItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This name field is required")]
        [MaxLength(255)]
        public string BorrowerName { get; set; }
    }
}