using Library.DB.Base;

namespace Library.DB.Model
{
    public class AuthorBook : EntityBase
    {
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
