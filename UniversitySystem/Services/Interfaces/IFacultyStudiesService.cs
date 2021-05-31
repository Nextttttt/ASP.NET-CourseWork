namespace UniversitySystem.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Models.JoiningModels;

    public interface IFacultyStudiesService
    {

        IEnumerable<FacultyStudies> GetAll();

        public FacultyStudies GetById(string Facultyid, string Studieid);

        public List<FacultyStudies> GetAllById(string id);

        Task CreateAsync(FacultyStudies model);

        Task DeleteAsync(string Facultyid, string Studieid);

        Task DeleteAsync(string id);

    }
}
