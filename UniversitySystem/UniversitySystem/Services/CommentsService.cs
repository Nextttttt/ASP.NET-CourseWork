namespace UniversitySystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Data;
    using UniversitySystem.Models.Comunication.Comments;
    using UniversitySystem.Models.Comunication.Comments.BindingModels;
    using UniversitySystem.Services.Interfaces;

    public class CommentsService : ICommentsService
    {
        private readonly ApplicationDbContext dbContext;

        public CommentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<CommentModel> GetAll()
        {
            IEnumerable<CommentModel> comment = dbContext.Comments
                .Select(comment => new CommentModel
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    Date = comment.Date,
                })
                .OrderBy(comment => comment.Date)
                .ToList();

            return comment;

        }

        public CommentModel GetById(string id)
        {
            CommentModel comment = this.dbContext.Comments
                .Where(comment => comment.Id == id)
                .SingleOrDefault();

            return comment;
        }

        public CommentViewModel GetForViewById(string id)
        {

            CommentViewModel comment = this.dbContext.Comments
            .Select(s => new CommentViewModel
            {
                Id = s.Id,
                Text = s.Text,
            })
            .Where(s => s.Id == id)
            .SingleOrDefault();

            return comment;

        }


        public async Task CreateAsync(CommentBindingModel model)
        {
            CommentModel comment = new CommentModel
            {
                Text = model.Text,
            };

            await this.dbContext.Comments.AddAsync(comment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            CommentModel comment = this.GetById(id);

            bool isCommentNull = comment == null;

            if (isCommentNull)
            {
                return;
            }

            this.dbContext.Remove(comment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CommentUpdateBindingModel model)
        {
            CommentModel comment = this.GetById(model.Id);

            bool isCommentNull = comment == null;
            if (isCommentNull)
            {
                return;
            }

            comment.Text = model.Text;

            this.dbContext.Comments.Update(comment);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
