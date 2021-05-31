using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySystem.Data;
using UniversitySystem.Models.Faculties;
using UniversitySystem.Models.Faculties.BindingModels;
using UniversitySystem.Services.Interfaces;

namespace UniversitySystem.Services
{
    public class FacultiesService : IFacultiesService
    {

        private readonly ApplicationDbContext dbContext;

        public FacultiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<FacultyModel> GetAll()
        {
            IEnumerable<FacultyModel> faculty = dbContext.Faculties
                .Select(faculty => new FacultyModel
                {
                    Id = faculty.Id,
                    Name = faculty.Name,
                    Desc = faculty.Desc,
                })
                .OrderBy(faculty => faculty.Name)
                .ToList();

            return faculty;

        }

        public FacultyModel GetById(string id)
        {
            FacultyModel faculty = this.dbContext.Faculties
                .Where(faculty => faculty.Id == id)
                .SingleOrDefault();

            return faculty;
        }

        public FacultyViewModel GetForViewById(string id)
        {

            FacultyViewModel faculty = this.dbContext.Faculties
            .Select(s => new FacultyViewModel
            {
                Id = s.Id,
               Name = s.Name,
               Desc = s.Desc,
            })
            .Where(s => s.Id == id)
            .SingleOrDefault();

            return faculty;

        }

        public FacultyModel GetByName(string name)
        {
            FacultyModel facultyFromDb = dbContext.Faculties
                .Where(s => s.Name == name)
                .SingleOrDefault();

            return facultyFromDb;
        }


        public async Task CreateAsync(FacultyBindingModel model)
        {
            FacultyModel faculty = new FacultyModel
            {
                Name = model.Name,
                Desc = model.Desc,
            };

            await this.dbContext.Faculties.AddAsync(faculty);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            FacultyModel faculty = this.GetById(id);

            bool isFacultyNull = faculty == null;

            if (isFacultyNull)
            {
                return;
            }

            this.dbContext.Remove(faculty);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(FacultyUpdateBindingModel model)
        {
            FacultyModel faculty = this.GetById(model.Id);

            bool isFacultyNull = faculty == null;
            if (isFacultyNull)
            {
                return;
            }

            faculty.Name = model.Name;
            faculty.Desc = model.Desc;

            this.dbContext.Faculties.Update(faculty);
            await this.dbContext.SaveChangesAsync();
        }

    }
}
