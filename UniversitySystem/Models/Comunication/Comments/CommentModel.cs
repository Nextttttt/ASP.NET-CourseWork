namespace UniversitySystem.Models.Comunication.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CommentModel : BaseModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(300)]
        public string Text { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(14)]
        public string Date { get; set; }

    }
}
