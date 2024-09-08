using System.ComponentModel.DataAnnotations;

namespace Identity.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
