using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace UniversitySystem.Areas.Identity.Pages.Account
{
    public class RegisterInput
    {

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

        [Required]
            [Display(Name = "EGN")]
            [StringLength(10, ErrorMessage = "The {0} must be {1} characters long.")]
            public string EGN { get; set; }
#nullable enable
            [Display(Name = "Faculty Number")]
            public string? FacultyNumber { get; set; }

            [Display(Name = "Title")]
            public string? Title { get; set; }

            [Display(Name ="Faculty")]
            public string? Faculty { get; set; }
#nullable disable
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Year of Studie")]
        [Required]
        public string Year { get; set; }

        public bool IsTeacher { get; set; }
    }

    public enum EnumFaculty
    {
        [Description("Faculty of History Studies")]
        History,
        Law,
        [Description("Faculty of Arts")]
        Arts,
        [Description("Faculty of Informatics")]
        Science,
        [Description("Faculty of Commerce")]
        Commerce,
        [Description("Faculty of Economics")]
        Economics,
        [Description("Faculty of Educaion")]
        Education,
        [Description("Faculty of Engineering")]
        Engineering
    }

}




