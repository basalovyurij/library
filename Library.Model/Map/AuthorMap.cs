using Library.DB.Base;
using Library.DB.Model;
using System.Data.Entity.ModelConfiguration;

namespace Library.Model
{
    public class AuthorMap : EntityBaseMap<Author>
    {
        public AuthorMap()
        {
            Property(t => t.FirstName);
            Property(t => t.SurName);
        }
    }
}
