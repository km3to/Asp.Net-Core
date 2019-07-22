using System.ComponentModel.DataAnnotations;

namespace Panda.BindingModels.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; } = false;
    }
}
