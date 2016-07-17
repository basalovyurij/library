using AutoMapper;
using Library.DB.Model;
using Library.Domain.Model;

namespace Library.Domain.Mapping
{
    public class AuthorMapProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Author, AuthorModel>();
            CreateMap<AuthorModel, Author>()
                .ForMember(d => d.AuthorBooks, m => m.Ignore());
        }
    }
}
