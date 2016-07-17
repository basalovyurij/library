using Library.Domain.Interfaces;
using Library.Domain.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Web.Api
{
    public class AuthorController : BaseController
    {
        private readonly IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<AuthorModel> Get()
        {
            var res = _repository.Get();
            return res;
        }

        [HttpGet]
        public AuthorModel Get(int id)
        {
            var res = _repository.Find(id);
            return res;
        }

        [HttpPost]
        public HttpResponseMessage Create(AuthorModel Author)
        {
            if (!ModelState.IsValid)
            {
                return ModelError();
            }

            var id = _repository.Create(Author);
            var res = _repository.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [HttpPut]
        public HttpResponseMessage Update(int id, AuthorModel Author)
        {
            if (!ModelState.IsValid)
            {
                return ModelError();
            }

            _repository.Update(id, Author);
            var res = _repository.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
