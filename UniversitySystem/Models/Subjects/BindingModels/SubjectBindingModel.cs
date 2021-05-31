namespace UniversitySystem.Models.Subjects.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class SubjectBindingModel : BaseModel
    {
        [Required(ErrorMessage = "Please enter a Subject Name!")]
        [Display(Name = "Subject Name")]
        [MinLength(2, ErrorMessage = "Name too short!")]
        [MaxLength(30, ErrorMessage = "Name too long!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Subject Description!")]
        [Display(Name = "Subject Description")]
        [MinLength(50, ErrorMessage = "Description too short!")]
        [MaxLength(200, ErrorMessage = "Description too long!")]
        public string Desc { get; set; }
    }
}
