using Blog.Data;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context) {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category) {
            _context.categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category category) {
            _context.categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync() {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(string id) {
            return await _context.categories.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task UpdateCategoryAsync(Category category) {
            _context.categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
