namespace UniversitySystem.Models.Subjects
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using UniversitySystem.Models.Studies;

    public class SubjectModel : BaseModel
    {
       
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MinLength(50)]
        [MaxLength(200)]
        public string Desc { get; set; }

    }
}
