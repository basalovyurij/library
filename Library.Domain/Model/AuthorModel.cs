using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Model
{
    public class AuthorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Имя\" обязательное")]
        [MaxLength(20, ErrorMessage = "Поле \"Имя\" не может превышать 20 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле \"Фамилия\" обязательно")]
        [MaxLength(20, ErrorMessage = "Поле \"Фамилия\" не может превышать 20 символов")]
        public string SurName { get; set; }
    }
}
