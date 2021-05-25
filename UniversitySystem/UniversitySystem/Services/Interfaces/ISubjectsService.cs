namespace UniversitySystem.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Subjects;
    using UniversitySystem.Models.Subjects.BindingModels;

    public interface ISubjectsService
    {

        IEnumerable<SubjectModel> GetAll();

        public SubjectModel GetById(string id);

        public SubjectViewModel GetForViewById(string id);

        SubjectModel GetByName(string name);

        Task CreateAsync(SubjectBindingModel model);

        Task UpdateAsync(SubjectUpdateBindingModel model);

        Task DeleteAsync(string id);

    }
}
