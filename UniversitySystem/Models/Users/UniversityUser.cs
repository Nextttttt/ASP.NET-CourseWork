using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
    public class UniversityUser : IdentityUser
    {
        [PersonalData]
        public bool IsTeacher { get; set; }

        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string EGN { get; set; }

        [PersonalData]
        public string Year { get; set; }
#nullable enable
        [PersonalData]
        public string? FacultyNumber { get; set; }

        [PersonalData]
        public string? Title { get; set; }

        [PersonalData]
        public string? Faculty { get; set; }
#nullable disable

    }
}
