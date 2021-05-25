namespace UniversitySystem.Services.Interfaces
{

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Comunication.Posts;
    using UniversitySystem.Models.Comunication.Posts.BindingModels;

    public interface IPostsService
    {
        IEnumerable<PostModel> GetAll();

        public PostModel GetById(string id);

        public PostViewModel GetForViewById(string id);

        PostModel GetByName(string name);

        Task CreateAsync(PostBindingModel model);

        Task UpdateAsync(PostUpdateBindingModel model);

        Task DeleteAsync(string id);
    }
}
