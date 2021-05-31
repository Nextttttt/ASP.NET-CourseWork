namespace UniversitySystem.Models.Comunication.Posts
{
    using System.ComponentModel.DataAnnotations;

    public class PostModel : BaseModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string Text { get; set; }
        [Required]
        [MaxLength(14)]
        public string Date { get; set; }

    }
}
