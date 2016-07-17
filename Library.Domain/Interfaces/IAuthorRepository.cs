using Library.Domain.Model;
using System.Collections.Generic;

namespace Library.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        List<AuthorModel> Get();
        AuthorModel Find(int id);
        int Create(AuthorModel author);
        void Update(int id, AuthorModel author);
        void Delete(int id);
    }
}
