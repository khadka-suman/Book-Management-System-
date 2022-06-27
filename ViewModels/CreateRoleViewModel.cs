using System.ComponentModel.DataAnnotations;

namespace Book.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}