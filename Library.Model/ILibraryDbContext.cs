using Library.DB.Model;
using System.Data.Entity;

namespace Library.DB
{
    public interface ILibraryDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<AuthorBook> AuthorBooks { get; set; }
        DbSet<Book> Books { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        void Dispose();
    }
}
