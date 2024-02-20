using System.ComponentModel.DataAnnotations;

namespace HamburgaoDoGeorjao.Mvc.Models
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Entre com um email válido")]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }

    public class ClienteCreate
    {
        public ClienteCreate()
        {
            this.Role = "simples";
        }
        [Required]
        [EmailAddress(ErrorMessage = "Entre com um email válido")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Nome { get; set; }


        [Required]
        public string ConfirmPassword { get; set; }
        public string? Role { get; set; }

    }
}
