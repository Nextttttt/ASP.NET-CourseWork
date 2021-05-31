namespace UniversitySystem.Models.Faculties.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class FacultyBindingModel : BaseModel
    {

        [Required(ErrorMessage = "Please, enter a Faculty Name!")]
        [Display(Name = "Faculty Name")]
        [MinLength(3, ErrorMessage = "Name too short!")]
        [MaxLength(50, ErrorMessage = "Name too long!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter a Faculty Description!")]
        [Display(Name = "Description")]
        [MinLength(10, ErrorMessage = "Description too short!")]
        [MaxLength(200, ErrorMessage = "Description too long!")]
        public string Desc { get; set; }

    }
}
