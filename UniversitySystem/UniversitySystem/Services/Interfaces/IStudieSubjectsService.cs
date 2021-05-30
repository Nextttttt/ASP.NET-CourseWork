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

        public List<StudieSubjects> GetAllById(string id);


    }
}
