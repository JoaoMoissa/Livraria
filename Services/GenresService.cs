using Bookstore.Data;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services
{
    public class GenresService
    {
        private readonly BookstoreContext _context;

        public GenresService(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> FindAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task InsertAsync(Genre genre)
        {
            _context.Add(genre);
            await _context.SaveChangesAsync();
        }
        public async Task<Genre?> FindByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _ context.Genres.FindAsync(id);
                _context.Genres.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityExeption(ex.Message);
            }
        }
    }
}
