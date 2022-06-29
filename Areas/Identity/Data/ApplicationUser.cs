using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Book.Models;


namespace Book.Areas.Identity.Data;

public class ApplicationUser : IdentityUser
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

   /* [Required]
    [Display(Name = "User Name")]
    public string Username => firstname + " " + lastname;*/

    [Required]
    [Display(Name = "Address")]
    public string address { get; set; }

    [Required]
    [Display(Name = "Age")]
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public int age { get; set; }

    

    [NotMapped]
    public string RoleId { get; set;}

    [NotMapped]
    public string Role { get; set; }
}

