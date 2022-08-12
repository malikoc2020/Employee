using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class AuthenticateModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required.")]
        public string Email { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
