namespace UniversitySystem.Models.Studies.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class StudieUpdateBindingModel : BaseModel
    {
        [Required(ErrorMessage = "Please enter a Studie Name!")]
        [Display(Name = "Studie Name")]
        [MinLength(2, ErrorMessage = "Name too short!")]
        [MaxLength(60, ErrorMessage = "Name too long!")]
        public string Name { get; set; }
    }
}
