using System.ComponentModel.DataAnnotations;

namespace Identity.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(40)]
        public string Password { get; set; }
        
        [Compare(nameof(Password))]
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(40)]
        public string ConfirmPassword { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
    }
}
