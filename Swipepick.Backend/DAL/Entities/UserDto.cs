using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    /// <summary>
    /// Данный класс используется для регистрации
    /// </summary>
    public class UserDto
    {
        [EmailAddress(ErrorMessage = "Please, input a correct email")]
        [Required(ErrorMessage = "Please, input your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, input your password")]
        public string Password { get; set; }

        [Column("name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Column("lastname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите фамилию")]
        public string Lastname { get; set; }
    }
}