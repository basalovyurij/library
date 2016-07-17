using Library.DB.Base;
using System.Collections.Generic;

namespace Library.DB.Model
{
    public class Book : EntityBase
    {
        public Book()
        {
            this.AuthorBooks = new List<AuthorBook>();
        }

        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Publishment { get; set; }
        public int? PublishYear { get; set; }
        public string ISBN { get; set; }
        public string Image { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } 
    }
}
