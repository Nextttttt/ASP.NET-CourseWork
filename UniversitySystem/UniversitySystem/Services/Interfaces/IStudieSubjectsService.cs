namespace UniversitySystem.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Models.JoiningModels;

    public interface IStudieSubjectsService
    {


        IEnumerable<StudieSubjects> GetAll();

        public StudieSubjects GetById(string Studieid, string Subjectid);

        public List<StudieSubjects> GetAllById(string id);

        Task CreateAsync(StudieSubjects model);

        Task DeleteAsync(string Studieid, string Subjectid);


    }
}
