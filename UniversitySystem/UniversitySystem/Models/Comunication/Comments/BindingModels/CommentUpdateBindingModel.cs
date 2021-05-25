namespace UniversitySystem.Models.Comunication.Comments.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    public class CommentUpdateBindingModel : BaseModel
    {

        [Required(ErrorMessage = "Please enter a comment text!")]
        [Display(Name = "Comment")]
        [MinLength(10, ErrorMessage = "Text too short!")]
        [MaxLength(300, ErrorMessage = "Text too long!")]
        public string Text { get; set; }

        [Display(Name = "Upload Date")]
        [MaxLength(14)]
        public string Date { get; set; } = DataType.DateTime.ToString();

    }
}
