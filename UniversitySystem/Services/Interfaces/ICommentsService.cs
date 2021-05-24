namespace UniversitySystem.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Comunication.Comments;
    using UniversitySystem.Models.Comunication.Comments.BindingModels;
    public interface ICommentsService
    {

        IEnumerable<CommentModel> GetAll();

        public CommentModel GetById(string id);

        public CommentViewModel GetForViewById(string id);

        Task CreateAsync(CommentBindingModel model);

        Task UpdateAsync(CommentUpdateBindingModel model);

        Task DeleteAsync(string id);

    }
}
