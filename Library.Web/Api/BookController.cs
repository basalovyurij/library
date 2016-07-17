using Library.Domain.Interfaces;
using Library.Domain.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Web.Api
{
    public class BookController : BaseController
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<BookModel> Get()
        {
            var res = _repository.Get();
            return res;
        }

        [HttpGet]
        public BookModel Get(int id)
        {
            var res = _repository.Find(id);
            return res;
        }

        [HttpPost]
        public HttpResponseMessage Create(BookModel Book)
        {
            if (!ModelState.IsValid)
            {
                return ModelError();
            }

            var id = _repository.Create(Book);
            var res = _repository.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }

        [HttpPut]
        public HttpResponseMessage Update(int id, BookModel Book)
        {
            if (!ModelState.IsValid)
            {
                return ModelError();
            }

            _repository.Update(id, Book);
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
