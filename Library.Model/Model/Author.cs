using Library.DB.Base;
using System.Collections.Generic;

namespace Library.DB.Model
{
    public class Author : EntityBase
    {
        public Author()
        {
            this.AuthorBooks = new List<AuthorBook>();
        }

        public string FirstName { get; set; }
        public string SurName { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } 
    }
}
