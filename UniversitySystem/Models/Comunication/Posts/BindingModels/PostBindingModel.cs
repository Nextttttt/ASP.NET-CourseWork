namespace UniversitySystem.Models.Comunication.Posts.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class PostBindingModel
    {
        [Required(ErrorMessage = "Please enter a Post Title!")]
        [Display(Name = "Post Title")]
        [MinLength(2, ErrorMessage = "Title too short!")]
        [MaxLength(30, ErrorMessage = "Title too long!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Post`s text!")]
        [Display(Name = "Post")]
        [MinLength(2, ErrorMessage = "Post too short!")]
        [MaxLength(200, ErrorMessage = "Post too long!")]
        public string Text { get; set; }

        [Display(Name = "Upload Time")]
        [MaxLength(14)]
        public string Date { get; set; } = DataType.DateTime.ToString();
    }
}
