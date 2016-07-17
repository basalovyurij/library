using Library.Domain.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Library.Domain.Model
{
    [DataContract]
    public class BookModel
    {
        public BookModel()
        {
            this.Authors = new List<AuthorModel>();
        }

        [DataMember]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Заголовок\" обязательное")]
        [MaxLength(30, ErrorMessage = "Поле \"Заголовок\" не может превышать 30 символов")]
        [DataMember]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Кол-во страниц\" обязательное")]
        [Range(1, 10000, ErrorMessage = "Поле \"Кол-во страниц\" должно быть больше 0 и не более 10000)")]
        [DataMember(IsRequired = true)]
        public int PageCount { get; set; }

        [MaxLength(30, ErrorMessage = "Поле \"Издательсво\" не может превышать 30 символов")]
        [DataMember]
        public string Publishment { get; set; }

        [Range(1800, 2100, ErrorMessage = "Поле \"Год издания\" должно быть больше 1800 и не более 2100)")]
        [DataMember]
        public int? PublishYear { get; set; }
        
        [Isbn(ErrorMessage = "Введите валидный ISBN")]
        [DataMember]
        public string ISBN { get; set; }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public List<AuthorModel> Authors { get; set; }
        
        [Range(1, 1000, ErrorMessage = "Укажите хотя бы одного автора")]
        public int AuthorsCount
        {
            get
            {
                return Authors != null ? Authors.Count : 0;
            }
        }
    }
}
