using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class PublicationViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Header")]
        [Required(ErrorMessage = "No Header")]
        public string? Title { get; set; }

        [Display(Name = "Contain")]
        [Required(ErrorMessage = "No Contains")]
        public string? Description { get; set; }

        [Display(Name = "Category")]
        public IEnumerable<SelectListItem>? SelectListCategories { get; set; }

        [Display(Name = "Images")]
        public IFormFile File { get; set; }
        public string? Image {  get; set; }
        public string? ImageFullName {  get; set; }

        [Display(Name = "Seo description (under 155 symbols)")]
        [Required(ErrorMessage = "No seo description")]
        [MaxLength(155, ErrorMessage = "Under 155 symbols")]
        public string? SeoDescription { get; set; }

        [Display(Name = "Seo keys word")]
        public string? Keywords { get; set; }




    }
}
