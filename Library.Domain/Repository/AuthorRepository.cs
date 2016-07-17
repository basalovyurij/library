using AutoMapper;
using Library.DB;
using Library.DB.Model;
using Library.Domain.Interfaces;
using Library.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ILibraryDbContext _context;

        public AuthorRepository(ILibraryDbContext context)
        {
            _context = context;
        }

        public List<AuthorModel> Get()
        {
            return _context.Authors.ToList()
                .Select(t => Mapper.Map<AuthorModel>(t))
                .ToList();
        }

        public AuthorModel Find(int id)
        {
            var entity = _context.Authors.FirstOrDefault(t => t.Id == id);
            return Mapper.Map<AuthorModel>(entity);
        }

        public int Create(AuthorModel author)
        {
            var entity = Mapper.Map<Author>(author);
            _context.Authors.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Update(int id, AuthorModel author)
        {
            var entity = _context.Authors.FirstOrDefault(t => t.Id == id);
            entity = Mapper.Map<AuthorModel, Author>(author, entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Authors.FirstOrDefault(t => t.Id == id);
            _context.Authors.Remove(entity);
            _context.SaveChanges();
        }
    }
}
