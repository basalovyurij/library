using Effort;
using Library.DB.Model;
using Ninject.Modules;
using System.Data.Common;

namespace Library.DB
{
    public class DbNinjectModule : NinjectModule
    {
        private static bool _initialized = false;

        public override void Load()
        {

            Bind<ILibraryDbContext>()
                .ToMethod((k) =>
                {
                    DbConnection connection = DbConnectionFactory.CreatePersistent("test");
                    var context = new LibraryDbContext(connection);

                    if (!_initialized)
                    {
                        Init(context);
                        _initialized = true;
                    }

                    return context;
                })
                .InSingletonScope();
        }

        private void Init(ILibraryDbContext context)
        {
            context.Authors.Add(new Author
            {
                Id = 1,
                FirstName = "Лев",
                SurName = "Толстой"
            });

            context.Authors.Add(new Author
            {
                Id = 2,
                FirstName = "Федор",
                SurName = "Достоевский"
            });

            context.Books.Add(new Book
            {
                Id = 1,
                Name = "Lorem Ipsum",
                ISBN = "1-4493-4485-2",
                PageCount = 1,
                Publishment = "Москва",
                PublishYear = 2000,
                Image = "data:image/gif;base64,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",
            });
            context.Books.Add(new Book
            {
                Id = 2,
                Name = "Война и Мир",
                ISBN = "1-4493-4485-2",
                PageCount = 1000,
                Publishment = "Москва",
                PublishYear = 1900,
                Image = "data:image/gif;base64,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",
            });

            context.AuthorBooks.Add(new AuthorBook
            {
                Id = 1,
                AuthorId = 1,
                BookId = 1
            });
            context.AuthorBooks.Add(new AuthorBook
            {
                Id = 2,
                AuthorId = 2,
                BookId = 1
            });
            context.AuthorBooks.Add(new AuthorBook
            {
                Id = 3,
                AuthorId = 1,
                BookId = 2
            });

            context.SaveChanges();
        }
    }
}
