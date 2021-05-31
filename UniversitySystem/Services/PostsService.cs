namespace UniversitySystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Data;
    using UniversitySystem.Models.Comunication.Posts;
    using UniversitySystem.Models.Comunication.Posts.BindingModels;
    using UniversitySystem.Services.Interfaces;

    public class PostsService : IPostsService
    {
        private readonly ApplicationDbContext dbContext;

        public PostsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<PostModel> GetAll()
        {
            IEnumerable<PostModel> posts = dbContext.Posts
                .Select(post => new PostModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Text = post.Text,
                    Date = post.Date,
                })
                .OrderBy(post => post.Title)
                .ToList();

            return posts;

        }

        public PostModel GetById(string id)
        {
            PostModel post = this.dbContext.Posts
                .Where(post => post.Id == id)
                .SingleOrDefault();

            return post;
        }

        public PostViewModel GetForViewById(string id)
        {

            PostViewModel post = this.dbContext.Posts
            .Select(s => new PostViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Text = s.Text,
            })
            .Where(s => s.Id == id)
            .SingleOrDefault();

            return post;

        }

        public PostModel GetByName(string Title)
        {
            PostModel postFromDb = dbContext.Posts
                .Where(s => s.Title == Title)
                .SingleOrDefault();

            return postFromDb;
        }

        public async Task CreateAsync(PostBindingModel model)
        {
            PostModel post = new PostModel
            {
                Title = model.Title,
                Text = model.Text,
            };

            await this.dbContext.Posts.AddAsync(post);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            PostModel post = this.GetById(id);

            bool isPostNull = post == null;

            if (isPostNull)
            {
                return;
            }

            this.dbContext.Remove(post);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PostUpdateBindingModel model)
        {
            PostModel post = this.GetById(model.Id);

            bool isPostNull = post == null;
            if (isPostNull)
            {
                return;
            }

            post.Title = model.Title;

            this.dbContext.Posts.Update(post);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
