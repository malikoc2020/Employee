using System.ComponentModel.DataAnnotations;

namespace Business.DTO
{
    public class LoginDTO
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required.")]
        [EmailAddress(ErrorMessage ="Email Invalid.")]
        public string Email { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]        
        public string Password { get; set; }
      
    }
}
