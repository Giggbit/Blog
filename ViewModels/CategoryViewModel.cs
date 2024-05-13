using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "There is no category name")]
        public string? Name { get; set; }

        [Display(Name = "Discription")]
        public string? Discription { get; set; }
    }
}
