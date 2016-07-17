using Library.DB.Model;
using Library.Model;
using System.Data.Common;
using System.Data.Entity;

namespace Library.DB
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }

        public LibraryDbContext(DbConnection connection)
            : base(connection, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new AuthorBookMap());
            modelBuilder.Configurations.Add(new BookMap());
        }
    }
}
