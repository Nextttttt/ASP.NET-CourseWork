namespace UniversitySystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Data;
    using UniversitySystem.Models.Studies;
    using UniversitySystem.Models.Studies.BindingModels;
    using UniversitySystem.Services.Interfaces;

    public class StudiesService : IStudiesService
    {
        private readonly ApplicationDbContext dbContext;

        public StudiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<StudieModel> GetAll()
        {
            IEnumerable<StudieModel> studies = dbContext.Studies
                .Select(subject => new StudieModel
                {
                    Id = subject.Id,
                    Name = subject.Name,
                })
                .OrderBy(subject => subject.Name)
                .ToList();

            return studies;

        }

        public StudieModel GetById(string id)
        {
            StudieModel studie = this.dbContext.Studies
                .Where(subject => subject.Id == id)
                .SingleOrDefault();

            return studie;
        }

        public StudieViewModel GetForViewById(string id)
        {

            StudieViewModel studie = this.dbContext.Studies
            .Select(s => new StudieViewModel
            {
                Id = s.Id,
                Name = s.Name,
            })
            .Where(s => s.Id == id)
            .SingleOrDefault();

            return studie;

        }

        public StudieModel GetByName(string name)
        {
            StudieModel studieFromDb = dbContext.Studies
                .Where(s => s.Name == name)
                .SingleOrDefault();

            return studieFromDb;
        }

        public async Task CreateAsync(StudieBindingModel model)
        {
            StudieModel studie = new StudieModel
            {
                Name = model.Name
            };

            await this.dbContext.Studies.AddAsync(studie);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            StudieModel studie = this.GetById(id);

            bool isStudieNull = studie == null;

            if (isStudieNull)
            {
                return;
            }

            this.dbContext.Remove(studie);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudieUpdateBindingModel model)
        {
            StudieModel studie = this.GetById(model.Id);

            bool isStudieNull = studie == null;
            if (isStudieNull)
            {
                return;
            }

            studie.Name = model.Name;

            this.dbContext.Studies.Update(studie);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
