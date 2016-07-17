using Library.DB.Base;
using Library.DB.Model;
using System.Data.Entity.ModelConfiguration;

namespace Library.Model
{
    public class AuthorBookMap : EntityBaseMap<AuthorBook>
    {
        public AuthorBookMap()
        {
            Property(t => t.AuthorId);
            Property(t => t.BookId);

            HasRequired(t => t.Author)
                .WithMany(t => t.AuthorBooks)
                .HasForeignKey(t => t.AuthorId);

            HasRequired(t => t.Book)
                .WithMany(t => t.AuthorBooks)
                .HasForeignKey(t => t.BookId);
        }
    }
}
