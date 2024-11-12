using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class GenresService
    {
        private readonly BookstoreContext _context;

        public GenresService(BookstoreContext context)
        {
            _context = context;
        }

        public List<Genre>FindAll()
        {
            return _context.Genres.ToList();
        }
    }
}
