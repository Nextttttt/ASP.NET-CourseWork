namespace UniversitySystem.Services
{

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Data;
    using UniversitySystem.Models.Subjects;
    using UniversitySystem.Models.Subjects.BindingModels;
    using UniversitySystem.Services.Interfaces;

    public class SubjectsService : ISubjectsService
    {
        private readonly ApplicationDbContext dbContext;

        public SubjectsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<SubjectModel> GetAll()
        {
            IEnumerable<SubjectModel> subjects = dbContext.Subjects
                .Select(subject => new SubjectModel
                {
                    Id = subject.Id,
                    Name = subject.Name,
                })
                .OrderBy(subject => subject.Name)
                .ToList();

            return subjects;

        }

        public SubjectModel GetById(string id)
        {
            SubjectModel subject = this.dbContext.Subjects
                .Where(subject => subject.Id == id)
                .SingleOrDefault();

            return subject;
        }

        public SubjectViewModel GetForViewById(string id)
        {

            SubjectViewModel subject = this.dbContext.Subjects
            .Select(s => new SubjectViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Desc = s.Desc,
            })
            .Where(s => s.Id == id)
            .SingleOrDefault();

            return subject;

        }

        public SubjectModel GetByName(string name)
        {
            SubjectModel subjectFromDb = dbContext.Subjects
                .Where(s => s.Name == name)
                .SingleOrDefault();

            return subjectFromDb;
        }

        public async Task CreateAsync(SubjectBindingModel model)
        {
            SubjectModel subject = new SubjectModel
            {
                Name = model.Name,
                Desc = model.Desc,
            };

            await this.dbContext.Subjects.AddAsync(subject);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            SubjectModel subject = this.GetById(id);

            bool isSubjectNull = subject == null;

            if(isSubjectNull)
            {
                return;
            }

            this.dbContext.Remove(subject);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubjectUpdateBindingModel model)
        {
            SubjectModel subject = this.GetById(model.Id);

            bool isSubjectNull = subject == null;
            if (isSubjectNull)
            {
                return;
            }

            subject.Name = model.Name;
            subject.Desc = model.Desc;

            this.dbContext.Subjects.Update(subject);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
