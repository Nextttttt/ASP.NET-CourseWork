namespace UniversitySystem.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Faculties;
    using UniversitySystem.Models.Faculties.BindingModels;

    public interface IFacultiesService
    {

        IEnumerable<FacultyModel> GetAll();

        public FacultyModel GetById(string id);

        public FacultyViewModel GetForViewById(string id);

        FacultyModel GetByName(string name);

        Task CreateAsync(FacultyBindingModel model);

        Task UpdateAsync(FacultyUpdateBindingModel model);

        Task DeleteAsync(string id);

    }
}
