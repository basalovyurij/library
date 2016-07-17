using Library.DB.Base;
using Library.DB.Model;
using System.Data.Entity.ModelConfiguration;

namespace Library.Model
{
    public class BookMap : EntityBaseMap<Book>
    {
        public BookMap()
        {
            Property(t => t.Name);
            Property(t => t.PageCount);
            Property(t => t.Publishment);
            Property(t => t.PublishYear);
            Property(t => t.ISBN);
            Property(t => t.Image);
        }
    }
}
