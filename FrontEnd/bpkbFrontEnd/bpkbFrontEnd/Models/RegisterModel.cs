using System.ComponentModel.DataAnnotations;

namespace bpkbFrontEnd.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Konfirmasi password tidak cocok.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterVal
    {
        public string user_name { get; set; }
        public string password { get; set; }
    }

}
