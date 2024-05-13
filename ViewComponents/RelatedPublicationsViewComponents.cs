using Blog.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.ViewComponents
{
    public class RelatedPublicationsViewComponents : ViewComponent
    {
        private readonly IPublication _publication;
    
        public RelatedPublicationsViewComponents(IPublication publication) {
            _publication = publication;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id) {
            return View("RelatedPublications", await _publication.GetFourRandomPublicationAsync(id));
        }

    
    }
}
