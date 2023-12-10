using System.ComponentModel.DataAnnotations;

namespace magazin.ModelDto.User
{
    public class RegistrationUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }          
        public string Address { get; set; }
    }
}
