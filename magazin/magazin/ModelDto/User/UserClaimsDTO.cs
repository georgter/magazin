using System.ComponentModel.DataAnnotations;

namespace magazin.ModelDto.User
{
    public class UserClaimsDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Role { get; set; }

        public string? Message { get; set; }
    }
}
