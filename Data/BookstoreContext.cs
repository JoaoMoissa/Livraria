using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

//save

namespace Bookstore.Data
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
    }
}
