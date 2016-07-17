using Library.Domain.Model;
using System.Collections.Generic;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository
    {
        List<BookModel> Get();
        BookModel Find(int id);
        int Create(BookModel book);
        void Update(int id, BookModel book);
        void Delete(int id);
    }
}
