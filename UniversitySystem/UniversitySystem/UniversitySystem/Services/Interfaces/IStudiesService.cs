namespace UniversitySystem.Services.Interfaces
{

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Studies;
    using UniversitySystem.Models.Studies.BindingModels;

    public interface IStudiesService
    {
        IEnumerable<StudieModel> GetAll();

        public StudieModel GetById(string id);

        public StudieViewModel GetForViewById(string id);

        StudieModel GetByName(string name);

        Task CreateAsync(StudieBindingModel model);

        Task UpdateAsync(StudieUpdateBindingModel model);

        Task DeleteAsync(string id);
    }
}
