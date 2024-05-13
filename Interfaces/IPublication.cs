using Blog.Models;
using Blog.Models.Pages;

namespace Blog.Interfaces
{
    public interface IPublication
    {
        Task<IEnumerable<Publication>> GetFourRandomPublicationAsync(string id);
        Task<PagedList<Publication>> GetAllPublicationsByCategoryWithCAtegories(QueryOptions options, string id);
        Task<IEnumerable<Publication>> GetAllPublicationsAsync();
        PagedList<Publication> GetAllPublicationsWithCategoriesAsync(QueryOptions options);
        Task<Publication> GetPublicationAsync(string id);
        Task<Publication> GetPublicationWithCategoriesAsync(string id);

        Task UpdateViewAsync(string id);

        Task AddPublicationAsync(Publication publication);
        Task UpdatePublicationAsync(Publication publication);
        Task DeletePublicationAsync(Publication publication);
    }
}
