namespace UniversitySystem.Models.Studies
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using UniversitySystem.Models.Subjects;

    public class StudieModel : BaseModel
    {
       
        [Required]
        [MinLength(2)]
        [MaxLength(60)]
        public string Name { get; set; }

    }
}
