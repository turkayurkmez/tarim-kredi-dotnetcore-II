using System.ComponentModel.DataAnnotations;

namespace introduceDotNetCore.Models
{
    public class UserResponse
    {
        [Required(ErrorMessage ="Lütfen isminizi girin")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyisminizi girin")]

        public string LastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Lütfen email adresinizi girin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen belirtiniz")]

        public bool IsComing { get; set; }

    }
}
