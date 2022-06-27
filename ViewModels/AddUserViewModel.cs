using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Book.ViewModels
{
    public class AddUserViewModel
    {
        [PersonalData]
        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 2)]
        public string firstname { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}