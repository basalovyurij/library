using AutoMapper;
using Library.DB;
using Library.DB.Model;
using Library.Domain.Interfaces;
using Library.Domain.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Library.Domain.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ILibraryDbContext _context;

        public BookRepository(ILibraryDbContext context)
        {
            _context = context;
        }

        public List<BookModel> Get()
        {
            return _context.Books
                .Include(b => b.AuthorBooks)
                .Include(b => b.AuthorBooks.Select(ab => ab.Author))
                .ToList()
                .Select(t => Mapper.Map<BookModel>(t))
                .ToList();
        }

        public BookModel Find(int id)
        {
            var entity = _context.Books
                .Include(b => b.AuthorBooks)
                .Include(b => b.AuthorBooks.Select(ab => ab.Author))
                .FirstOrDefault(t => t.Id == id);
            return Mapper.Map<BookModel>(entity);
        }

        public int Create(BookModel book)
        {
            var entity = Mapper.Map<Book>(book);
            _context.Books.Add(entity);
            book.Authors.ForEach(t => 
                _context.AuthorBooks.Add(new AuthorBook { AuthorId = t.Id, Book = entity }));
            _context.SaveChanges();

            return entity.Id;
        }

        public void Update(int id, BookModel book)
        {
            var entity = _context.Books.FirstOrDefault(t => t.Id == id);
            entity = Mapper.Map<BookModel, Book>(book, entity);
            UpdateAuthors(book);
            _context.SaveChanges();
        }

        private void UpdateAuthors(BookModel book)
        {
            var newAuthors = book.Authors
                .Select(t => t.Id)
                .ToList();

            var exist = _context.AuthorBooks
                .Where(t => t.BookId == book.Id)
                .ToList();

            var existAuthors = exist.Select(t => t.AuthorId).ToList();

            var create = newAuthors.Where(t => !existAuthors.Contains(t)).ToList();
            var delete = existAuthors.Where(t => !newAuthors.Contains(t)).ToList();

            create.ForEach(t =>
                _context.AuthorBooks.Add(new AuthorBook { AuthorId = t, BookId = book.Id })); 
            delete.ForEach(t =>
                _context.AuthorBooks.Remove(exist.FirstOrDefault(x => x.AuthorId == t))); 
        }

        public void Delete(int id)
        {
            var entity = _context.Books.FirstOrDefault(t => t.Id == id);
            _context.Books.Remove(entity);
            
            _context.SaveChanges();
        }
    }
}
