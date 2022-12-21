using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    /// <summary>
    /// Данный класс используется для входа на сайт
    /// </summary>
    public class UserLogin
    {
        [EmailAddress(ErrorMessage = "Please, input a correct email")]
        [Required(ErrorMessage = "Please, input your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, input your password")]
        public string Password { get; set; }
    }
}
