namespace UniversitySystem.Models.Enrollments
{
    using System.ComponentModel.DataAnnotations;

    public class EnrollmentModel : BaseModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(2)]
        public int Value { get; set; }
    }
}
