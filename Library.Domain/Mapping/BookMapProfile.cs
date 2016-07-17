using AutoMapper;
using Library.DB.Model;
using Library.Domain.Model;
using System;
using System.Linq;

namespace Library.Domain.Mapping
{
    public class BookMapProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Book, BookModel>()
                .ForMember(d => d.Authors, m => m.MapFrom(s => s.AuthorBooks.Select(t => Mapper.Map<Author>(t.Author))));
            CreateMap<BookModel, Book>()
                .ForMember(d => d.AuthorBooks, m => m.Ignore());
        }
    }
}
