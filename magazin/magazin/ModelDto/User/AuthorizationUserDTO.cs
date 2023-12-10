using System.ComponentModel.DataAnnotations;

namespace magazin.ModelDto.User
{
    public class AuthorizationUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
